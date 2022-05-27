namespace BinaryPacker
{
    partial class MainPacker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPacker));
            this.FolderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HiBox = new System.Windows.Forms.TextBox();
            this.BinBox = new System.Windows.Forms.TextBox();
            this.PackButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PackThread = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // FolderBox
            // 
            this.FolderBox.Location = new System.Drawing.Point(57, 12);
            this.FolderBox.Name = "FolderBox";
            this.FolderBox.Size = new System.Drawing.Size(613, 20);
            this.FolderBox.TabIndex = 0;
            this.FolderBox.Text = "Binary";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(678, 10);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "HiRes:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Bin:";
            // 
            // HiBox
            // 
            this.HiBox.Location = new System.Drawing.Point(57, 38);
            this.HiBox.Name = "HiBox";
            this.HiBox.Size = new System.Drawing.Size(696, 20);
            this.HiBox.TabIndex = 4;
            this.HiBox.Text = "New*.HiRes.pak";
            // 
            // BinBox
            // 
            this.BinBox.Location = new System.Drawing.Point(57, 62);
            this.BinBox.Name = "BinBox";
            this.BinBox.Size = new System.Drawing.Size(696, 20);
            this.BinBox.TabIndex = 4;
            this.BinBox.Text = "New*.pak";
            // 
            // PackButton
            // 
            this.PackButton.Location = new System.Drawing.Point(624, 88);
            this.PackButton.Name = "PackButton";
            this.PackButton.Size = new System.Drawing.Size(129, 40);
            this.PackButton.TabIndex = 6;
            this.PackButton.Text = "Pack";
            this.PackButton.UseVisualStyleBackColor = true;
            this.PackButton.Click += new System.EventHandler(this.PackButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 88);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(606, 40);
            this.progressBar1.TabIndex = 7;
            // 
            // PackThread
            // 
            this.PackThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PackThread_DoWork);
            // 
            // MainPacker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 140);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.PackButton);
            this.Controls.Add(this.BinBox);
            this.Controls.Add(this.HiBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FolderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainPacker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BinaryPacker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainPacker_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FolderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox HiBox;
        private System.Windows.Forms.TextBox BinBox;
        private System.Windows.Forms.Button PackButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker PackThread;
    }
}

