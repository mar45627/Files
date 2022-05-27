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

namespace GameVersion
{
    public partial class TruncatorForm : Form
    {
        OpenFileDialog dlg = new OpenFileDialog();

        public TruncatorForm()
        {
            InitializeComponent();
            if (File.Exists("GameVersion.txt"))
            {
                string[] lines = File.ReadAllLines("GameVersion.txt");
                foreach (string line in lines)
                {
                    string opt = line.Remove(line.IndexOf('='));
                    if (opt == "game-version")
                    {
                        fileBox.Text = line.Substring(line.IndexOf('=') + 1);
                    }
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileBox.Text = dlg.FileName;
            }
        }

        private void fileBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.All : DragDropEffects.None;
        }

        private void fileBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            fileBox.Text = s[0];
        }

        private Game gv;
        private void readButton_Click(object sender, EventArgs e)
        {
            gv = new Game(fileBox.Text);
            gv.Read();
            //gv.ComputeMd5Checksum(fileBox.Text);
        }

        private void TruncatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("GameVersion.txt", "game-version=" + fileBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gv.Save("game2.version");
        }
    }
}
