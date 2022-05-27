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

namespace IndexEditor
{
    public partial class IndexForm : Form
    {
        private Item curItem;
        private IndexDir root, cur;
        private Index ind;
        private string _settings = "Index.cfg";
        private string MainDirectory;
        private FolderBrowserDialog dlg = new FolderBrowserDialog() {SelectedPath = Directory.GetCurrentDirectory()};

        public IndexForm()
        {
            InitializeComponent();
            if (File.Exists(_settings))
            {
                string[] lines = File.ReadAllLines(_settings);
                foreach (string line in lines)
                {
                    string opt = line.Remove(line.IndexOf('='));
                    if (opt == "WorkDir")
                    {
                        MainDirectory = line.Substring(line.IndexOf('=') + 1);
                        dlg.SelectedPath = MainDirectory;
                    }
                }
            }
        }

        private void IndexForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(_settings, "WorkDir=" + MainDirectory);
        }

        private void IndexForm_Load(object sender, EventArgs e)
        {
            var imageList = new ImageList();
            imageList.Images.Add("Dir", Properties.Resources.DirIcon);
            imageList.Images.Add("Xdb", Properties.Resources.XdbIcon);
            imageList.Images.Add("Back", Properties.Resources.BackIcon);
            filesView.SmallImageList = imageList;
            ind = new Index() { Directory = MainDirectory };
            cur = root = ind.AllDirs;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in filesView.SelectedItems.Cast<ListViewItem>().Where(item => item.Text != "../"))
            {
                cur.Delete(item.Text);
                item.Remove();
            }
        }

        private void fileMenu_Opening(object sender, CancelEventArgs e)
        {
            if (filesView.SelectedItems.Count == 0)
            {
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void pathBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filesView.Focus();
                var test = root.MovePath(pathBox.Text);
                if (test == null)
                {
                    pathBox.Text = cur.GetPath();
                    return;
                }
                cur = test;
                filesView.Items.Clear();
                if (cur.Parent != null)
                    filesView.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in cur.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    filesView.Items.Add(w);
                }
                pathBox.Text = cur.GetPath();
            }
        }

        private void addRootItem_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                root.AddPath(f.FullPath, f.ResourceId);
                filesView.Items.Clear();
                foreach (var v in root.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    filesView.Items.Add(w);
                }
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                cur.AddPath(f.FullPath, f.ResourceId);
                filesView.Items.Clear();
                foreach (var v in cur.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    filesView.Items.Add(w);
                }
            }
        }

        private void addCurrent_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    cur.AddDirectory(f.SelectedPath);
                    filesView.Items.Clear();
                    foreach (var v in cur.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        filesView.Items.Add(w);
                    }
                }
            }
        }

        private void addRoot_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    root.AddDirectory(f.SelectedPath);
                    filesView.Items.Clear();
                    foreach (var v in root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        filesView.Items.Add(w);
                    }
                }
            }
        }

        private void addRootPak_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog f = new OpenFileDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    cur.AddPak(f.FileName);
                    filesView.Items.Clear();
                    foreach (var v in root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        filesView.Items.Add(w);
                    }
                }
            }
        }

        private void addRootPaks_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() {SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    root.AddPaks(f.SelectedPath);
                    filesView.Items.Clear();
                    foreach (var v in root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        filesView.Items.Add(w);
                    }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MainDirectory = dlg.SelectedPath;
            }
            if (ind == null)
            {
                ind = new Index() { Directory = MainDirectory };
                ind.Load();
                cur = root = ind.AllDirs;
            }
            else
            {
                ind.Directory = MainDirectory;
                ind.Load();
                cur = root = ind.AllDirs;
            }

            filesView.Items.Clear();
            foreach (var v in root.GetChildList())
            {
                var w = new ListViewItem() { Text = v };
                if (w.Text.LastIndexOf('.') > 0)
                    w.ImageKey = "Xdb";
                else
                {
                    w.ImageKey = "Dir";
                }
                filesView.Items.Add(w);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!root.IsEmpty())
                ind.Save();
            MessageBox.Show("Done");
        }

        private void directoryToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = !root.IsEmpty();
        }

        private void resBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && curItem != null)
            {
                curItem.ResId = Convert.ToUInt64(resBox.Text);
            }
        }

        private void resBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void filesView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0) return;
            if (filesView.SelectedItems.Count == 0) return;
            string item = filesView.SelectedItems[0].Text;
            if (item == "../")
            {
                cur = cur.Parent;
                filesView.Items.Clear();
                if(cur.Parent != null)
                    filesView.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back"});
                foreach (var v in cur.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    filesView.Items.Add(w);
                }
            }
            else
            {
                if (cur.GetDir(item) == null)
                {
                    curItem = cur.GetItem(item);
                    if (curItem != null)
                    {
                        itemBox.Text = cur.GetPath() + "/" + curItem.Name;
                        resBox.Text = Convert.ToString(curItem.ResId);
                    }
                    return;
                }
                cur = cur.GetDir(item);
                filesView.Items.Clear();
                filesView.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in cur.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    filesView.Items.Add(w);
                }
            }
            pathBox.Text = cur.GetPath();
        }
    }
}
