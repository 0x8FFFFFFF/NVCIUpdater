namespace NVCIUpdater
{
    partial class FormAuto 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAuto));
            this.buttonStop = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerUpdateAuto = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(12, 59);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(120, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Отмена";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(12, 14);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(120, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Проверка обновлений";
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::NVCIUpdater.Properties.Resources.wait;
            this.pictureBox.Location = new System.Drawing.Point(12, 34);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(120, 18);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // backgroundWorkerUpdateAuto
            // 
            this.backgroundWorkerUpdateAuto.WorkerReportsProgress = true;
            this.backgroundWorkerUpdateAuto.WorkerSupportsCancellation = true;
            this.backgroundWorkerUpdateAuto.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerUpdateAuto_DoWork);
            this.backgroundWorkerUpdateAuto.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerUpdateAuto_RunWorkerCompleted);
            // 
            // FormAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(144, 95);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label);
            this.Controls.Add(this.buttonStop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAuto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAuto";
            this.Load += new System.EventHandler(this.FormAuto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.ComponentModel.BackgroundWorker backgroundWorkerUpdateAuto;
    }
}