using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexEditor
{
    public partial class AddIndex : Form
    {
        private IndexDir dir;

        public AddIndex(IndexDir dir)
        {
            this.dir = dir;
            InitializeComponent();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(resBox.Text))
                DialogResult = DialogResult.Cancel;
            else
                DialogResult = DialogResult.OK;
        }

        private void resBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void getMaxBtn_Click(object sender, EventArgs e)
        {
            ulong resId = 0;
            dir.GetMaxResId(ref resId);
            resBox.Text = Convert.ToString(resId + 1);
        }
    }
}
