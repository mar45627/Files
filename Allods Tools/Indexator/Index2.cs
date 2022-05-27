using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Ionic.Zip;
using static System.String;

namespace IndexEditor
{
    class Index2
    {
        private string _mDir;

        private List<ZipFile> _packs = new List<ZipFile>(); 
        private List<Item> _items = new List<Item>();
        private List<Item> _added = new List<Item>(); 

        public List<string> GetAddedItems()
        {
            return _added.Select(t => t.ResId + " - " + t.Path).ToList();
        }

        private void SortAdded()
        {
            _added.Sort((x, y) => x.ResId.CompareTo(y.ResId));
        }

        public void SortByPath()
        {
            _items.Sort((x, y) => Compare(x.Path, y.Path, StringComparison.Ordinal));
        }

        public void SortById()
        {
            _items.Sort((x,y) => x.ResId.CompareTo(y.ResId));
        }

        public void Save()
        {
            if (!Directory.Exists(_mDir + "/System"))
                Directory.CreateDirectory(_mDir + "/System");
            string index = _mDir + "/System/index.srv";

            List<string> lines = _items.Select(item => item.ResId + "#/" + item.Path).ToList();
            lines.Insert(0, "1183");
            File.WriteAllLines(index, lines);
            lines.Clear();
        }

        private void LoadIndex()
        {
            string index = _mDir + "/System/index.srv";

            if (!File.Exists(index)) return;

            List<string> lines = File.ReadAllLines(index).ToList();
            lines.RemoveAt(0);

            foreach (var str in lines)
            {
                string[] s = str.Split('#');
                ulong id = Convert.ToUInt64(s[0]);
                string path = s[1].Remove(0,1);
                _items.Add(new Item { Path = path, ResId = id });
            }
        }

        public void SetDir(string dir)
        {
            _mDir = dir;
        }

        public Index2(string dir)
        {
            _mDir = dir;
            LoadIndex();
            LoadFolder();
        }

        private void GetPacks(string folder)
        {
            IEnumerable<string> list = Directory.GetFiles(_mDir, "*.pak", SearchOption.AllDirectories);
            foreach (var e in list)
                _packs.Add(ZipFile.Read(e));

            foreach (var e in from zip in _packs from e in zip.Entries.Where(t => !t.IsDirectory) let isFound = _items.Any(item => item.Path == e.FileName) where !isFound select e)
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
                    }

                    bool isFound = _items.Any(item => item.ResId == id);
                    if (isFound) continue;

                    _items.Add(new Item { Path = e.FileName, ResId = id });
                    _added.Add(new Item { Path = e.FileName, ResId = id });
                }
            }
        }

        private void GetFiles(string folder)
        {
            IEnumerable<string> list = Directory.GetFiles(_mDir, "*.xdb", SearchOption.AllDirectories);
            foreach (var e in list)
            {
                string file = e.Replace('\\', '/');

                string cut = file.Substring(_mDir.Length + 1);

                bool isFound = _items.Any(item => item.Path == cut);
                if (isFound) continue;

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
                }

                isFound = _items.Any(item => item.ResId == id);
                if (isFound) continue;

                _items.Add(new Item { Path = cut, ResId = id });
                _added.Add(new Item { Path = cut, ResId = id });
            }
        }

        public void LoadFolder(string dir = null)
        {
            if (dir == null)
            {
                GetFiles(_mDir);
                GetPacks(_mDir);
            }
            else
            {
                GetFiles(dir);
                GetPacks(dir);
            }
            SortAdded();
        }
    }
}
