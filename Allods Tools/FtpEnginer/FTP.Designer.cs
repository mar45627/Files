namespace FtpEnginer
{
    partial class FTP
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
            this.workDirBox = new System.Windows.Forms.TextBox();
            this.OpenWork = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.WorkBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.DataSaver = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.DateChecker = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // workDirBox
            // 
            this.workDirBox.AllowDrop = true;
            this.workDirBox.Location = new System.Drawing.Point(12, 12);
            this.workDirBox.Name = "workDirBox";
            this.workDirBox.Size = new System.Drawing.Size(765, 20);
            this.workDirBox.TabIndex = 0;
            this.workDirBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.workDirBox_DragDrop);
            this.workDirBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.workDirBox_DragEnter);
            // 
            // OpenWork
            // 
            this.OpenWork.Location = new System.Drawing.Point(12, 38);
            this.OpenWork.Name = "OpenWork";
            this.OpenWork.Size = new System.Drawing.Size(120, 23);
            this.OpenWork.TabIndex = 1;
            this.OpenWork.Text = "Load";
            this.OpenWork.UseVisualStyleBackColor = true;
            this.OpenWork.Click += new System.EventHandler(this.OpenWork_Click);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(702, 38);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(11, 67);
            this.treeView1.Name = "treeView1";
            this.treeView1.PathSeparator = "/";
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(766, 255);
            this.treeView1.TabIndex = 3;
            // 
            // DataSaver
            // 
            this.DataSaver.Enabled = false;
            this.DataSaver.Location = new System.Drawing.Point(634, 328);
            this.DataSaver.Name = "DataSaver";
            this.DataSaver.Size = new System.Drawing.Size(143, 31);
            this.DataSaver.TabIndex = 4;
            this.DataSaver.Text = "Get New Date";
            this.DataSaver.UseVisualStyleBackColor = true;
            this.DataSaver.Click += new System.EventHandler(this.DataSaver_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(11, 328);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(121, 31);
            this.loadButton.TabIndex = 5;
            this.loadButton.Text = "Load Files";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // DateChecker
            // 
            this.DateChecker.Location = new System.Drawing.Point(300, 351);
            this.DateChecker.Name = "DateChecker";
            this.DateChecker.Size = new System.Drawing.Size(172, 50);
            this.DateChecker.TabIndex = 6;
            this.DateChecker.Text = "Check Dates";
            this.DateChecker.UseVisualStyleBackColor = true;
            this.DateChecker.Click += new System.EventHandler(this.DateChecker_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(333, 328);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(103, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Create reload.txt";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 421);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.DateChecker);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.DataSaver);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.OpenWork);
            this.Controls.Add(this.workDirBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FTP";
            this.Text = "FTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FTP_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workDirBox;
        private System.Windows.Forms.Button OpenWork;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog WorkBrowser;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button DataSaver;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button DateChecker;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

