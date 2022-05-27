namespace BinarySearch
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BrowseArchives = new System.Windows.Forms.Button();
            this.ArchivesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.XdbBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrowseXDB = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.LoadThread = new System.ComponentModel.BackgroundWorker();
            this.LoadArcButton = new System.Windows.Forms.Button();
            this.PakLoader = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BrowseArchives
            // 
            this.BrowseArchives.Location = new System.Drawing.Point(605, 6);
            this.BrowseArchives.Name = "BrowseArchives";
            this.BrowseArchives.Size = new System.Drawing.Size(93, 20);
            this.BrowseArchives.TabIndex = 0;
            this.BrowseArchives.Text = "Browse";
            this.BrowseArchives.UseVisualStyleBackColor = true;
            this.BrowseArchives.Click += new System.EventHandler(this.BrowseArchives_Click);
            // 
            // ArchivesBox
            // 
            this.ArchivesBox.AllowDrop = true;
            this.ArchivesBox.Location = new System.Drawing.Point(114, 6);
            this.ArchivesBox.Name = "ArchivesBox";
            this.ArchivesBox.Size = new System.Drawing.Size(485, 20);
            this.ArchivesBox.TabIndex = 1;
            this.ArchivesBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.ArchivesBox_DragDrop);
            this.ArchivesBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Archives Directory:";
            // 
            // XdbBox
            // 
            this.XdbBox.AllowDrop = true;
            this.XdbBox.Location = new System.Drawing.Point(114, 33);
            this.XdbBox.Name = "XdbBox";
            this.XdbBox.Size = new System.Drawing.Size(485, 20);
            this.XdbBox.TabIndex = 3;
            this.XdbBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.XdbBox_DragDrop);
            this.XdbBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "XDB Directory:";
            // 
            // BrowseXDB
            // 
            this.BrowseXDB.Location = new System.Drawing.Point(605, 33);
            this.BrowseXDB.Name = "BrowseXDB";
            this.BrowseXDB.Size = new System.Drawing.Size(93, 20);
            this.BrowseXDB.TabIndex = 4;
            this.BrowseXDB.Text = "Browse";
            this.BrowseXDB.UseVisualStyleBackColor = true;
            this.BrowseXDB.Click += new System.EventHandler(this.BrowseXDB_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Enabled = false;
            this.LoadButton.Location = new System.Drawing.Point(511, 162);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(190, 43);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Get Binary";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 68);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(683, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 94);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(50, 15);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Status";
            // 
            // LoadThread
            // 
            this.LoadThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadThread_DoWork);
            // 
            // LoadArcButton
            // 
            this.LoadArcButton.Location = new System.Drawing.Point(12, 162);
            this.LoadArcButton.Name = "LoadArcButton";
            this.LoadArcButton.Size = new System.Drawing.Size(209, 43);
            this.LoadArcButton.TabIndex = 9;
            this.LoadArcButton.Text = "Load Pak\'s";
            this.LoadArcButton.UseVisualStyleBackColor = true;
            this.LoadArcButton.Click += new System.EventHandler(this.LoadArcButton_Click);
            // 
            // PakLoader
            // 
            this.PakLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.PakLoader_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 211);
            this.Controls.Add(this.LoadArcButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LoadButton);
            this.Controls.Add(this.BrowseXDB);
            this.Controls.Add(this.XdbBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ArchivesBox);
            this.Controls.Add(this.BrowseArchives);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Bin In Paks";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BrowseArchives;
        private System.Windows.Forms.TextBox ArchivesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox XdbBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BrowseXDB;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label StatusLabel;
        private System.ComponentModel.BackgroundWorker LoadThread;
        private System.Windows.Forms.Button LoadArcButton;
        private System.ComponentModel.BackgroundWorker PakLoader;
    }
}

