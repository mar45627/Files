using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpEnginer
{
    public partial class FTP : Form
    {
        List<Dir> dirs = new List<Dir>();
        private string CurDir = Directory.GetCurrentDirectory();

        public FTP()
        {
            InitializeComponent();
            if (File.Exists("path.cfg"))
            {
               workDirBox.Text = File.ReadAllText("path.cfg");
            }
        }

        private void workDirBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            workDirBox.Text = Path.GetDirectoryName(s[0]);
        }

        private void workDirBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (WorkBrowser.ShowDialog() == DialogResult.OK)
            {
                workDirBox.Text = WorkBrowser.SelectedPath;
            }
        }

        private void OpenWork_Click(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(workDirBox.Text);

            if (File.Exists("ftp.cfg"))
            {
                var files = File.ReadAllLines("ftp.cfg").ToList();
                foreach (TreeNode t in files.Select(f => new TreeNode(f) { Checked = true }))
                {
                    treeView1.Nodes.Add(t);
                }
                return;
            }

            List<string> dirs = Directory.GetDirectories("./").ToList();

            foreach (var d in dirs)
            {
                var t = d.Remove(0, 2);
                treeView1.Nodes.Add(t);
            }
        }

        private void DataSaver_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            foreach (var d in dirs)
            {
                d.Save(list, d.Name);
            }
            File.WriteAllLines("lines.txt", list);
            list.Clear();
            DataSaver.Enabled = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            foreach (TreeNode d in treeView1.Nodes)
            {
                if (d.Checked)
                {
                    Dir t = new Dir(d.Name);
                    t.Load("./");
                    dirs.Add(t);
                }
            }
            DataSaver.Enabled = true;
        }

        private void DateChecker_Click(object sender, EventArgs e)
        {
            foreach (var d in dirs)
            {
                d.Refresh();
            }

            List<string> files = File.ReadAllLines("lines.txt").ToList();
            List<string> output = new List<string>();
            foreach (var d in dirs)
            {
                d.CheckDates(files, output);
            }
            File.WriteAllLines("test.txt", output);

            //====================================
            List<string> list = new List<string>();
            foreach (var d in dirs)
            {
                d.Save(list, d.Name);
            }
            File.WriteAllLines("lines.txt", list);
            list.Clear();
            DataSaver.Enabled = false;
        }

        private void FTP_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (TreeNode t in treeView1.Nodes)
            {
                if(t.Checked) continue;
                var test = new List<string>();
                test.Add(t.Name);
                File.WriteAllLines("ftp.cfg", test);
                test.Clear();
            }
            Directory.SetCurrentDirectory(CurDir);
            File.WriteAllText("path.cfg", workDirBox.Text);
        }
    }
}
