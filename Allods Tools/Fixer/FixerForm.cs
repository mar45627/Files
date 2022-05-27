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
using System.Xml;
using System.Xml.Linq;

namespace Fixer
{
    public partial class FixerForm : Form
    {
        public FixerForm()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if(mainDlg.ShowDialog() == DialogResult.OK)
            {
                folderBox.Text = mainDlg.SelectedPath;
            }
        }

        public static string DetectEncoding(String fileName, out String contents)
        {
            var doc = XDocument.Load(fileName);
            contents = "123";
            return doc.Declaration.Encoding.ToString();
            // open the file with the stream-reader:
            //using (StreamReader reader = new StreamReader(fileName, true))
            //{
            //    // read the contents of the file into a string
            //    contents = reader.ReadToEnd();

            //    // return the encoding.
            //   // return reader.CurrentEncoding;
            //}
        }
        
        public void Rewrite(string fname)
        {
            var doc = XDocument.Load(fname);
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = new ASCIIEncoding();
            settings.Indent = true;
            settings.IndentChars = "    ";
            settings.OmitXmlDeclaration = true;
            StringWriter sw = new StringWriter();
            using (var writer = XmlWriter.Create(sw, settings))
            {
                doc.Save(writer);
            }
            File.WriteAllText(fname, "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>\n" + sw.ToString());
        }

        public void SetDate(string fname, DateTime time)
        {
            var path = Path.GetDirectoryName(fname);
            if (!String.IsNullOrEmpty(path))
            {
                Directory.SetCreationTime(path, time);
                Directory.SetLastAccessTime(path, time);
                Directory.SetLastWriteTime(path, time);
            }
            File.SetCreationTime(fname, time);
            File.SetLastAccessTime(fname, time);
            File.SetLastWriteTime(fname, time);
        }

        private void fixBtn_Click(object sender, EventArgs e)
        {
            var folder = folderBox.Text.Replace('\\', '/');
            if (String.IsNullOrEmpty(folder))
                folder = Directory.GetCurrentDirectory().Replace('\\', '/');
            var files = Directory.GetFiles(folder, "*.xdb", SearchOption.AllDirectories);
            if(rBox.Checked)
            {
                var reload = new List<string>();
                if(edRadio.Checked)
                    foreach (var f in files)
                    {
                        reload.Add("rreload \"" + f.Remove(0, folder.Length) + "\"");
                        Rewrite(f);
                        SetDate(f, filesTime.Value);
                    }
                else if(eRadio.Checked)
                    foreach (var f in files)
                    {
                        reload.Add("rreload \"" + f.Remove(0, folder.Length) + "\"");
                        Rewrite(f);
                    }
                else
                    foreach (var f in files)
                    {
                        reload.Add("rreload \"" + f.Remove(0, folder.Length) + "\"");
                        SetDate(f, filesTime.Value);
                    }
                var rFolder = reloadFBox.Text;
                if(String.IsNullOrEmpty(rFolder))
                    rFolder = Directory.GetCurrentDirectory().Replace('\\', '/');
                File.WriteAllLines(rFolder + "/rreload.txt", reload);
            }
            else
            {
                if (edRadio.Checked)
                    foreach (var f in files)
                    {
                        Rewrite(f);
                        SetDate(f, filesTime.Value);
                    }
                else if (eRadio.Checked)
                    foreach (var f in files)
                    {
                        Rewrite(f);
                    }
                else
                    foreach (var f in files)
                    {
                        SetDate(f, filesTime.Value);
                    }
            }
            MessageBox.Show("Done!");
        }

        private void FixerForm_Load(object sender, EventArgs e)
        {
            var opt = new Options("fixer.cfg").Load();
            var folder = opt["folder"];
            if (!String.IsNullOrEmpty(folder))
                folderBox.Text = folder;

            var reload = opt["reload"];
            if (!String.IsNullOrEmpty(reload))
            {
                rBox.Checked = Convert.ToBoolean(reload);
            } 
            reloadFBox.Enabled = rBox.Checked;
            browseRBtn.Enabled = rBox.Checked;
            var rFolder = opt["reloadFolder"];
            if (!String.IsNullOrEmpty(rFolder))
            {
                reloadFBox.Text = rFolder;
            }
            filesTime.Value = DateTime.Now;
            var type = opt["type"];
            switch(type)
            {
                default:
                    edRadio.Checked = true;
                    break;
                case "ed":
                    edRadio.Checked = true;
                    break;
                case "e":
                    eRadio.Checked = true;
                    break;
                case "d":
                    dRadio.Checked = true;
                    break;
            }
        }

        private void FixerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var opt = new Options("fixer.cfg");
            opt["folder"] = folderBox.Text;
            opt["reload"] = rBox.Checked.ToString();
            opt["reloadFolder"] = reloadFBox.Text;
            if (edRadio.Checked)
                opt["type"] = "ed";
            else if (eRadio.Checked)
                opt["type"] = "e";
            else
                opt["type"] = "d";
            opt.Save();
        }

        private void browseRBtn_Click(object sender, EventArgs e)
        {
            if(reloadDlg.ShowDialog() == DialogResult.OK)
            {
                reloadFBox.Text = reloadDlg.SelectedPath;
            }
        }

        private void rBox_CheckedChanged(object sender, EventArgs e)
        {
            reloadFBox.Enabled = rBox.Checked;
            browseRBtn.Enabled = rBox.Checked;
        }
    }
}
