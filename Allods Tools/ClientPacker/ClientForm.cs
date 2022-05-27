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

namespace ClientPacker
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(folderDlg.ShowDialog() == DialogResult.OK)
            {
                folderBox.Text = folderDlg.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(outDlg.ShowDialog() == DialogResult.OK)
            {
                outBox.Text = outDlg.SelectedPath;
            }
        }

        private void crBtn_Click(object sender, EventArgs e)
        {
            var folder = folderBox.Text;
            var output = outBox.Text;
            if(String.IsNullOrEmpty(output))
            {
                MessageBox.Show("Output is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if(!Directory.Exists(output))
            {
                Directory.CreateDirectory(output);
            }
            dirWorker.RunWorkerAsync();
        
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            var packer = new Options("packer.cfg").Load();
            var folder = packer["folder"];
            if (folder != null)
                folderBox.Text = folder;
            var output = packer["output"];
            if (output != null)
                outBox.Text = output;
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var packer = new Options("packer.cfg");
            packer["folder"] = folderBox.Text;
            packer["output"] = outBox.Text;
            packer.Save();
        }

        private string[] getFiles(string folder)
        {
            var files = File.ReadAllLines(folder + "/uninstall.log").Where(file => file[0] != '\\').ToList();
            files.Add("uninstall.log");
            return files.ToArray();
            //return Directory.GetFiles(String.IsNullOrEmpty(folder) ? "./" : folder, "*", SearchOption.AllDirectories);
        }

        private void dirWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var folder = folderBox.Text;
            var output = outBox.Text;
            Invoke(new Action(() => {
                statusLabel.Text = "Getting files...";
                crBtn.Enabled = false;
            }));
            var files = getFiles(String.IsNullOrEmpty(folder) ? Directory.GetCurrentDirectory() : folder);
            
            Invoke(new Action(() => {
                statusLabel.Text = "Files: 0/" + files.Length;
                statusBar.Maximum = files.Length;
            }));

            var time = dateTimePicker1.Value;

            List<string> dirs = new List<string>();

            for(int i = 0; i < files.Length; i++)
            {
                var file = files[i].Replace('\\', '/');
                if (file[0] == '.' && file[1] == '/')
                    file = file.Substring(2);
          
                var path = Path.GetDirectoryName(file);
                var full = output + "/" + path;
                if (!String.IsNullOrEmpty(path))
                {
                    if(!Directory.Exists(full))
                    {
                        Directory.CreateDirectory(full);
                    }
                    if (!dirs.Contains(full))
                    {
                        dirs.Add(full);
                    }
                }

                var fname = output + "/" + file;
                File.Copy(String.IsNullOrEmpty(folder) ? file : folder + "/" + file, fname, true);
                
                File.SetCreationTime(fname, time);
                File.SetLastAccessTime(fname, time);
                File.SetLastWriteTime(fname, time);

                Invoke(new Action(() => {
                    fileBox.Items.Add(file);
                    fileBox.SelectedIndex = fileBox.Items.Count - 1;
                    statusLabel.Text = "Files: " + i + "/" + files.Length;
                    statusBar.Value = i;
                }));
            }
            foreach(var d in dirs)
            {
                Directory.SetCreationTime(d, time);
                Directory.SetLastAccessTime(d, time);
                Directory.SetLastWriteTime(d, time);
            }
            Invoke(new Action(() => {
                statusLabel.Text = "Done!";
                statusBar.Value = 0;
                crBtn.Enabled = true;
            }));
        }
    }
}
