using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace NVCIUpdater
{
    class Compare
    {
        public static bool Files(string file1, string file2)
        {
            // Determine if the same file was referenced two times.
            if (file1 == file2) return true;
            
            // Сheck existence of files.
            if (!File.Exists(file1)) return false;
            if (!File.Exists(file2)) return false;

            try
            {
                using (FileStream fs1 = File.OpenRead(file1))
                {
                    using (FileStream fs2 = File.OpenRead(file2))
                    {
                        int file1byte;
                        int file2byte;

                        // Check the file sizes. If they are not the same, the files are not the same.
                        if (fs1.Length != fs2.Length) return false;

                        // Read and compare a byte from each file until either a
                        // non-matching set of bytes is found or until the end of
                        // file1 is reached.
                        do
                        {
                            // Read one byte from each file.
                            file1byte = fs1.ReadByte();
                            file2byte = fs2.ReadByte();
                        }
                        while ((file1byte == file2byte) && (file1byte != -1));

                        // Return the success of the comparison. "file1byte" is 
                        // equal to "file2byte" at this point only if the files are 
                        // the same.
                        return ((file1byte - file2byte) == 0);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
                // исключение FileStream, возвращаем true, так как с одним из файлов что то не так и его копирование/замена не рекомендуется 
                return true; 
            }          
        }

        public static bool FilesMD5(string file1, string file2)
        {
            // Determine if the same file was referenced two times.
            if (file1 == file2) return true;

            // Сheck existence of files.
            if (!File.Exists(file1)) return false;
            if (!File.Exists(file2)) return false;

            try
            {
                using (FileStream fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read))
                    {
                        // Check the file sizes. If they are not the same, the files are not the same.
                        if (fs1.Length != fs2.Length) return false;

                        MD5 hash1 = new MD5CryptoServiceProvider();
                        BinaryReader br1 = new BinaryReader(fs1);
                        hash1.ComputeHash(br1.ReadBytes((int)fs1.Length));

                        MD5 hash2 = new MD5CryptoServiceProvider();
                        BinaryReader br2 = new BinaryReader(fs2);
                        hash2.ComputeHash(br2.ReadBytes((int)fs2.Length));

                        if (hash1.Hash == hash2.Hash)
                            return true;
                        else
                            return false;
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
                // исключение FileStream, возвращаем true, так как с одним из файлов что то не так и его копирование/замена не рекомендуется 
                return true;
            }
        }
    }
}
