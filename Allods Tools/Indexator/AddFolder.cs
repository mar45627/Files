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
    public partial class AddFolder : Form
    {
        public string FullPath;

        public AddFolder()
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
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fileBox_TextChanged(object sender, EventArgs e)
        {
            if (fileBox.TextLength == 0 || Path.GetExtension(fileBox.Text) != "")
                okButton.Enabled = false;
            else
                okButton.Enabled = true;
        }

        private void resBox_TextChanged(object sender, EventArgs e) {
            okButton.Enabled = fileBox.TextLength != 0;
        }
    }
}
