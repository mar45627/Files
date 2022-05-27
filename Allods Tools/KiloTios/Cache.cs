using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KiloTios
{
    class Caches
    {
        private List<Cache> caches;
        private string fname;

        public Caches(string fname)
        {
            caches = new List<Cache>();
            this.fname = fname;
        }

        public void Add(Cache c)
        {
            caches.Add(c);
        }

        public static Caches Load(string fname)
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream(fname, FileMode.Open))
            {
                return formatter.Deserialize(fs) as Caches;
            }
        }

        public void Save()
        {
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream(fname, FileMode.Create))
            {
                formatter.Serialize(fs, this);
            }
        }
    }

    class Cache
    {
        private string folder;
        private string fname;
        private long size;
        private DateTime time;
        private byte[] md5;

        public Cache(string fname)
        {
            this.fname = fname;
            using(var stream = new FileStream(fname, FileMode.Open))
            {
                size = stream.Length;
                md5 = MD5.Create().ComputeHash(stream);
            }
            
            time = File.GetLastWriteTime(fname);
        }
    }
}
