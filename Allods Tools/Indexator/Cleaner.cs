using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;

namespace IndexEditor
{
    class Dup
    {
        public long ResourceId;
        public string Xdb;
    }

    class Delete
    {
        public string First;
        public string Last;
    }

    class Cleaner
    {
        public string Version;
        private List<Dup> _items = new List<Dup>();
        private List<Dup> _new = new List<Dup>(); 
        private List<Delete> _dels = new List<Delete>();

        public void LoadDir(string dir)
        {
            string newIndex = dir + "/index.new.srv";
            string index = dir + "/index.bak.srv";

            List<string> newLines = File.ReadAllLines(newIndex).ToList();

            newLines.RemoveAt(0);

            foreach (var t in newLines)
            {
                long resId = Convert.ToInt64(t.Substring(0, t.IndexOf('#')));
                string path = t.Substring(t.IndexOf('#') + 1);

                _new.Add(new Dup { ResourceId = resId, Xdb = path });
            }

            List<string> lines = File.ReadAllLines(index).ToList();
            Version = lines[0];
            lines.RemoveAt(0);

            foreach (var t in lines)
            {
                long resId = Convert.ToInt64(t.Substring(0, t.IndexOf('#')));
                string path = t.Substring(t.IndexOf('#') + 1);

                _items.Add(new Dup {ResourceId = resId, Xdb = path});
            }
            lines.Clear();
        }

        public void NewSaveClean(string dir, ProgressBar bar)
        {
            var log = new List<string>();

            bar.Maximum = _new.Count;
            bar.Value = 0;

            List<Dup> saves = new List<Dup>();
            foreach (var n in _new)
            {
                bool flag = false;
                foreach (var t in _items)
                {
                    if (n.ResourceId == t.ResourceId)
                    {
                        log.Add("================================================\n"
                                + t.ResourceId + "#" + t.Xdb + " - Old\n"
                                + n.ResourceId + "#" + n.Xdb + " - New\n"
                                + "===================================================\n");
                        flag = true;
                    }
                }
                if(!flag)
                    saves.Add(n);
                bar.Value++;
            }


            //for (int i = 0; i < _new.Count; i++)
            //{
            //    Dup d = _new[i];
            //    foreach (Dup t1 in _items)
            //    {
            //        if (d.ResourceId == t1.ResourceId)
            //        {
            //            log.Add("================================================\n"
            //                    + t1.ResourceId + "#" + t1.Xdb + " - Old\n"
            //                    + d.ResourceId + "#" + d.Xdb + " - New\n"
            //                    + "===================================================\n");
            //            _new.RemoveAt(i);
            //        }
            //    }
            //    bar.Value++;
            //}
            File.WriteAllLines("ClearNewLog.txt", log);
            log.Clear();

            var lines = saves.Select(v => v.ResourceId + "#" + v.Xdb).ToList();
            lines.Insert(0, Version);
            File.WriteAllLines(dir + "/index.new.srv", lines);

            lines.InsertRange(1, _items.Select(v => v.ResourceId + "#" + v.Xdb).ToList());

            File.WriteAllLines(dir + "/index.srv", lines);
            lines.Clear();

            saves.Clear();

            bar.Value = 0;

            MessageBox.Show("Done");
        }

        public void SaveCleaned(string dir, ProgressBar bar)
        {
            var log = new List<string>();

            bar.Maximum = _new.Count;
            bar.Value = 0;
            foreach (var d in _new)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    var t = _items[i];
                    if (d.ResourceId == t.ResourceId)
                    {
                        log.Add("================================================\n" 
                            + _items[i].ResourceId + "#" + _items[i].Xdb + " - Cleared\n"
                            + d.ResourceId + "#" + d.Xdb + " - Duplication\n"
                            + "===================================================");
                        _dels.Add(new Delete {First = _items[i].Xdb, Last = d.Xdb});
                        _items.RemoveAt(i);
                    }
                }
                bar.Value++;
            }
            File.WriteAllLines("ClearLog.txt", log);
            log.Clear();

            var lines = _items.Select(v => v.ResourceId + "#" + v.Xdb).ToList();
            lines.Insert(0, Version);
            File.WriteAllLines(dir + "/index.bak.srv", lines);

            lines.AddRange(_new.Select(v => v.ResourceId + "#" + v.Xdb)); 

            File.WriteAllLines(dir + "/index.srv", lines);
            lines.Clear();

            bar.Value = 0;

            if (
                MessageBox.Show("Do you want to clear the packs?", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                DialogResult.Yes)
            {
                using (FolderBrowserDialog dlg = new FolderBrowserDialog() { SelectedPath = dir})
                {
                    if(dlg.ShowDialog() == DialogResult.OK)
                        ClearPacks(dlg.SelectedPath, bar);
                }
            }
        }

        public void ClearPacks(string Dir, ProgressBar bar)
        {
            List<string> dirs = Directory.GetFiles(Dir, "*.Server.pak", SearchOption.AllDirectories).Where(t => t.IndexOf("_Patch", StringComparison.Ordinal) == -1).ToList();
            bar.Maximum = dirs.Count;
            bar.Value = 0;
            foreach (var d in dirs)
            {
                using (ZipFile zip = ZipFile.Read(d))
                {
                    foreach (var del in _dels)
                    {
                        var e = zip[del.First];
                        if(e != null)
                            zip.RemoveEntry(e);
                    }
                    zip.Save();
                }
                bar.Value++;
            }
            bar.Value = 0;
            MessageBox.Show("Done");
        }
    }
}
