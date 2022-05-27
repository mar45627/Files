using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;

namespace BinarySearch
{
    public class ZipPak
    {
        private long maxSize = 100*1024*1024;

        private ZipFile pak;
        private List<MemoryStream> streams = new List<MemoryStream>();
        private bool isSave;

        public ZipPak(string fname)
        {
            pak = new ZipFile(fname);
        }

        public bool isOverload
        {
            get
            {
                long len = streams.Sum(s => s.Length);
                return (len > maxSize);
            }
        }

        public bool AddEntry(ZipEntry e)
        {
            if (isOverload)
            {
                return false;
            }
            MemoryStream ms = new MemoryStream();
            e.Extract(ms);
            ms.Seek(0, SeekOrigin.Begin);
            ZipEntry ze = pak.UpdateEntry(e.FileName, ms);
            ze.Attributes = 0;
            ze.CompressionLevel = 0;
            ze.CompressionMethod = CompressionMethod.None;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 2, 10);
            streams.Add(ms);
            return true;
        }

        public void Add(string fname)
        {
            ZipEntry ze = pak.AddFile(fname);
            ze.Attributes = 0;
            ze.CompressionLevel = 0;
            ze.CompressionMethod = CompressionMethod.None;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 2, 10);
        }

        public void Add(string fname, Stream s)
        {
            ZipEntry ze = pak.AddEntry(fname, s);
            ze.Attributes = 0;
            ze.CompressionLevel = 0;
            ze.CompressionMethod = CompressionMethod.None;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 2, 10);
        }

        public void Save()
        {
            if(isSave) return;
            pak.Save();
            for (int i = 0; i < streams.Count; i++)
            {
                streams[i].Dispose();
            }
            streams.Clear();
            pak = null;
            GC.Collect();
            isSave = true;
        }
    }
}
