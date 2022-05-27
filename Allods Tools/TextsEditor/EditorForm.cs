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
using Ionic.Zlib;

namespace TextsEditor
{
    public partial class EditorForm : Form
    {
        private OpenFileDialog dlg = new OpenFileDialog();

        public EditorForm()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileBox.Text = dlg.FileName;
            }
        }

        private void FileBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void FileBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            FileBox.Text = s[0];
        }

        private MemoryStream UnZLib(FileStream input)
        {
            input.Position = 0L;
            MemoryStream memoryStream = new MemoryStream();
            using (ZlibStream zlibStream = new ZlibStream((Stream)input, CompressionMode.Decompress))
            {
                byte[] buffer = new byte[16384];
                for (int count = zlibStream.Read(buffer, 0, 16384); count > 0; count = zlibStream.Read(buffer, 0, 16384))
                    memoryStream.Write(buffer, 0, count);
            }
            return memoryStream;
        }
        private void Zlib(MemoryStream input, FileStream fs)
        {
            input.Position = 0L;
            using (ZlibStream zlibStream = new ZlibStream((Stream)input, CompressionMode.Compress, CompressionLevel.Level6))
            {
                byte[] buffer = new byte[16384];
                for (int count = zlibStream.Read(buffer, 0, 16384); count > 0; count = zlibStream.Read(buffer, 0, 16384))
                    fs.Write(buffer, 0, count);
            }
            fs.Close();
        }

        private void WriteFile(string file, string content)
        {
            file = file.Remove(file.LastIndexOf(".txt", StringComparison.Ordinal) + 4);
            string fdir = file.Substring(0, file.LastIndexOf('/'));
            if (!Directory.Exists(fdir))
                Directory.CreateDirectory(fdir);

            File.WriteAllText(file, content, Encoding.BigEndianUnicode);
            //File.WriteAllBytes(file, content);
        }

        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                StatusLabel.Text = "Saving archive";
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                statusBar.Maximum = e.EntriesTotal;
                statusBar.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                statusBar.Value = 0;
                StatusLabel.Text = "Done";
            }
        }

        private void WriteTextEntries(string fout, List<string> files)
        {
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            //string fstr = "";
            //foreach (var f in files)
            //{
            //    fstr += f;
            //    fstr += '\0';
            //}
            using (BinaryWriter bw = new BinaryWriter((Stream) ms))
            {
                bw.Write(0x0);

                int size_files = files.Sum(f => 2 + f.Length);

                bw.Write(size_files + 12*files.Count + 8);
                bw.Write(0x08);
                bw.Write(files.Count);

                string tmp = "";
                //for (int i = 0; i < files.Count; i++)
                //{
                //    bw.Write(12 * files.Count + tmp.Length - 12 * i);
                //    tmp += files[i] + "\0";
                //}
                foreach (var f in files)
                {
                    bw.Write(f);
                    bw.Write('\0');
                }
                bw.Write(0x01);
                bw.Write(files.Count * 2);

                long cur_pos = 0;
                for (int i = 0; i < files.Count; i++)
                {
                    FileInfo info = new FileInfo(files[i]);
                    long size = info.Length;
                    bw.Write(size / 2);
                    bw.Write(cur_pos + 16);
                    cur_pos += size + (4 - size%4);
                }

                long size_t = 0;
                foreach (string path in files)
                    size_t += new FileInfo(path).Length;

                bw.Write(0x02);
                bw.Write(size_t);

                bw.Write(0x0);
                bw.Write(0x0);
                bw.Write(0x0);
                bw.Write(0x0);

                //foreach (string t in files)
                //{
                //    string content = File.ReadAllText(t);
                //}
                Zlib(ms, new FileStream(fout, FileMode.Create));
            }
            ms.Close();
        }

        private void ReadTextEntries(MemoryStream ms, string archive)
        {
            ZipFile zip = new ZipFile(archive) {UseZip64WhenSaving = Zip64Option.AsNecessary};
            zip.SaveProgress += SaveProgress;
            StatusLabel.Text = "Getting files";
            ms.Position = 0L;
            using (BinaryReader binaryReader = new BinaryReader((Stream)ms))
            {
                binaryReader.ReadInt32();
                int num1 = binaryReader.ReadInt32();
                binaryReader.ReadInt32();
                int num2 = binaryReader.ReadInt32();
                statusBar.Maximum = num2;
                statusBar.Value = 0;
                for (int index = 0; index < num2; ++index)
                {
                    int num3 = binaryReader.ReadInt32();
                    int count = binaryReader.ReadInt32();
                    int num4 = binaryReader.ReadInt32();
                    long position = binaryReader.BaseStream.Position;
                    binaryReader.BaseStream.Position = (long)(num3 + 12 * num4 + 16);
                    string fullPath = new string(binaryReader.ReadChars(count));
                    binaryReader.BaseStream.Position = (long)(16 + num1 + num4 * 8);
                    int num5 = binaryReader.ReadInt32();
                    int num6 = binaryReader.ReadInt32();
                    binaryReader.BaseStream.Position = (long)(16 + num1 + 8 * num2 + num6 + 8);
                    //string content = new string(Encoding.BigEndianUnicode.GetChars(binaryReader.ReadBytes(num5 * 2)));
                    zip.AddEntry(fullPath, Encoding.Unicode.GetString(binaryReader.ReadBytes(num5 * 2)), Encoding.Unicode);
                    //WriteFile(fullPath, content);
                    binaryReader.BaseStream.Position = position;
                   // test.Add(fullPath);
                   // _tree.AddItem(fullPath, content);
                    statusBar.Value = index;
                }
                statusBar.Value = 0;
            }
            zip.Save();
        }


        private void ExButton_Click(object sender, EventArgs e)
        {
           WorkThread.RunWorkerAsync();
        }

        private void ReadButton_Click(object sender, EventArgs e)
        {
            string fout = OutputBox.Text;

            //if (!Directory.Exists(fout))
            //    Directory.CreateDirectory(fout);
            string curdir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(DirBox.Text);

            List<string> list = Directory.GetFiles("./", "*.txt", SearchOption.AllDirectories).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = list[i].Remove(0, 2);
                list[i] = list[i].Replace('\\', '/');
            }

            WriteTextEntries("../" + fout, list);
            Directory.SetCurrentDirectory(curdir);
        }

        private void WorkThread_DoWork(object sender, DoWorkEventArgs e)
        {
            string arc = ArcBox.Text;
            string dir = Path.GetDirectoryName(arc);
            if (!string.IsNullOrEmpty(dir))
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
            if (File.Exists(arc))
                File.Delete(arc);
            FileStream f = new FileStream(FileBox.Text, FileMode.Open);
            ReadTextEntries(UnZLib(f), arc);
        }
    }
}
