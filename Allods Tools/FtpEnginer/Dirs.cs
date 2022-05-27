using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpEnginer
{
    class Item
    {
        public DateTime Date;
        public string Name;
    }

    class Dir
    {
        public string Name;
        List<Item> _items = new List<Item>();
        List<Dir> _dirs = new List<Dir>();

        public Dir(string name)
        {
            Name = name;
        }

        void AddPath(string fullpath, DateTime date)
        {
            int slash = fullpath.IndexOf('/');
            if (slash == 0)
            {
                fullpath = fullpath.Remove(0, 1);
                slash = fullpath.IndexOf('/');
            }
            if (slash > 0)
            {
                string item = fullpath.Substring(0, slash);
                bool isFound = false;
                foreach (var d in _dirs.Where(d => d.Name == item))
                {
                    d.AddPath(fullpath.Substring(slash + 1), date);
                    isFound = true;
                }
                if (!isFound)
                {
                    var dir = new Dir(item);
                    dir.AddPath(fullpath.Substring(slash + 1), date);
                    _dirs.Add(dir);
                }
            }
            else
            {
                if (!_items.Exists(t => t.Name == fullpath))
                {
                    _items.Add(new Item { Name = fullpath, Date = date });
                }
            }
        }

        public void Load(string path)
        {
            List<string> dirs = Directory.GetFiles(path, "*.xdb", SearchOption.AllDirectories).ToList();

            for (int i = 0; i < dirs.Count; i++)
                dirs[i] = dirs[i].Replace('\\', '/');

            for (int i = 0; i < dirs.Count; i++)
                dirs[i] = dirs[i].Remove(0, 2);

            foreach (var d in dirs)
            {
                FileInfo f = new FileInfo(d);
                AddPath(d, f.LastWriteTime);
            }
        }

        public void Refresh(string path = "")
        {
            foreach (var d in _dirs)
            {
                d.Refresh(path + "/" + d.Name);
            }
            if(path != "")
                path = path.Remove(0, 1);
            foreach (var i in _items)
            {
                FileInfo f = new FileInfo(path + "/" + i.Name);
                i.Date = f.LastWriteTime;
            }
        }

        public void Save(List<string> list, string path)
        {
            foreach (var d in _dirs)
            {
                d.Save(list, path + "/" + d.Name);
            }
            list.AddRange(_items.Select(i => i.Date.ToString("yyyy-MM-dd HH:mm:ss.fffffff tt") + "#" + path + "/" + i.Name));
        }

        public Dir GetDir(string name)
        {
            return _dirs.FirstOrDefault(d => d.Name == name);
        }
        public Item GetItem(string name)
        {
            return _items.FirstOrDefault(d => d.Name == name);
        }

        public Item Search(string path)
        {
            int pos = path.IndexOf('/');
            if (pos != -1)
            {
                path = path.Substring(pos + 1);
                pos = path.IndexOf('/');
                if (pos != -1)
                {
                    var dir = GetDir(path.Substring(0, pos));
                    if (dir != null)
                        return dir.Search(path);
                }
            }
            return _items.FirstOrDefault(i => i.Name == path);
        }

        public void CheckDates(List<string> files, List<string> newFiles)
        {
            foreach (var f in files)
            {
                string str = f.Remove(f.IndexOf('#'));
                DateTime date = DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss.fffffff tt", null);
                var item = Search(f.Substring(f.IndexOf('#') + 1));
                if (item?.Date.CompareTo(date) == 1)
                    newFiles.Add(f.Substring(f.IndexOf('#') + 1));
            }
        }
    }
}
