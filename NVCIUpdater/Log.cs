using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NVCIUpdater
{
    class Log
    {
        static string logFileName = Application.StartupPath + @"\log.txt";
        public static void Record(string strlog) // делаем запись в лог файл
        {
            object obj = new object();
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter(logFileName, true))
                {
                    writer.WriteLine(String.Format("{0} {1}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss "), strlog));
                    writer.Flush();
                }
            }
        }

        public static void Сleaning(int maxLinesInLog) // очищаем лог от старых записей, если количество записей превысило maxLinesInLog
        {
            if (File.Exists(logFileName))
            {
                // метод с LINQ, не использовать с большими файлами!
                object obj = new object();
                lock (obj)
                {
                    string[] lines = File.ReadAllLines(logFileName);
                    int n = lines.Length - maxLinesInLog;
                    if (n > 0)
                        File.WriteAllLines(logFileName, lines.Skip(n), System.Text.Encoding.UTF8);
                }
            }
        }

    }
}
