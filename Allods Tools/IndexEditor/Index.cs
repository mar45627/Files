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
    class Index
    {
        public string Version = "1183";
        public string Directory;
        public static List<ulong> resIds = new List<ulong>();
        public IndexDir AllDirs = new IndexDir(null, resIds);

        public void Load()
        {
            string index = Directory + "/System/index.bak.srv";

            if (!File.Exists(index)) return;

            List<string> lines = File.ReadAllLines(index).ToList();
            Version = lines[0];
            lines.RemoveAt(0);

            foreach (var str in lines)
            {
                string[] s = str.Split('#');
                ulong id = Convert.ToUInt64(s[0]);
                //string path = s[1].Remove(0, 1);
                AllDirs.AddPath(s[1], id);
            }
        }

        public void Save()
        {
            string index = Directory + "/System/index.srv";

            List<string> files = new List<string>();
            AllDirs.GetAll(files);
            files.Sort((x, y) => Convert.ToUInt64(x.Substring(0, x.IndexOf('#'))).CompareTo(Convert.ToUInt64(y.Substring(0, y.IndexOf('#')))));
            files.Insert(0, Version);
            
            File.WriteAllLines(index, files);
            files.Clear();
        }
        
    }
}
