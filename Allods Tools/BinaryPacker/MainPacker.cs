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
using Ionic.Zip;

namespace BinaryPacker
{
    public partial class MainPacker : Form
    {
        private FolderBrowserDialog dir = new FolderBrowserDialog();

        public MainPacker()
        {
            InitializeComponent();
            if (File.Exists("Packer.txt"))
            {
                string[] lines = File.ReadAllLines("Packer.txt");
                foreach (string line in lines)
                {
                    string opt = line.Remove(line.IndexOf('='));
                    if (opt == "Folder")
                    {
                        FolderBox.Text = line.Substring(line.IndexOf('=') + 1);
                    }
                }
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (FolderBox.Text != "") dir.SelectedPath = FolderBox.Text;
            if (dir.ShowDialog() == DialogResult.OK)
            {
                FolderBox.Text = dir.SelectedPath;
            }
        }

        public void Zipping(IEnumerable<string> list, string path, string fname)
        {
            string archive = fname;
            string Main = path.Substring(path.LastIndexOf('\\') + 1);
        //    string archive = textBox2.Text;
        //    DirectoryInfo dir = new DirectoryInfo(textBox1.Text);

          //  string path = Path.GetDirectoryName(textBox1.Text) + "\\";
         //   string extens = ExtBox.Text;

            progressBar1.Maximum = list.Count() + 1;

            if (!File.Exists(archive))
                using (ZipFile zip1 = new ZipFile())
                {
                    foreach (string item in list)
                    {
                        var directoryName = Path.GetDirectoryName(item);
                        if (directoryName != null)
                        {
                            string directory = directoryName.Replace(path, "");
                            ZipEntry ze = zip1.UpdateFile(item, Main + directory);
   
                            ze.Attributes = 0;
                            ze.CompressionLevel = 0;
                            ze.CompressionMethod = CompressionMethod.None;

                            ze.AccessedTime = DateTime.FromFileTime(0);
                            ze.CreationTime = DateTime.FromFileTime(0);
                            ze.ModifiedTime = new DateTime(2009, 2, 10);
                        }

                        progressBar1.Value++;
                    }

                    zip1.Save(archive);
                }
            else
                using (ZipFile zip1 = ZipFile.Read(archive))
                {
                    foreach (string item in list)
                    {
                        var directoryName = Path.GetDirectoryName(item);
                        if (directoryName != null)
                        {
                            string directory = directoryName.Replace(path, "");
                            ZipEntry ze = zip1.UpdateFile(item, Main + directory);

                            ze.Attributes = 0;
                            ze.CompressionLevel = 0;
                            ze.CompressionMethod = CompressionMethod.None;

                            ze.AccessedTime = DateTime.FromFileTime(0);
                            ze.CreationTime = DateTime.FromFileTime(0);
                            ze.ModifiedTime = new DateTime(2009, 2, 10);
                        }

                        progressBar1.Value++;
                    }

                    zip1.Save(archive);
                }
            progressBar1.Value = 0;
        }

        private void PackBin(string DirName)
        {
            string dir = DirName.Substring(DirName.LastIndexOf('\\') + 1);

            string mask = HiBox.Text;
            int pos = mask.IndexOf('*');
            mask = mask.Remove(pos, 1);
            string arc = mask.Insert(pos, dir);

            IEnumerable<string> list = Directory.GetFiles(DirName, "*.bin", SearchOption.AllDirectories);
            List<string> bins = list.Where(f => f.IndexOf(".hi", StringComparison.Ordinal) == -1).ToList();

            if(bins.Count != 0)
            Zipping(bins, DirName, arc);
        }

        private void PackHi(string DirName)
        {
            string dir = DirName.Substring(DirName.LastIndexOf('\\') + 1);

            string mask = BinBox.Text;
            int pos = mask.IndexOf('*');
            mask = mask.Remove(pos, 1);
            string arc = mask.Insert(pos, dir);

            IEnumerable<string> list = Directory.GetFiles(DirName, "*.bin", SearchOption.AllDirectories);
            List<string> bins = list.Where(f => f.IndexOf(".hi", StringComparison.Ordinal) != -1).ToList();

            if (bins.Count != 0)
                Zipping(bins, DirName, arc);
        }

        private void PackButton_Click(object sender, EventArgs e)
        {
            PackThread.RunWorkerAsync();
        }

        private void PackThread_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> list = Directory.GetDirectories(FolderBox.Text).ToList();
            foreach (var s in list)
            {
                PackBin(s);
                PackHi(s);
            }
            Console.Beep();
        }

        private void MainPacker_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("Packer.txt", "Folder=" + FolderBox.Text);
        }
    }
}
