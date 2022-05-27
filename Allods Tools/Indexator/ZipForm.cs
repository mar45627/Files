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
    public partial class ZipForm : Form
    {
        private Queue<string> files;

        public ZipForm(Queue<string> files)
        {
            this.files = files;
            InitializeComponent();
            folderBox.Text = Directory.GetCurrentDirectory();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderBox.Text = folderBrowserDialog1.SelectedPath;
            }
            DialogResult = DialogResult.OK;
        }

        private void packBtn_Click(object sender, EventArgs e)
        {
            var folder = folderBox.Text;
            var arcName = zipBox.Text;
            if(String.IsNullOrEmpty(folder)|| String.IsNullOrEmpty(arcName))
            {
                MessageBox.Show("Folder or ZipName is epmpty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            zipWorker.RunWorkerAsync();
        }

        private void zipWorker_DoWork(object sender, DoWorkEventArgs e) {
            var folder = folderBox.Text + "/";
            var arcName = zipBox.Text;
            var step = Convert.ToInt32(compLevel.Value);

            var zip = new Zip(folder, arcName, step);
            zip.EntriesCount += (s, ea) => {
                progressBar1.Invoke(new Action(() => {
                    progressBar1.Maximum = ea.MaxEntries;
                    progressBar1.Value = ea.UpdEntries;
                }));
            };
            zip.Save(files);
            MessageBox.Show("Done!");
            progressBar1.Invoke(new Action(() => {
                progressBar1.Value = 0;
            }));
        }
    }
}
