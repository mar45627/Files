using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Ionic.Zip;

namespace IndexEditor
{
    class IndexDir
    {
        private List<ulong> resList; 
        public string Name;
        public IndexDir(string name, List<ulong> resources )
        {
            Name = name;
            resList = resources;
        }

        public bool IsEmpty()
        {
            return _items.Count == 0 && _dirs.Count == 0;
        }

        public void Clear()
        {
            _items.Clear();
            foreach (var dir in _dirs)
            {
                dir.Clear();
            }
            _dirs.Clear();
        }

        public ulong ReadResId(string file)
        {
            var doc = XDocument.Load(file);
            ulong id = 0;
            if (doc.Root != null)
            {
                var xElement = doc.Root.Element("Header");
                var element = xElement?.Element("resourceId");
                if (element != null)
                {
                    var resId = element.Value;
                    id = Convert.ToUInt64(resId);
                }
               // if (xElement?.Element("isPrototype") != null)
               //     return 0;
            }
            return id;
        }

        public ulong ReadResId(ZipEntry e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                e.Extract(ms);
                ms.Position = 0;

                var doc = XDocument.Load(ms);
                ulong id = 0;
                if (doc.Root != null)
                {
                    var xElement = doc.Root.Element("Header");
                    var element = xElement?.Element("resourceId");
                    if (element != null)
                    {
                        var resId = element.Value;
                        id = Convert.ToUInt64(resId);
                    }
                  //  if (xElement?.Element("isPrototype") != null)
                  //      return 0;
                }
                return id;
            }
        }

        public void AddDirectory(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.xdb", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < dirs.Count; i++)
                dirs[i] = dirs[i].Replace('\\', '/');

            foreach (var t in dirs)
            {
                string tmp = t.Substring(path.Length);
                ulong resId = ReadResId(t);
                if (resId != 0 && resList.FirstOrDefault(d => d == resId) == 0)
                    AddPath(tmp, resId);
            }
        }

        public void AddPaks(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.pak", SearchOption.AllDirectories).ToList();
            foreach (var t in dirs)
            {
                ZipFile zip = ZipFile.Read(t);
                foreach (var e in zip.Entries.Where(d => !d.IsDirectory && Path.GetExtension(d.FileName) == ".xdb"))
                {
                    ulong resId = ReadResId(e);
                    if(resId != 0 && resList.FirstOrDefault(d => d == resId) == 0)
                        AddPath(e.FileName, resId);
                }
            }
        }

        public void AddPak(string pak)
        {
            ZipFile zip = ZipFile.Read(pak);
            foreach (var e in zip.Entries.Where(d => !d.IsDirectory))
            {
                ulong resId = ReadResId(e);
                if (resId != 0 && resList.FirstOrDefault(t => t == resId) == 0)
                    AddPath(e.FileName, resId);
            }
        }

        public IndexDir MovePath(string fullpath)
        {
            if (string.IsNullOrEmpty(fullpath)) return this;
            int slash = fullpath.IndexOf('/');
            if (slash == 0)
            {
                fullpath = fullpath.Remove(0, 1);
                slash = fullpath.IndexOf('/');
            }
            IndexDir found = null;
            if (slash > 0)
            {
                string item = fullpath.Substring(0, slash);
                var d = _dirs.FirstOrDefault(t => t.Name == item);
                found = d?.MovePath(fullpath.Substring(slash + 1));
                return found;
            }
            var dir = _dirs.FirstOrDefault(d => d.Name == fullpath);
            found = dir?.MovePath(fullpath.Substring(slash + 1));
            return found ?? this;
        }

        public void AddPath(string fullpath, ulong resId)
        {
            int slash = fullpath.IndexOf('/');
            if (slash == 0)
            {
                fullpath = fullpath.Remove(0,1);
                slash = fullpath.IndexOf('/');
            }
            if (slash > 0)
            {
                string item = fullpath.Substring(0, slash);
                bool isFound = false;
                foreach (var d in _dirs.Where(d => d.Name == item))
                {
                    d.AddPath(fullpath.Substring(slash + 1), resId);
                    isFound = true;
                }
                if (!isFound)
                {
                    var dir = new IndexDir(item, resList) {Parent = this};
                    dir.AddPath(fullpath.Substring(slash + 1), resId);
                    _dirs.Add(dir);
                }
            }
            else
            {
                if (!_items.Exists(t => t.Name == fullpath))
                {
                    resList.Add(resId);
                    _items.Add(new Item {Name = fullpath, ResId = resId});
                }
            }
        }

        public IndexDir Parent = null;
        private readonly List<IndexDir> _dirs = new List<IndexDir>();
        private readonly List<Item> _items = new List<Item>();

        public List<string> GetChildList()
        {
            List<string> items = _items.Select(item => item.Name).ToList();
            List<string> dirs = _dirs.Select(d => d.Name).ToList();
            items.Sort((x, y) => String.Compare(x, y, StringComparison.Ordinal));
            dirs.Sort((x, y) => String.Compare(x, y, StringComparison.Ordinal));
            List<string> list = new List<string>();
            list.AddRange(dirs.ToArray());
            list.AddRange(items.ToArray());
            items.Clear();
            dirs.Clear();
            return list;
        }

        public void GetAll(List<string> outList, string path = "")
        {
            outList.AddRange(_items.Select(item => item.ResId + "#" + path + Name + "/" + item.Name));
            foreach (var dir in _dirs)
            {
                dir.GetAll(outList, path + Name + "/");
            }
        }

        public IndexDir GetDir(string name)
        {
            return _dirs.FirstOrDefault(d => d.Name == name);
        }
        public Item GetItem(string name)
        {
            return _items.FirstOrDefault(d => d.Name == name);
        }

        public void Delete(string name)
        {
            var firstOrDefault = _dirs.FirstOrDefault(d => d.Name == name);
            firstOrDefault?.Clear();
            _dirs.Remove(firstOrDefault);
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name != name) continue;
                _items.RemoveAt(i);
                break;
            }
        }

        public string GetPath()
        {
            if (Parent != null)
            {
                return Parent.GetPath() + "/" + Name ;
            }
            return Name;
        }
    }
}
