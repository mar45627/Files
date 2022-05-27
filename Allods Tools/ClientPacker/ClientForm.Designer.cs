namespace ClientPacker
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.outBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.fileBox = new System.Windows.Forms.ListBox();
            this.crBtn = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.statusLabel = new System.Windows.Forms.Label();
            this.folderDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.outDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.dirWorker = new System.ComponentModel.BackgroundWorker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(336, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder:";
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(53, 6);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(277, 20);
            this.folderBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output:";
            // 
            // outBox
            // 
            this.outBox.Location = new System.Drawing.Point(53, 32);
            this.outBox.Name = "outBox";
            this.outBox.Size = new System.Drawing.Size(277, 20);
            this.outBox.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(336, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // fileBox
            // 
            this.fileBox.FormattingEnabled = true;
            this.fileBox.Location = new System.Drawing.Point(12, 85);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(399, 147);
            this.fileBox.TabIndex = 3;
            // 
            // crBtn
            // 
            this.crBtn.Location = new System.Drawing.Point(336, 269);
            this.crBtn.Name = "crBtn";
            this.crBtn.Size = new System.Drawing.Size(75, 23);
            this.crBtn.TabIndex = 4;
            this.crBtn.Text = "Create";
            this.crBtn.UseVisualStyleBackColor = true;
            this.crBtn.Click += new System.EventHandler(this.crBtn_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(12, 238);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(399, 23);
            this.statusBar.TabIndex = 5;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(12, 274);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Files: 0";
            // 
            // dirWorker
            // 
            this.dirWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.dirWorker_DoWork);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(211, 59);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2009, 10, 2, 2, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date:";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 299);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.crBtn);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.outBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.folderBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Packer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox outBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox fileBox;
        private System.Windows.Forms.Button crBtn;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.FolderBrowserDialog folderDlg;
        private System.Windows.Forms.FolderBrowserDialog outDlg;
        private System.ComponentModel.BackgroundWorker dirWorker;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
    }
}

