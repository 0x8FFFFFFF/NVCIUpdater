using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NVCIUpdater
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            textBoxSourcePath.Text = Data.SourceDir;
            textBoxDestinPath.Text = Data.DestinDir;            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!backgroundWorkerUpdate.IsBusy)
            {
                listBoxUpdate.Items.Clear();
                listBoxUpdate.Items.Add("Подождите, выполняется проверка обновлений..");
                progressBar.MarqueeAnimationSpeed = 15;
                
                backgroundWorkerUpdate.RunWorkerAsync();
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerUpdate.IsBusy)
            {
                listBoxUpdate.Items.Clear();
                Data.StopThread = true;
            }
        }

        private void buttonGetSourcePath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            String path = folderBrowserDialog.SelectedPath;
            if (!String.IsNullOrEmpty(path))
            {
                Data.SourceDir = path;
                textBoxSourcePath.Clear();
                textBoxSourcePath.AppendText(path);
                Settings.Save();
            }
        }

        private void textBoxSourcePath_TextChanged(object sender, EventArgs e)
        {
            Data.SourceDir = textBoxSourcePath.Text;
            Settings.Save();
        }

        private void buttonGetDestinPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            String path = folderBrowserDialog.SelectedPath;
            if (!String.IsNullOrEmpty(path))
            {
                Data.DestinDir = path;
                textBoxDestinPath.Clear();
                textBoxDestinPath.AppendText(path);
                Settings.Save();
            }
        }

        private void textBoxDestinPath_TextChanged(object sender, EventArgs e)
        {
            Data.DestinDir = textBoxDestinPath.Text;
            Settings.Save();
        }

        private void buttonChangeShortcut_Click(object sender, EventArgs e)
        {
            Shortcut.ChangeShortcutForUpdate();
        }

        private void buttonUnchangeShortcut_Click(object sender, EventArgs e)
        {
            Shortcut.UnchangeShortcutForUpdate();
        }

        private void backgroundWorkerUpdate_DoWork(object sender, DoWorkEventArgs e)
        {
            Updater.StartUpdate();
        }

        private void backgroundWorkerUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Data.ListOfFiles.Count > 0)
            {
                listBoxUpdate.Items.Clear();
                foreach (string str in Data.ListOfFiles)
                    listBoxUpdate.Items.Add(str);
                listBoxUpdate.Items.Add("Обновление программы завершено, приятной работы! :)");
            }
            else
            {
                if (!Data.StopThread)
                {
                    listBoxUpdate.Items.Clear();
                    listBoxUpdate.Items.Add("Для Вас нет обновлений, приятной работы! :)");
                }
            }

            Log.Сleaning(300);

            Data.ListOfFiles.Clear();
            Data.StopThread = false;
            progressBar.MarqueeAnimationSpeed = 0;
            progressBar.Refresh();
        }

    }
}
