namespace NVCIUpdater
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.listBoxUpdate = new System.Windows.Forms.ListBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.textBoxDestinPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.labelDestinPath = new System.Windows.Forms.Label();
            this.labelSourcePath = new System.Windows.Forms.Label();
            this.buttonGetDestinPath = new System.Windows.Forms.Button();
            this.buttonGetSourcePath = new System.Windows.Forms.Button();
            this.buttonChangeShortcut = new System.Windows.Forms.Button();
            this.buttonUnchangeShortcut = new System.Windows.Forms.Button();
            this.groupBoxShortcut = new System.Windows.Forms.GroupBox();
            this.groupBoxUpdate = new System.Windows.Forms.GroupBox();
            this.groupBoxShortcut.SuspendLayout();
            this.groupBoxUpdate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(5, 31);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(210, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Запустить проверку обновлений";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(226, 31);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(210, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Остановить проверку обновлений";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // listBoxUpdate
            // 
            this.listBoxUpdate.FormattingEnabled = true;
            this.listBoxUpdate.Location = new System.Drawing.Point(6, 60);
            this.listBoxUpdate.Name = "listBoxUpdate";
            this.listBoxUpdate.Size = new System.Drawing.Size(429, 95);
            this.listBoxUpdate.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(6, 19);
            this.progressBar.MarqueeAnimationSpeed = 0;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(429, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 3;
            // 
            // backgroundWorkerUpdate
            // 
            this.backgroundWorkerUpdate.WorkerReportsProgress = true;
            this.backgroundWorkerUpdate.WorkerSupportsCancellation = true;
            this.backgroundWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdate_DoWork);
            this.backgroundWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdater_RunWorkerCompleted);
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Location = new System.Drawing.Point(40, 23);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(414, 20);
            this.textBoxSourcePath.TabIndex = 4;
            this.textBoxSourcePath.WordWrap = false;
            this.textBoxSourcePath.TextChanged += new System.EventHandler(this.textBoxSourcePath_TextChanged);
            // 
            // textBoxDestinPath
            // 
            this.textBoxDestinPath.Location = new System.Drawing.Point(40, 60);
            this.textBoxDestinPath.Name = "textBoxDestinPath";
            this.textBoxDestinPath.Size = new System.Drawing.Size(414, 20);
            this.textBoxDestinPath.TabIndex = 5;
            this.textBoxDestinPath.WordWrap = false;
            this.textBoxDestinPath.TextChanged += new System.EventHandler(this.textBoxDestinPath_TextChanged);
            // 
            // labelDestinPath
            // 
            this.labelDestinPath.AutoSize = true;
            this.labelDestinPath.Location = new System.Drawing.Point(13, 45);
            this.labelDestinPath.Name = "labelDestinPath";
            this.labelDestinPath.Size = new System.Drawing.Size(223, 13);
            this.labelDestinPath.TabIndex = 8;
            this.labelDestinPath.Text = "Путь к рабочей папке на этом компютере:";
            // 
            // labelSourcePath
            // 
            this.labelSourcePath.AutoSize = true;
            this.labelSourcePath.Location = new System.Drawing.Point(13, 7);
            this.labelSourcePath.Name = "labelSourcePath";
            this.labelSourcePath.Size = new System.Drawing.Size(213, 13);
            this.labelSourcePath.TabIndex = 9;
            this.labelSourcePath.Text = "Путь к папке с обновленными файлами:";
            // 
            // buttonGetDestinPath
            // 
            this.buttonGetDestinPath.BackgroundImage = global::NVCIUpdater.Properties.Resources.folder;
            this.buttonGetDestinPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGetDestinPath.Location = new System.Drawing.Point(13, 59);
            this.buttonGetDestinPath.Name = "buttonGetDestinPath";
            this.buttonGetDestinPath.Size = new System.Drawing.Size(26, 22);
            this.buttonGetDestinPath.TabIndex = 7;
            this.buttonGetDestinPath.UseVisualStyleBackColor = true;
            this.buttonGetDestinPath.Click += new System.EventHandler(this.buttonGetDestinPath_Click);
            // 
            // buttonGetSourcePath
            // 
            this.buttonGetSourcePath.BackgroundImage = global::NVCIUpdater.Properties.Resources.folder;
            this.buttonGetSourcePath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonGetSourcePath.Location = new System.Drawing.Point(13, 22);
            this.buttonGetSourcePath.Name = "buttonGetSourcePath";
            this.buttonGetSourcePath.Size = new System.Drawing.Size(26, 22);
            this.buttonGetSourcePath.TabIndex = 6;
            this.buttonGetSourcePath.UseVisualStyleBackColor = true;
            this.buttonGetSourcePath.Click += new System.EventHandler(this.buttonGetSourcePath_Click);
            // 
            // buttonChangeShortcut
            // 
            this.buttonChangeShortcut.Location = new System.Drawing.Point(6, 19);
            this.buttonChangeShortcut.Name = "buttonChangeShortcut";
            this.buttonChangeShortcut.Size = new System.Drawing.Size(210, 23);
            this.buttonChangeShortcut.TabIndex = 10;
            this.buttonChangeShortcut.Text = "Настроить ярлыки для обновления";
            this.buttonChangeShortcut.UseVisualStyleBackColor = true;
            this.buttonChangeShortcut.Click += new System.EventHandler(this.buttonChangeShortcut_Click);
            // 
            // buttonUnchangeShortcut
            // 
            this.buttonUnchangeShortcut.Location = new System.Drawing.Point(226, 19);
            this.buttonUnchangeShortcut.Name = "buttonUnchangeShortcut";
            this.buttonUnchangeShortcut.Size = new System.Drawing.Size(210, 23);
            this.buttonUnchangeShortcut.TabIndex = 11;
            this.buttonUnchangeShortcut.Text = "Вернуть ярлыки в обычное состояние";
            this.buttonUnchangeShortcut.UseVisualStyleBackColor = true;
            this.buttonUnchangeShortcut.Click += new System.EventHandler(this.buttonUnchangeShortcut_Click);
            // 
            // groupBoxShortcut
            // 
            this.groupBoxShortcut.Controls.Add(this.buttonChangeShortcut);
            this.groupBoxShortcut.Controls.Add(this.buttonUnchangeShortcut);
            this.groupBoxShortcut.Location = new System.Drawing.Point(13, 255);
            this.groupBoxShortcut.Name = "groupBoxShortcut";
            this.groupBoxShortcut.Size = new System.Drawing.Size(442, 48);
            this.groupBoxShortcut.TabIndex = 12;
            this.groupBoxShortcut.TabStop = false;
            this.groupBoxShortcut.Text = "Измение ярлыков:";
            // 
            // groupBoxUpdate
            // 
            this.groupBoxUpdate.Controls.Add(this.progressBar);
            this.groupBoxUpdate.Controls.Add(this.buttonStart);
            this.groupBoxUpdate.Controls.Add(this.listBoxUpdate);
            this.groupBoxUpdate.Controls.Add(this.buttonStop);
            this.groupBoxUpdate.Location = new System.Drawing.Point(13, 87);
            this.groupBoxUpdate.Name = "groupBoxUpdate";
            this.groupBoxUpdate.Size = new System.Drawing.Size(442, 162);
            this.groupBoxUpdate.TabIndex = 13;
            this.groupBoxUpdate.TabStop = false;
            this.groupBoxUpdate.Text = "Проверка обновлений:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 313);
            this.Controls.Add(this.groupBoxUpdate);
            this.Controls.Add(this.groupBoxShortcut);
            this.Controls.Add(this.labelSourcePath);
            this.Controls.Add(this.labelDestinPath);
            this.Controls.Add(this.buttonGetDestinPath);
            this.Controls.Add(this.buttonGetSourcePath);
            this.Controls.Add(this.textBoxDestinPath);
            this.Controls.Add(this.textBoxSourcePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Проверка обновлений";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBoxShortcut.ResumeLayout(false);
            this.groupBoxUpdate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ListBox listBoxUpdate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdate;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.TextBox textBoxDestinPath;
        private System.Windows.Forms.Button buttonGetSourcePath;
        private System.Windows.Forms.Button buttonGetDestinPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label labelDestinPath;
        private System.Windows.Forms.Label labelSourcePath;
        private System.Windows.Forms.Button buttonChangeShortcut;
        private System.Windows.Forms.Button buttonUnchangeShortcut;
        private System.Windows.Forms.GroupBox groupBoxShortcut;
        private System.Windows.Forms.GroupBox groupBoxUpdate;
    }
}

