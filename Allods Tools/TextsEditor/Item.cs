using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextsEditor
{
    class Dir
    {
        public Dir parent;

        private List<Dir> dirs = new List<Dir>();
        private List<Item> items = new List<Item>(); 

        public string name;

        public void FillList(ListView w)
        {
            w.Items.Clear();
            foreach (Dir d in dirs)
            {
                w.Items.Add(d.name);
            }
            foreach (Item d in items)
            {
                w.Items.Add(d.name);
            }
        }

        public Dir Open(ListView w, int index)
        {
            string name = w.Items[index].Text;

            foreach (Dir d in dirs)
            {
                if (d.name == name)
                {
                    d.FillList(w);
                    return d;
                }
            }
            foreach (Item d in items)
            {
                if (d.name == name)
                {
                    
                }
            }
            return null;
        }

        public Dir(string nam, Dir parent)
        {
            name = nam;
            this.parent = parent;
        }

        public Dir()
        {
            
        }

        public Dir(string path, string content)
        {
            List<string> ss = path.Split('/').ToList();
            name = ss[0];
            AddItem(ss, content);
        }

        public void AddItem(string path, string content)
        {
            List<string> ss = path.Split('/').ToList();
            AddItem(ss, content);
        }

        public void AddItem(List<string> list, string content)
        {
            if (list.Count == 0) return;
            list.RemoveAt(0);
            if (list.Count == 1)
            {
                Item item = new Item();
                item.name = list[0];
                item.content = content;
                items.Add(item);
                list.RemoveAt(0);
                return;
            }
            foreach (Dir dir in dirs)
            {
                if (dir.name == list[0])
                {
                   dir.AddItem(list, content);
                    return;
                }
            }
            Dir dr = new Dir(list[0], this);
            dr.AddItem(list, content);
            dirs.Add(dr);
        }
    }

    class Item
    {
        public string name;
        public string content;

        public void AddItem(string fullpath)
        {
            
        }
    }
}
