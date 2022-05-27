using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zlib;

namespace GameVersion
{
    class Game
    {
        private List<Item> items = new List<Item>(); 
        private List<Dir> dirs = new List<Dir>();

        private string _fname;

        public string ComputeMd5Checksum(string fname)
        {
            using (FileStream fs = File.OpenRead(fname))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                byte[] checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }

        private MemoryStream UnZLib(Stream input)
        {
            //input.Position = 0L;
            MemoryStream memoryStream = new MemoryStream();
            using (ZlibStream zlibStream = new ZlibStream(input, CompressionMode.Decompress))
            {
                byte[] buffer = new byte[16384];
                for (int count = zlibStream.Read(buffer, 0, 16384); count > 0; count = zlibStream.Read(buffer, 0, 16384))
                    memoryStream.Write(buffer, 0, count);
            }
            return memoryStream;
        }
        private MemoryStream Zlib(Stream input)
        {
            var output = new MemoryStream();
            input.Position = 0L;
            using (ZlibStream zlibStream = new ZlibStream((Stream)input, CompressionMode.Compress, CompressionLevel.BestCompression))
            {
                byte[] buffer = new byte[16384];
                for (int count = zlibStream.Read(buffer, 0, 16384); count > 0; count = zlibStream.Read(buffer, 0, 16384))
                    output.Write(buffer, 0, count);
            }
            return output;
        }

        public Game(string f)
        {
            _fname = f;
        }

        private void UnpackFiles(byte[] s)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(s, 0, s.Length);
            ms.Position = 0;
            
            using (BinaryReader br = new BinaryReader(ms))
            {
                int dirCount = br.ReadInt32();

                while (ms.Position < ms.Length)
                {
                    int dirFlag = br.ReadInt32();
                    int strSize = br.ReadInt32();
                    string dir = new string(br.ReadChars(strSize));
                    int fCountInDir = br.ReadInt32();
                    for (int i = 0; i < fCountInDir; i++)
                    {
                        int nameSize = br.ReadInt32();
                        string fname = new string(br.ReadChars(nameSize));
                        int fsize = br.ReadInt32();
                        byte[] md5 = br.ReadBytes(16);
                        byte[] hash2 = br.ReadBytes(16);
                        byte type = br.ReadByte();

                        bool isFound = false;
                        foreach (var d in dirs.Where(d => d.Name == dir))
                        {
                            d.Items.Add(new Item { FileName = fname, FileSize = fsize, Md5 = md5, Hash2 = hash2, Type = type });
                            isFound = true;
                        }
                        if(isFound) continue;
                        Dir dr = new Dir() {Name = dir, Flag = dirFlag};
                        dr.Items.Add(new Item { FileName = fname, FileSize = fsize, Md5 = md5, Hash2 = hash2, Type = type });
                        dirs.Add(dr);
                    }
                }
            }
        }

        private int unk;
        private byte[] endBytes;
        public void Read()
        {
            FileStream fs = new FileStream(_fname, FileMode.Open) {Position = 0};
            using (BinaryReader br = new BinaryReader(fs))
            {
                int dataFullSize = br.ReadInt32();
                string uVer = new string(br.ReadChars(4));
                int verNumSize = br.ReadInt32();
                string clientVersion = new string(br.ReadChars(verNumSize));
                int dataZlibSize = br.ReadInt32();
                UnpackFiles(ZlibStream.UncompressBuffer(br.ReadBytes(dataZlibSize)));
                unk = br.ReadInt32();
                endBytes = br.ReadBytes(128);
            }
        }

        private byte[] PackFiles()
        {
            MemoryStream ms = new MemoryStream();
            using (var bw = new BinaryWriter(ms))
            {
                bw.Write(dirs.Count);
                foreach (var d in dirs)
                   bw.Write(d.GetCell());
                return ZlibStream.CompressBuffer(ms.ToArray());
            }
        }

        public void Save(string fname)
        {
            FileStream fs = new FileStream(fname, FileMode.Create);
            using (var bw = new BinaryWriter(fs))
            {
                string uVer = "ver5";
                string clientVersion = "4.0.02.42";
                int verNumSize = clientVersion.Length;
                byte[] zlibData = PackFiles();
                int dataZlibSize = zlibData.Length;

               // dataFullSize = 4 + uVer.Length + clientVersion.Length + verNumSize + dataZlibSize + 128 + 4;

                bw.Write(0);
                bw.Write(uVer.ToCharArray());
                bw.Write(verNumSize);
                bw.Write(clientVersion.ToCharArray());
                bw.Write(dataZlibSize);
                bw.Write(zlibData);
                bw.Write(unk);
                bw.Write(endBytes);

                int dataFullSize = Convert.ToInt32(fs.Length);
                fs.Position = 0;
                bw.Write(dataFullSize);
            }
            fs.Close();
        }
    }
}
