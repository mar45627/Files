using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;

namespace IndexEditor
{
    public class IndexDir
    {
        //private List<ulong> resList; 
        public string Name;
        public IndexDir(string name/*, List<ulong> resources */)
        {
            Name = name;
           // resList = resources;
        }

        public bool IsEmpty()
        {
            return _items.Count == 0 && _dirs.Count == 0;
        }

        public void Clear()
        {
            foreach (var i in _items)
            {
               // resList.Remove(i.ResId);
            }
            _items.Clear();
            foreach (var dir in _dirs)
            {
                dir.Clear();
            }
            _dirs.Clear();
        }

        public delegate void EventHandler(object sender, Progress e);

        public event EventHandler LoadProgressChanged;
        protected virtual void onLoad(Progress e)
        {
            LoadProgressChanged?.Invoke(this, e);
        }

        public ulong ReadResId(string file)
        {
            try
            {
                var doc = XDocument.Load(file);
                ulong id = 0;
                if (doc.Root != null)
                {
                    var str = doc.Root.Name.LocalName;
                    if (!str.Substring(0, 13).Equals("gameMechanics", StringComparison.OrdinalIgnoreCase) &&
                            !str.Substring(0, 16).Equals("avatarPopulation", StringComparison.OrdinalIgnoreCase) &&
                            !str.Substring(0, 9).Equals("mapLoader", StringComparison.OrdinalIgnoreCase))
                        throw new Exception("0");

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
            catch (Exception ex)
            {
                throw new Exception("0");
            }
        }

        public ulong ReadResId(ZipEntry e)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                e.Extract(ms);
                ms.Position = 0;

                var doc = XDocument.Load(ms);
                ulong id = 0;
                try
                {
                    if (doc.Root != null)
                    {
                        var str = doc.Root.Name.LocalName; 
                        if (!str.Substring(0, 13).Equals("gameMechanics", StringComparison.OrdinalIgnoreCase) &&
                            !str.Substring(0, 16).Equals("avatarPopulation", StringComparison.OrdinalIgnoreCase) &&
                            !str.Substring(0, 9).Equals("mapLoader", StringComparison.OrdinalIgnoreCase))
                            throw new Exception("0");

                        var xElement = doc.Root.Element("Header");
                        if (xElement == null)
                            return 0;
                        var element = xElement?.Element("resourceId");
                        if (element != null)
                        {
                            var resId = element.Value;
                            id = Convert.ToUInt64(resId);
                        }
                        //  if (xElement?.Element("isPrototype") != null)
                        //      return 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("0");
                }
                return id;
            }
        }

        public bool WriteResId(string file, ulong resId)
        {
            try
            {
                var doc = XDocument.Load(file);
                if (doc.Root != null)
                {
                    var xElement = doc.Root.Element("Header");
                    if (xElement == null)
                    {
                        var resEl = new XElement("resourceId", resId);
                        doc.Root.AddFirst(new XElement("Header", resEl));
                    }
                    else if (xElement.Element("resourceId") == null)
                    {
                        var resEl = new XElement("resourceId", resId);
                        xElement.Add(resEl);
                    }
                    else
                    {
                        var element = xElement.Element("resourceId");
                        if (element != null)
                            element.Value = Convert.ToString(resId);
                    }
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Encoding = new ASCIIEncoding();
                    settings.Indent = true;
                    settings.IndentChars = "    ";
                    settings.OmitXmlDeclaration = true;

                    StringWriter sw = new StringWriter();
                    using (var writer = XmlWriter.Create(sw, settings))
                    {
                        doc.Save(writer);
                    }
                    File.WriteAllText(file, "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + sw.ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, file, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }

        public void IndexAllNull(string folder, ref ulong startResId)
        {
            foreach (var i in _items)
            {
                if (i.ResId == 0)
                {
                    if(WriteResId(folder + GetPath() + "/" + i.Name, startResId))
                        i.ResId = startResId;
                    startResId++;
                }
            }
            foreach(var d in _dirs)
                d.IndexAllNull(folder, ref startResId);
        }

        public void IndexAll(string folder, ref ulong startResId)
        {
            foreach (var i in _items)
            {
                if (WriteResId(folder + GetPath() + "/" + i.Name, startResId))
                    i.ResId = startResId;
                startResId++;
            }
            foreach (var d in _dirs)
                d.IndexAll(folder, ref startResId);
        }

        public void AddDirectory(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.xdb", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < dirs.Count; i++)
                dirs[i] = dirs[i].Replace('\\', '/');

            Progress pr = new Progress(0, dirs.Count);
            int a = 0;
            foreach (var t in dirs)
            {
                string tmp = t.Substring(path.Length);
                try
                {
                    ulong resId = ReadResId(t);
                    //if (resId != 0 /*&& resList.FirstOrDefault(d => d == resId) == 0*/)
                    AddPath(tmp, resId);
                }
                catch (Exception)
                {
                    // ignored
                }
                pr.Loaded = a;
                onLoad(pr);
            }
            pr.Loaded = 0;
            onLoad(pr);
        }

        public void AddItems(List<string> fnames)
        {
            for (int i = 0; i < fnames.Count; i++)
                fnames[i] = fnames[i].Replace('\\', '/');
            foreach (var f in fnames)
            {
                try
                {
                    ulong resId = ReadResId(f);
                    // if (resId != 0 /*&& resList.FirstOrDefault(d => d == resId) == 0*/)
                    AddPath(Path.GetFileName(f), resId);
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public void AddFolder(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.xdb", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < dirs.Count; i++)
                dirs[i] = dirs[i].Replace('\\', '/');

            Progress pr = new Progress(0, dirs.Count);
            int a = 0;
            foreach (var t in dirs)
            {
                string tmp = t.Substring(Path.GetDirectoryName(path).Length + 1);
                try
                {
                    ulong resId = ReadResId(t);
                    //if (resId != 0 /*&& resList.FirstOrDefault(d => d == resId) == 0*/)
                    AddPath(tmp, resId);
                }
                catch (Exception)
                {
                    // ignored
                }
                pr.Loaded = a;
                onLoad(pr);
            }
            pr.Loaded = 0;
            onLoad(pr);
        }

        public void AddPaks(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.pak", SearchOption.AllDirectories).ToList();
            Progress pr = new Progress(0, dirs.Count);
            int i = 0;
            foreach (var t in dirs)
            {
                ZipFile zip = ZipFile.Read(t);
                foreach (var e in zip.Entries.Where(d => !d.IsDirectory && Path.GetExtension(d.FileName) == ".xdb"))
                {
                    try
                    {
                        ulong resId = ReadResId(e);
                        if (resId != 0 /*&& resList.FirstOrDefault(d => d == resId) == 0*/)
                            AddPath(e.FileName, resId);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                pr.Loaded = i;
                onLoad(pr);
            }
            pr.Loaded = 0;
            onLoad(pr);
        }

        public void AddPak(string pak)
        {
            ZipFile zip = ZipFile.Read(pak);
            Progress pr = new Progress(0, zip.Entries.Count);
            int i = 0;
            foreach (var e in zip.Entries.Where(d => !d.IsDirectory))
            {
                try
                {
                    ulong resId = ReadResId(e);
                    if (resId != 0/* && resList.FirstOrDefault(t => t == resId) == 0*/)
                        AddPath(e.FileName, resId);
                }
                catch (Exception)
                {
                    // ignored
                }
                pr.Loaded = i;
                onLoad(pr);
            }
            pr.Loaded = 0;
            onLoad(pr);
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
                    var dir = new IndexDir(item/*, resList*/) {Parent = this};
                    dir.AddPath(fullpath.Substring(slash + 1), resId);
                    _dirs.Add(dir);
                }
            }
            else
            {
                if (!_items.Exists(t => t.Name == fullpath))
                {
                    //resList.Add(resId);
                    _items.Add(new Item {Name = fullpath, ResId = resId});
                }
            }
        }

        public void AddDir(string fullpath) {
            int slash = fullpath.IndexOf('/');
            if (slash == 0) {
                fullpath = fullpath.Remove(0, 1);
                slash = fullpath.IndexOf('/');
            }
            if (slash > 0) {
                string item = fullpath.Substring(0, slash);
                bool isFound = false;
                foreach (var d in _dirs.Where(d => d.Name == item)) {
                    d.AddDir(fullpath.Substring(slash + 1));
                    isFound = true;
                }
                if (!isFound) {
                    var dir = new IndexDir(item) { Parent = this };
                    dir.AddDir(fullpath.Substring(slash + 1));
                    _dirs.Add(dir);
                }
            } else {
                if (!_dirs.Exists(t => t.Name == fullpath)) {
                    _dirs.Add(new IndexDir(fullpath) { Parent = this });
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

        public void GetItems(List<Item> items, string path = "")
        {
            foreach (var item in _items)
            {
                item.Path = path + Name + "/";
                items.Add(item);
            }
            foreach(var dir in _dirs)
                dir.GetItems(items, path + Name + "/");
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
                //resList.Remove(_items[i].ResId);
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

        public void GetMaxResId(ref ulong resId)
        {
            foreach(var i in _items)
                if (i.ResId > resId)
                    resId = i.ResId;
            foreach(var d in _dirs)
                d.GetMaxResId(ref resId);
        }
    }
}
