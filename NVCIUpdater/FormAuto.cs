using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace NVCIUpdater
{
    public partial class FormAuto : Form
    {
        public FormAuto()
        {
            InitializeComponent();
        }

        private void FormAuto_Load(object sender, EventArgs e)
        {
           if (!backgroundWorkerUpdateAuto.IsBusy)           
               backgroundWorkerUpdateAuto.RunWorkerAsync();           
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerUpdateAuto.IsBusy)
            {
                Data.StopThread = true;
            }
        }

        private void backgroundWorkerUpdateAuto_DoWork(object sender, DoWorkEventArgs e)
        {
            Updater.StartUpdate();
        }

        private void backgroundWorkerUpdateAuto_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log.Сleaning(300);
            if (!Data.StopThread && Data.PathRunAppAfterUpdate != null)
            {
                if (File.Exists(Data.PathRunAppAfterUpdate))
                    System.Diagnostics.Process.Start(Data.PathRunAppAfterUpdate, Data.ArgsRunAppAfterUpdate);
            }
            Application.Exit();           
        }
       
    }
}
