using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace NVCIUpdater
{
    class Settings
    {
        static string pathSettingXML = Application.StartupPath + @"\settings.xml";

        public static void Load() //загрузить настройки из файла.
        {
            if (File.Exists(pathSettingXML)) //проверяем, существует ли файл настроек
            {
                XmlTextReader reader = new XmlTextReader(pathSettingXML); //создает ридер
                try
                {
                    while (reader.Read()) //считываем по порядку элементы 
                    {
                        if (reader.Name == "SourcePath") //если элемент SourcePath то читаем следующий за ним элемент, если следующий элемент Text, то забираем его значение
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                Data.SourceDir = reader.Value;
                        }

                        if (reader.Name == "DestinPath") //если элемент DestinPath то читаем следующий за ним элемент, если следующий элемент Text, то забираем его значение
                        {
                            reader.Read();
                            if (reader.NodeType == XmlNodeType.Text)
                                Data.DestinDir = reader.Value;
                        }
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    reader.Close();
                    DialogResult result = MessageBox.Show("Oшибка в файле настроек " + pathSettingXML + "\nПопробовать исправить этот файл?", "NVCI Updater", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                        File.Delete(pathSettingXML);
                    //Application.Exit();
                    Environment.Exit(0);
                }
            }
            else
            {
                if (Save())
                    MessageBox.Show("Файл настроек был восстановлен, не забудьте проверить настройки программы!", "NVCI Updater", 0, MessageBoxIcon.Information);
            }
        }

        public static bool Save() //перезаписываем файл настроек (создаст новый, если файл не существует)
        {
            XmlTextWriter writer = new XmlTextWriter(pathSettingXML, Encoding.UTF8);
            try
            {
                writer.Formatting = Formatting.Indented; //используем форматирование
                writer.Indentation = 2; //количество пробелов в файле

                writer.WriteStartDocument(); //записываем заголовок
                writer.WriteStartElement("NVCIUpdaterSettings"); //основной элемент

                writer.WriteElementString("SourcePath", Data.SourceDir); //настройки
                writer.WriteElementString("DestinPath", Data.DestinDir);

                writer.WriteEndElement(); //закрываем тег NVCIUpdaterSettings
                writer.WriteEndDocument(); //закрываем все теги, если такие остались
                writer.Close();
                return true;               
            }
            catch (Exception exp)
            {
                writer.Close();
                MessageBox.Show("Не возможно сохранить файл настроек.\n" + exp.Message, "NVCI Updater", 0, MessageBoxIcon.Error);
                return false;
            }
        }        
    }
}
