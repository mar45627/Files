using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace BinarySearch
{
    class Pak
    {
        private string name;
        private ZipFile pack;

        public Pak(string pakName)
        {
            pack = File.Exists(pakName) ? ZipFile.Read(pakName) : new ZipFile();
            name = pakName;
        }

        public void Add(string fname)
        {
            ZipEntry ze = pack.AddFile(fname);
            ze.Attributes = 0;
            ze.CompressionLevel = 0;
            ze.CompressionMethod = CompressionMethod.None;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 2, 10);
        }

        public void Add(string fname, Stream s)
        {
            ZipEntry ze = pack.AddEntry(fname, s);
            ze.Attributes = 0;
            ze.CompressionLevel = 0;
            ze.CompressionMethod = CompressionMethod.None;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 2, 10);
        }

        public void Save()
        {
            pack.Save(name);
        }
    }
}
