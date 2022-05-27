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
    public class Progress : EventArgs
    {

        public int Loaded { get; set; }
        public int Max { get; private set; }

        private Progress() { }

        public Progress(int status, int max)
        {
            Loaded = status;
            Max = max;
        }
    }

    class Index
    {
        public delegate void EventHandler(object sender, Progress e);

        public event EventHandler LoadProgressChanged;
        protected virtual void onLoad(Progress e)
        {
            LoadProgressChanged?.Invoke(this, e);
        }

        public IndexDir Root, Current;

        public string Version = "1183";
        public string FileIndex;
       // public static List<ulong> resIds = new List<ulong>();
        public IndexDir AllDirs = new IndexDir(null);

        public Index()
        {
            Root = Current = AllDirs;
        }

        public void Load()
        {
            if (!File.Exists(FileIndex)) return;

            List<string> lines = File.ReadAllLines(FileIndex).ToList();
            Version = lines[0];
            lines.RemoveAt(0);

            Progress pr = new Progress(0, lines.Count);
            int i = 0;
            foreach (var str in lines)
            {
                string[] s = str.Split('#');
                ulong id = Convert.ToUInt64(s[0]);
                AllDirs.AddPath(s[1], id);
                pr.Loaded = i;
                onLoad(pr);
                i++;
            }
            pr.Loaded = 0;
            onLoad(pr);
        }

        public List<string> SaveHelper()
        {
            List<string> files = new List<string>();
            AllDirs.GetAll(files);
            files.Sort((x, y) => Convert.ToUInt64(x.Substring(0, x.IndexOf('#'))).CompareTo(Convert.ToUInt64(y.Substring(0, y.IndexOf('#')))));
            return files;
        }

        public void Save(List<string> list)
        {
            list.Insert(0, Version);
            File.WriteAllLines(FileIndex, list);
            list.Clear();
        }
        
    }
}
