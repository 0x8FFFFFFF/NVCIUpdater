using System;
using System.IO;
using IWshRuntimeLibrary;
using System.Windows.Forms;
using System.Linq;

namespace NVCIUpdater
{
    class Shortcut
    {
        public static void ChangeShortcutForUpdate()
        {
            try
            {
                string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop/*CommonDesktopDirectory*/); // Каталог рабочего стола юзера
                string pathCommonDesktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory); // Каталог рабочего стола общий
                string[] found1 = Directory.GetFiles(pathDesktop, "*.lnk", SearchOption.TopDirectoryOnly); // Получаем пути ко всем ярлыкам на раб.столе
                string[] found2 = Directory.GetFiles(pathCommonDesktop, "*.lnk", SearchOption.TopDirectoryOnly);      
                string[] foundlnk = found1.Union(found2).ToArray(); // объдиняем найденые ярлыки на десктопах

                int countShortcut = 0;
                foreach (string lnk in foundlnk)
                {
                    IWshShell wsh = new WshShell();
                    IWshShortcut link = (IWshShortcut)wsh.CreateShortcut(lnk); // получаем свойства ярлыка
                    
                    if (link.WorkingDirectory.StartsWith(Data.DestinDir, StringComparison.OrdinalIgnoreCase))  // проверяем, совпадает ли WorkingDirectory с рабочей папкой "ушек"
                    {
                        if (String.Compare(link.TargetPath, Data.DestinDir + @"\NVCIUpdater.exe", true) != 0) // если TargetPath еще не ссылается на NVCIUpdater, то изменяем свойства ярлыка
                        {
                            link.Arguments = (link.TargetPath + " " + link.Arguments);
                            link.TargetPath = Data.DestinDir + @"\NVCIUpdater.exe";
                            link.WorkingDirectory = Data.DestinDir;
                            link.Save();  // сохраняем сделаные изменения
                            countShortcut++;
                        }
                    }
                }
                if (countShortcut != 0)
                    MessageBox.Show(("Ярлыки, в количестве " + countShortcut + " шт. настроены."), "NVCIUpdater", 0, MessageBoxIcon.Information);
                else
                    MessageBox.Show("На рабочем столе, не найдено ярлыков, которые нуждаются в настройке.", "NVCIUpdater", 0, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
            }
                             
        }

        public static void UnchangeShortcutForUpdate()
        {
            try
            {
                string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop/*CommonDesktopDirectory*/); // Каталог рабочего стола юзера
                string pathCommonDesktop = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory); // Каталог рабочего стола общий
                string[] found1 = Directory.GetFiles(pathDesktop, "*.lnk", SearchOption.TopDirectoryOnly); // Получаем пути ко всем ярлыкам на раб.столе
                string[] found2 = Directory.GetFiles(pathCommonDesktop, "*.lnk", SearchOption.TopDirectoryOnly);
                string[] foundlnk = found1.Union(found2).ToArray(); // объдиняем найденые ярлыки на десктопах
                string pathApp = Data.DestinDir + @"\NVCIUpdater.exe";
                int countShortcut = 0;

                foreach (string lnk in foundlnk)
                {
                    IWshShell wsh = new WshShell();
                    IWshShortcut link = (IWshShortcut)wsh.CreateShortcut(lnk); // получаем свойства ярлыка
                    
                    if (link.WorkingDirectory.StartsWith(Data.DestinDir, StringComparison.OrdinalIgnoreCase))  // проверяем, совпадает ли WorkingDirectory с рабочей папкой "ушек"
                    {
                        if (String.Compare(link.TargetPath, pathApp, true) == 0) // если TargetPath ссылается на NVCIUpdater, то изменяем свойства ярлыка
                        {
                            string[] arg = link.Arguments.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);                            
                            link.TargetPath = arg[0];                           
                            link.Arguments = String.Join(" ", arg, 1, arg.Length - 1);                           
                            link.WorkingDirectory = Data.DestinDir;
                            link.Save();  // сохраняем сделаные изменения
                            countShortcut++;
                        }
                    }
                }
                if (countShortcut != 0)
                    MessageBox.Show(("Ярлыки, в количестве " + countShortcut + " шт. изменены в стандартное состояние."), "NVCIUpdater", 0, MessageBoxIcon.Information);
                else
                    MessageBox.Show("На рабочем столе, не найдено ярлыков, которые нужно вернуть в стандартное состояние.", "NVCIUpdater", 0, MessageBoxIcon.Information);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
            }
        }
    }
}
