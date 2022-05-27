using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;

namespace IndexEditor
{
    public class EntriesArgs
    {
        public int UpdEntries;
        public int MaxEntries;
        public string Stage;

        public EntriesArgs(int now, int max, string stage)
        {
            UpdEntries = now;
            MaxEntries = max;
            Stage = stage;
        }
    }

    class Zip
    {
        public delegate void FileHandler(object sender, EntriesArgs e);
        public event FileHandler EntriesCount;

        private void OnTick(int entries, int max, string stage)
        {
            EntriesCount?.Invoke(this, new EntriesArgs(entries, max, stage));
        }

        private long len = 0;
        private ZipFile zip;
        public string SaveFolder = "";
        private string MainFolder;

        public bool DelWhenSave = false;

        private int step = 0;

        public Zip(string mFolder, string arcName, int packStep, string saveFolder = "")
        {
            step = packStep;

            MainFolder = Path.GetDirectoryName(mFolder);
            SaveFolder = saveFolder.Replace('\\', '/');
            if (!File.Exists(SaveFolder + arcName))
                zip = new ZipFile(SaveFolder + arcName);
            else
                zip = ZipFile.Read(SaveFolder + arcName);
            //zip.UseZip64WhenSaving = Zip64Option.AsNecessary;

            zip.SaveProgress += (sender, e) =>
            {
                OnTick(e.EntriesSaved, e.EntriesTotal, "Saving");
            };
        }

        public void UpdateEntry(string file, string directory)
        {
            ZipEntry ze = zip.UpdateFile(file, directory);

            ze.Attributes = 0;
            switch (step)
            {
                case 0:
                    ze.CompressionLevel = 0;
                    break;
                case 1:
                    ze.CompressionLevel = CompressionLevel.Level1;
                    break;
                case 2:
                    ze.CompressionLevel = CompressionLevel.Level2;
                    break;
                case 3:
                    ze.CompressionLevel = CompressionLevel.Level3;
                    break;
                case 4:
                    ze.CompressionLevel = CompressionLevel.Level4;
                    break;
                case 5:
                    ze.CompressionLevel = CompressionLevel.Level5;
                    break;
                case 6:
                    ze.CompressionLevel = CompressionLevel.Level6;
                    break;
                case 7:
                    ze.CompressionLevel = CompressionLevel.Level7;
                    break;
                case 8:
                    ze.CompressionLevel = CompressionLevel.Level8;
                    break;
                case 9:
                    ze.CompressionLevel = CompressionLevel.Level9;
                    break;
            }
            ze.CompressionMethod = ze.CompressionLevel == 0 ? CompressionMethod.None : CompressionMethod.Deflate;

            ze.AccessedTime = DateTime.FromFileTime(0);
            ze.CreationTime = DateTime.FromFileTime(0);
            ze.ModifiedTime = new DateTime(2009, 10, 1, 21, 0, 20, DateTimeKind.Utc);
        }

        public void Save(Queue<string> files, long size = Int64.MaxValue)
        {
            int max = files.Count;
            int count = 0;
            List<string> delList = new List<string>();
            while (len < size && files.Any())
            {
                string file = files.Dequeue();
                len += File.ReadAllBytes(file).Length;
                UpdateEntry(file, Path.GetDirectoryName(file).Replace(MainFolder, ""));
                count++;
                if (DelWhenSave)
                    delList.Add(file);
                OnTick(count, max, "Loading");
            }
            OnTick(0, max, "Saving");
            zip.Save();
            count = 0;
            foreach (var del in delList)
            {
                File.Delete(del);
                count++;
                OnTick(count, delList.Count, "Deleting");
            }
            delList.Clear();
        }
    }
}
