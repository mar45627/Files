using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexEditor
{
    public partial class AddForm : Form
    {
        public string FullPath;
        public ulong ResourceId;

        public AddForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            FullPath = fileBox.Text;
            ResourceId = Convert.ToUInt64(resBox.Text);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void resBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
                e.Handled = true;
        }

        private void fileBox_TextChanged(object sender, EventArgs e)
        {
            if (fileBox.TextLength == 0 || resBox.TextLength == 0 || Path.GetExtension(fileBox.Text) != ".xdb")
                okButton.Enabled = false;
            else
                okButton.Enabled = true;
        }

        private void resBox_TextChanged(object sender, EventArgs e)
        {
            if (fileBox.TextLength == 0 || resBox.TextLength == 0)
                okButton.Enabled = false;
            else
                okButton.Enabled = true;
        }
    }
}
