using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Threading;
using System.Xml;
using Ionic.Zip;

namespace BinarySearch
{
    public partial class MainForm : Form
    {
        private readonly SynchronizationContext _syncContext;
        public MainForm()
        {
            _syncContext = SynchronizationContext.Current;
            InitializeComponent();
            if (File.Exists("Binary.txt"))
            {
                string[] lines = File.ReadAllLines("Binary.txt");
                foreach (string line in lines)
                {
                    string opt = line.Remove(line.IndexOf('='));
                    if (opt == "PacksDir")
                    {
                        ArchivesBox.Text = line.Substring(line.IndexOf('=') + 1);
                    }
                    else if (opt == "XdbDir")
                    {
                        XdbBox.Text = line.Substring(line.IndexOf('=') + 1);
                    }
                }
            }
        }

        private FolderBrowserDialog arcDir = new FolderBrowserDialog();
        private FolderBrowserDialog xdbDir = new FolderBrowserDialog();

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void ArchivesBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            ArchivesBox.Text = Path.GetDirectoryName(s[0]);
        }

        private void XdbBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            XdbBox.Text = Path.GetDirectoryName(s[0]);
        }

        private void BrowseArchives_Click(object sender, EventArgs e)
        {
            if (ArchivesBox.Text != "")
                arcDir.SelectedPath = ArchivesBox.Text;
            if (arcDir.ShowDialog() == DialogResult.OK)
            {
                ArchivesBox.Text = arcDir.SelectedPath;
            }
        }

        private void BrowseXDB_Click(object sender, EventArgs e)
        {
            if (XdbBox.Text != "")
                xdbDir.SelectedPath = XdbBox.Text;
            if (xdbDir.ShowDialog() == DialogResult.OK)
            {
                XdbBox.Text = xdbDir.SelectedPath;
            }
        }

        private List<ZipFile> paks = new List<ZipFile>();

        void InitPaks(string dir)
        {
            if (paks.Count > 0)
            {
                for (int i = 0; i < paks.Count; i++)
                {
                    paks[i] = null;
                }
                GC.Collect();
            }
            StatusLabel.Text = "Load packs";
            IEnumerable<string> list = Directory.GetFiles(dir, "*.pak", SearchOption.AllDirectories);
            progressBar1.Maximum = list.Count();
            foreach (string el in list)
            {
                paks.Add(ZipFile.Read(el));
                progressBar1.Value++;
            }
            progressBar1.Value = 0;
            StatusLabel.Text = "Done loading";
        }


        private List<string> bins = new List<string>();

        void Search()
        {
            ZipPak pak = new ZipPak("New_Pack.pak");
            int all = bins.Count;
            int ext = 0;
            int part = 0;
            foreach (ZipFile z in paks)
            {
                foreach (string t in bins)
                {
                    ZipEntry e = z[t];
                    if (e != null)
                    {
                        if (!pak.AddEntry(e))
                        {
                            pak.Save();
                            pak = new ZipPak("New_Pack.p" + part + ".pak");
                            part++;
                        }
                        //MemoryStream ms = new MemoryStream();
                        //e.Extract(ms);
                        //ms.Seek(0, SeekOrigin.Begin);
                        //zip.UpdateEntry(t, ms);
                        //e.Extract("Binary", ExtractExistingFileAction.OverwriteSilently);
                        progressBar1.Value++;
                        ext++;
                        StatusLabel.Text = "Extracted: " + ext + "/" + all + "\n"
                                           + "File: " + t;
                        // bins.RemoveAt(i);
                    }
                }
            }
            pak.Save();
            bins.Clear();
        }

        private void LoadBins(string xdb)
        {
            List<string> list = File.ReadAllLines(xdb).ToList();
            foreach (string el in list)
            {
                if (el.IndexOf(".bin", StringComparison.Ordinal) != -1)
                {
                    var str = el.Substring(el.IndexOf("href=\"", StringComparison.Ordinal) + 6);
                    str = str.Remove(str.LastIndexOf('"'));
                    str = str.Remove(0, 1);
                    bins.Add(str);
                    StatusLabel.Text = "Added: " + str;
                }
            }
        }

        void LoadFiles(string dir)
        {
            IEnumerable<string> list = Directory.GetFiles(XdbBox.Text, "*.xdb", SearchOption.AllDirectories);
            foreach (string file in list)
            {
                LoadBins(file);
            }
            progressBar1.Maximum = bins.Count;
            Search();
            progressBar1.Value = 0;
            StatusLabel.Text = "Done";
            Console.Beep();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
           LoadThread.RunWorkerAsync();
            //InitPaks(ArchivesBox.Text);
            //LoadFiles(XdbBox.Text);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string opt = "PacksDir=" + ArchivesBox.Text + Environment.NewLine;
            opt += "XdbDir=" + XdbBox.Text;

            File.WriteAllText("Binary.txt", opt);
        }

        private void LoadThread_DoWork(object sender, DoWorkEventArgs e)
        {
            //InitPaks(ArchivesBox.Text);
            LoadFiles(XdbBox.Text);
        }

        private void LoadArcButton_Click(object sender, EventArgs e)
        {
            PakLoader.RunWorkerAsync();
        }

        private void PakLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            InitPaks(ArchivesBox.Text);
            LoadArcButton.Text = "Reload Pak's";
            LoadButton.Enabled = true;
        }
    }
}
