using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexEditor
{
    public partial class ResourcesId : Form
    {
        private List<Item> items;

        private Srv parent;

        public ResourcesId(List<Item> Items, Srv p)
        {
            items = Items;
            parent = p;
            parent.Enabled = false;
            InitializeComponent();
        }

        private void ResourcesId_Load(object sender, EventArgs e)
        {
            items.Sort((x, y) => x.ResId.CompareTo(y.ResId));
            foreach (var item in items)
            {
                string[] row = { Convert.ToString(item.ResId), item.Path + item.Name};
                resView.Items.Add(new ListViewItem(row));
            }
        }

        private void ResourcesId_FormClosing(object sender, FormClosingEventArgs e)
        {
            items.Clear();
            parent.Enabled = true;
        }

        private void resView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Right) != 0) return;
            if (resView.SelectedItems.Count == 0) return;

            ulong res = Convert.ToUInt64(resView.SelectedItems[0].Text);

            foreach (var item in items)
            {
                if (res == item.ResId)
                {
                    pathBox.Text = item.Path + item.Name;
                    return;
                }
            }
        }
    }
}
