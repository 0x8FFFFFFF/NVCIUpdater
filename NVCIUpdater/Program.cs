using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace NVCIUpdater
{
    static class Data // глобальный статический класс для взаимодействия с потоками
    {
        public static string SourceDir { get; set; }
        public static string DestinDir { get; set; }
        public static string SubDir { get; set; }
        public static string PathRunAppAfterUpdate { get; set; }
        public static string ArgsRunAppAfterUpdate { get; set; }

        public static bool Auto = false;
        public static bool StopThread = false;
        public static List<string> ListOfFiles = new List<string>();
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {            
            Settings.Load(); // загружаем настройки из файла, если его нет или он поврежден, то создаем файл заново

            if (args.Length != 0) // проверяем наличие переданных параметров
            {
                // пример параметра: C:\NVCI\U94\EXE\U94A0000.exe *c: c: \NVCI\U94 \org \ceh U94GOLOV.pnl ORG=1 ceh=1
                if (args[0].StartsWith(@"C:\NVCI\") && args[1].StartsWith("*c:") && args[2].StartsWith("c:")) // проверяем параметры на приблизительное соответсвие здравому смыслу :)
                {
                    Data.Auto = true; // если есть параметры, то запуск обновления в автоматическом режиме

                    // формируем пути к папкам на основе переданых параметров
                    string[] WordsOfArgs = args[0].Split(new char[] {'\\'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string word in WordsOfArgs)
                    {
                        if (word.StartsWith("U"))
                        {
                            // если есть слеш в конце строки, то удаляем его
                            if (Data.SourceDir.EndsWith("\\")) Data.SourceDir = Data.SourceDir.TrimEnd(new char[] { '\\' });
                            if (Data.DestinDir.EndsWith("\\")) Data.DestinDir = Data.DestinDir.TrimEnd(new char[] { '\\' });

                            // формируем имя папки конкретной "ушки"
                            Data.SubDir += ("\\" + word);
                            break;
                        }
                    }

                    Data.PathRunAppAfterUpdate = args[0];
                    for (int i = 1; i < args.Length; i++)
                    {
                         Data.ArgsRunAppAfterUpdate = String.Format("{0} {1} ", Data.ArgsRunAppAfterUpdate, args[i]);
                    }                    
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Data.Auto)
                Application.Run(new FormAuto()); // если получен параметр запуска -auto запускаем минимализированую форму
            else
                Application.Run(new FormMain()); // если не получен параметр запуска -auto запускаем основную форму
        }
    }
}
