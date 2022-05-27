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
using System.Xml.Linq;

namespace FastIndexer
{
    public partial class Form1 : Form
    {
        FolderBrowserDialog dlg = new FolderBrowserDialog();

        public Form1()
        {
            InitializeComponent();
        }

        public string ReadResId(string file)
        {
            var doc = XDocument.Load(file);
            string id = "";
            if (doc.Root != null)
            {
                var xElement = doc.Root.Element("Header");
                var element = xElement?.Element("resourceId");
                if (element != null)
                {
                    var resId = element.Value;
                    id = resId;
                }
            }
            return id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string path = dlg.SelectedPath;
                //Directory.SetCurrentDirectory(path);

                List<string> files = Directory.GetFiles(path, "*.xdb", SearchOption.AllDirectories).ToList();
                List<string> lines = new List<string>();
                foreach (var f in files)
                {
                    string file = f.Replace('\\', '/');
                    file = file.Substring(path.Length);
                    string id = ReadResId(f);
                    if (id != "")
                    {
                        lines.Add(id + "#" + file);
                    }
                }
                File.WriteAllLines("System/index.new.srv", lines);

                List<string> ori = File.ReadAllLines("System/index.bak.srv").ToList();
                ori.AddRange(lines);
                File.WriteAllLines("System/index.srv", ori);

                files.Clear();
                lines.Clear();
                ori.Clear();
            }
        }
    }
}
