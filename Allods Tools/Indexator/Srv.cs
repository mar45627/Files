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
    public partial class Srv : Form
    {
        private Item curItem;
       // private Index mainIndex;
        private Index ind;
        public string MainDirectory;
        private FolderBrowserDialog dlg = new FolderBrowserDialog();
        private string lastDir;

        private string _settings = "index.cfg";

        public Srv()
        {
            InitializeComponent();
            if (File.Exists(_settings))
            {
                string[] lines = File.ReadAllLines(_settings);
                foreach (string line in lines)
                {
                    string opt = line.Remove(line.IndexOf('='));
                    if (opt == "MainDirectory")
                    {
                        MainDirectory = line.Substring(line.IndexOf('=') + 1);
                        dlg.SelectedPath = MainDirectory;
                        lastDir = MainDirectory;
                        var lastItem = new ToolStripMenuItem(lastDir);
                        lastItem.Click += (sender, args) =>
                        {
                            ind.Root.Clear();
                            MainDirectory = dlg.SelectedPath;
                            ind.FileIndex = MainDirectory + "/index.new.srv";
                            ind.LoadProgressChanged += OnMainLoad;
                            LoadWorker.RunWorkerAsync();
                            Text = MainDirectory;
                        };
                        fileToolStripMenuItem.DropDownItems.Add(lastItem);
                    }
                }
            }
        }

        private void Srv_Load(object sender, EventArgs e)
        {
            var imageList = new ImageList();
            imageList.Images.Add("Dir", Properties.Resources.DirIcon);
            imageList.Images.Add("Xdb", Properties.Resources.XdbIcon);
            imageList.Images.Add("Back", Properties.Resources.BackIcon);
            fileList.SmallImageList = imageList;
           // mainIndex = new Index { FileIndex = MainFile };
            ind = new Index();
            Text = MainDirectory;
        }

        private void pathBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                fileList.Focus();
                var test = ind.Root.MovePath(pathBox.Text);
                if (test == null)
                {
                    pathBox.Text = ind.Current.GetPath();
                    return;
                }
                ind.Current = test;
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
                pathBox.Text = ind.Current.GetPath();
            }
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

        private void fileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0) return;
            if (fileList.SelectedItems.Count == 0) return;
            string item = fileList.SelectedItems[0].Text;
            if (item == "../")
            {
                ind.Current = ind.Current.Parent;
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }
            else
            {
                if (ind.Current.GetDir(item) == null)
                {
                    curItem = ind.Current.GetItem(item);
                    if (curItem != null)
                    {
                        itemBox.Text = ind.Current.GetPath() + "/" + curItem.Name;
                        resBox.Text = Convert.ToString(curItem.ResId);
                    }
                    return;
                }
                ind.Current = ind.Current.GetDir(item);
                fileList.Items.Clear();
                fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }
            pathBox.Text = ind.Current.GetPath();
        }

        private void Srv_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText(_settings, "MainDirectory=" + MainDirectory);
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = !ind.Root.IsEmpty();
            saveAsToolStripMenuItem.Enabled = !ind.Root.IsEmpty();
        }

        private void OnMainLoad(object sender, Progress e)
        {
            Invoke(new Action(() => { progressBar1.Maximum = e.Max; progressBar1.Value = e.Loaded; }));
            // ProgressB(e.Loaded, e.Max);
            //  progressBar1.Maximum = e.Max;
            //  progressBar1.Value = e.Loaded;
        }

        private void LoadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ind.Load();
            Invoke(new Action(() =>
            {
                fileList.Items.Clear();
                foreach (var v in ind.Root.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }));  
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ind.Root.Clear();
                MainDirectory = dlg.SelectedPath;
                ind.FileIndex = MainDirectory + "/index.new.srv";
                ind.LoadProgressChanged += OnMainLoad;
                LoadWorker.RunWorkerAsync();
            }
            Text = MainDirectory;
        }

        private void addRootItem_Click(object sender, EventArgs e)
        {
            AddForm f = new AddForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                ind.Root.AddPath(f.FullPath, f.ResourceId);
                fileList.Items.Clear();
                ind.Current = ind.Root;
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Root.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }
        }

        private void addItem_Click(object sender, EventArgs e) {
            AddForm f = new AddForm();
            if (f.ShowDialog() == DialogResult.OK) {
                ind.Current.AddPath(f.FullPath, f.ResourceId);
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList()) {
                    var w = new ListViewItem() { Text = v };
                    w.ImageKey = w.Text.LastIndexOf('.') > 0 ? "Xdb" : "Dir";
                    fileList.Items.Add(w);
                }
            }
        }

        private void addCurrent_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ind.Current.AddDirectory(f.SelectedPath);
                    fileList.Items.Clear();
                    if (ind.Current.Parent != null)
                        fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                    foreach (var v in ind.Current.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        fileList.Items.Add(w);
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
                    ind.Root.AddDirectory(f.SelectedPath);
                    fileList.Items.Clear();
                    ind.Current = ind.Root;
                    if (ind.Current.Parent != null)
                        fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                    foreach (var v in ind.Root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        fileList.Items.Add(w);
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
                    ind.Root.AddPak(f.FileName);
                    fileList.Items.Clear();
                    ind.Current = ind.Root;
                    if (ind.Current.Parent != null)
                        fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                    foreach (var v in ind.Root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        fileList.Items.Add(w);
                    }
                }
            }
        }

        private void addRootPaks_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ind.Root.AddPaks(f.SelectedPath);
                    fileList.Items.Clear();
                    ind.Current = ind.Root;
                    if (ind.Current.Parent != null)
                        fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                    foreach (var v in ind.Root.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        fileList.Items.Add(w);
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in fileList.SelectedItems.Cast<ListViewItem>().Where(item => item.Text != "../"))
            {
                ind.Current.Delete(item.Text);
                item.Remove();
            }
        }

        private void fileMenu_Opening(object sender, CancelEventArgs e)
        {
            if (fileList.SelectedItems.Count == 0)
            {
                deleteToolStripMenuItem.Enabled = false;
            }
            else
            {
                deleteToolStripMenuItem.Enabled = true;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ind.FileIndex = MainDirectory + "/index.new.srv";
            string index = MainDirectory + "/index.bak.srv";
            //mainIndex.FileIndex = Path.GetDirectoryName(MainFile) + "/index.srv";
            //List<string> mainList = mainIndex.SaveHelper();
            List<string> twoList = ind.SaveHelper();
            if (File.Exists(index))
            {
                List<string> mainFile = File.ReadAllLines(index).ToList();
                mainFile.RemoveAt(0);
                mainFile.AddRange(twoList);
                ind.Save(twoList);

                ind.FileIndex = MainDirectory + "/index.srv";
                ind.Save(mainFile);
            }
            MessageBox.Show("Done");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folder = new FolderBrowserDialog() {SelectedPath = MainDirectory})
            {
                if (folder.ShowDialog() != DialogResult.OK) return;
                ind.FileIndex = folder.SelectedPath + "/index.new.srv";
                string index = folder.SelectedPath + "/index.bak.srv";
                //mainIndex.FileIndex = Path.GetDirectoryName(MainFile) + "/index.srv";
                //List<string> mainList = mainIndex.SaveHelper();
                List<string> twoList = ind.SaveHelper();
                if (File.Exists(index))
                {
                    List<string> mainFile = File.ReadAllLines(index).ToList();
                    mainFile.RemoveAt(0);
                    mainFile.AddRange(twoList);
                    ind.Save(twoList);

                    ind.FileIndex = folder.SelectedPath + "/index.srv";
                    ind.Save(mainFile);
                }
            }
        }

        private void dupCleanerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cleaner c = new Cleaner();
            c.LoadDir(MainDirectory);
            Invoke(new Action(() => {c.SaveCleaned(MainDirectory, progressBar1);}));
        }

        private void dupNewCleanerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cleaner c = new Cleaner();
            c.LoadDir(MainDirectory);
            Invoke(new Action(() => { c.NewSaveClean(MainDirectory, progressBar1); }));
        }

        private void addFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog f = new FolderBrowserDialog() { SelectedPath = MainDirectory })
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ind.Current.AddFolder(f.SelectedPath);
                    fileList.Items.Clear();
                    if (ind.Current.Parent != null)
                        fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                    foreach (var v in ind.Current.GetChildList())
                    {
                        var w = new ListViewItem() { Text = v };
                        if (w.Text.LastIndexOf('.') > 0)
                            w.ImageKey = "Xdb";
                        else
                        {
                            w.ImageKey = "Dir";
                        }
                        fileList.Items.Add(w);
                    }
                }
            }
        }

        private void getResIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = new List<Item>();
            foreach (var dir in from ListViewItem t in fileList.SelectedItems select ind.Current.GetDir(t.Text))
            {
                dir?.GetItems(items);
            }
            if (items.Count == 0)
                return;
            ResourcesId resForm = new ResourcesId(items, this);
            resForm.Show();
        }

        private void fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void fileList_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string f = s[0];
            if (!Path.HasExtension(f))
            {
                ind.Current.AddFolder(f);
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() {Text = "../", ImageKey = "Back"});
                foreach (var v in ind.Current.GetChildList())
                {
                    var w = new ListViewItem() {Text = v};
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }
            else
            {
                ind.Current.AddItems(s.ToList());
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList())
                {
                    var w = new ListViewItem() { Text = v };
                    if (w.Text.LastIndexOf('.') > 0)
                        w.ImageKey = "Xdb";
                    else
                    {
                        w.ImageKey = "Dir";
                    }
                    fileList.Items.Add(w);
                }
            }
        }

        private void indexNullResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new AddIndex(ind.Current);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var startIndex = Convert.ToUInt64(dlg.resBox.Text);
                ind.Current.IndexAllNull(MainDirectory.Replace('\\', '/') + "/..", ref startIndex);
            }
        }

        private void indexAllResourcesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new AddIndex(ind.Current);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var startIndex = Convert.ToUInt64(dlg.resBox.Text);
                ind.Current.IndexAll(MainDirectory.Replace('\\', '/') + "/..", ref startIndex);
            }
        }

        private void generateZipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var items = new List<Item>();
            var queue = new Queue<string>();
            if (ind.Current == ind.Root) {
                ind.Root.GetItems(items);
                foreach (var item in items) {
                    var file = item.Path.Remove(0, 1) + item.Name;
                    queue.Enqueue(file);
                }
            } else {
                var path = ind.Current.Parent.GetPath();
                path = path != null ? path.Remove(0, 1) + "/" : "";
                ind.Current.GetItems(items, path);
                foreach (var item in items) {
                    var file = item.Path + item.Name;
                    queue.Enqueue(file);
                }
            }
          
            var cur = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(MainDirectory + "/../");
            var zip = new ZipForm(queue);
            zip.ShowDialog();
            Directory.SetCurrentDirectory(cur);
        }

        private void createDirectoryToolStripMenuItem_Click(object sender, EventArgs e) {
            AddFolder f = new AddFolder();
            if (f.ShowDialog() == DialogResult.OK) {
                ind.Current.AddDir(f.FullPath);
                fileList.Items.Clear();
                if (ind.Current.Parent != null)
                    fileList.Items.Add(new ListViewItem() { Text = "../", ImageKey = "Back" });
                foreach (var v in ind.Current.GetChildList()) {
                    var w = new ListViewItem() { Text = v };
                    w.ImageKey = w.Text.LastIndexOf('.') > 0 ? "Xdb" : "Dir";
                    fileList.Items.Add(w);
                }
            }
        }
    }
}
