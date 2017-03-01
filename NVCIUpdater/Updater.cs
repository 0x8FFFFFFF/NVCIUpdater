using System;
using System.IO;
using System.Windows.Forms;

namespace NVCIUpdater
{
    class Updater
    {
        public static void StartUpdate()
        {
            if (CheckAllRight())
            {
                if (Data.Auto == true && Data.SubDir != null)
                {
                    string DestinDirUp = Data.DestinDir + Data.SubDir + @"\update.txt";
                    string SourceDirUp = Data.SourceDir + Data.SubDir + @"\update.txt";
                    if (File.Exists(SourceDirUp))
                    {
                        if (!Compare.Files(SourceDirUp, DestinDirUp))
                        {
                            UpdateFiles(Data.SourceDir + "\\U00"); // обновляем общие ресурсы
                            UpdateFiles(Data.SourceDir + Data.SubDir); // обновляем заданную папку "ушек" 
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Невозможно получить доступ к файлу " + SourceDirUp + 
                                        "\nВозможно это временная проблема и уже идет работа по ее устранению. Если Вам надоело это сообщение, то сообщите об этом системному администратору.", 
                                        "NVCI Updater", 0, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    UpdateFiles(Data.SourceDir);
                }
            }            
        }

        public static bool CheckAllRight()
        {
            if (Data.SourceDir == Data.DestinDir)
            {
                MessageBox.Show("Пути к папке назначения и папке источника обнвлений не должны совпадать!", "NVCI Updater", 0, MessageBoxIcon.Error);
                return false;
            }
            if (Data.SourceDir == null || Data.DestinDir == null)
            {
                MessageBox.Show("Настройте пути к папкам. От куда и куда будем проводить обнвления?", "NVCI Updater", 0, MessageBoxIcon.Error);
                return false;
            }
            if (!Directory.Exists(Data.SourceDir))
            {
                MessageBox.Show("Папка источника обновлений не доступна!", "NVCI Updater", 0, MessageBoxIcon.Error);
                return false;
            }
            if (!Directory.Exists(Data.DestinDir))
            {
                MessageBox.Show("Папка назначения обновлений не доступна!", "NVCI Updater", 0, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static void UpdateFiles(string startdirectory)
        {          
            string[] foundDirectory = Directory.GetDirectories(startdirectory);
            string[] foundFiles = Directory.GetFiles(startdirectory);
            
            foreach (string directoryPath in foundDirectory)
            {
                try
                {
                    if (Data.StopThread) return;
                    string replacePath = directoryPath.Replace(Data.SourceDir, Data.DestinDir);

                    if (!Directory.Exists(replacePath))
                        Directory.CreateDirectory(replacePath);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
                    continue;
                }
                UpdateFiles(directoryPath + @"\"); // Recursive call.
            }

            foreach (string filePath in foundFiles)
            {
                try
                {
                    if (Data.StopThread) return;
                    string replacePath = filePath.Replace(Data.SourceDir, Data.DestinDir);

                    if (!Compare.Files(filePath, replacePath))
                    {
                        File.Copy(filePath, replacePath, true);
                        string text = "Обновлен: " + Path.GetFileName(filePath) + " ---> " + Path.GetDirectoryName(replacePath);
                        Data.ListOfFiles.Add(text);
                        Log.Record(text);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "NVCIUpdater", 0, MessageBoxIcon.Error);
                    continue;
                }
            }          
        }

    }
}
