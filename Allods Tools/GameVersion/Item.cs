using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameVersion
{
    class Dir
    {
        public List<Item> Items = new List<Item>();
        public int Flag;
        public string Name;
        public int FilesCount;

        public byte[] GetCell()
        {
            FilesCount = Items.Count;
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(Flag);
                    bw.Write(Name.Length);
                    bw.Write(Name.ToCharArray());
                    bw.Write(FilesCount);
                    foreach(var i in Items)
                        bw.Write(i.GetCell());
                }

                return ms.ToArray();
            }
        }
    }

    class Item
    {
        public string FileName;
        public int FileSize;
        public byte[] Md5;
        public byte[] Hash2;
        public int Type;

        public new string GetType()
        {
            switch (Type)
            {
                case 0:
                    return "Подгружаемый";
                case 1:
                    return "Мануальный";
                case 2:
                    return "Статический";
            }
            return "Unknown";
        }

        public byte[] GetCell()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter bw = new BinaryWriter(ms))
                {
                   bw.Write(FileName.Length);
                   bw.Write(FileName.ToCharArray());
                   bw.Write(FileSize);
                   bw.Write(Md5);
                   bw.Write(Hash2);
                   bw.Write(Convert.ToByte(Type));
                }

                return ms.ToArray();
            }
        }
    }
}
