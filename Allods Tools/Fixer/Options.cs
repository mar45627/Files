using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fixer
{
    class Options
    {
        private string fname;
        private Dictionary<string, string> options = new Dictionary<string, string>();

        public Options(string fname)
        {
            this.fname = fname;
        }

        public Options Load()
        {
            options = new Dictionary<string, string>();
            if (!File.Exists(fname))
                return this;
            var lines = File.ReadAllLines(fname);
            foreach(var l in lines)
            {
                var pos = l.IndexOf("=");
                var key = l.Substring(0, pos);
                var value = l.Substring(pos + 1);
                options.Add(key, value);
            }
            return this;
        }

        public Options Save()
        {
            var lines = new List<string>();
            foreach(var item in options)
            {
                lines.Add(item.Key + "=" + item.Value);
            }
            if (lines.Count != 0)
                File.WriteAllLines(fname, lines);
            return this;
        }

        public string this[string key]
        {
            get
            {
                if (!options.ContainsKey(key))
                    return null;
                return options[key];
            }
            set
            {
                options.Add(key, value);
            }
        }

    }
}
