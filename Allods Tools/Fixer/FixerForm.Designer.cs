namespace Fixer
{
    partial class FixerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FixerForm));
            this.folderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.fixBtn = new System.Windows.Forms.Button();
            this.mainDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.rBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reloadFBox = new System.Windows.Forms.TextBox();
            this.browseRBtn = new System.Windows.Forms.Button();
            this.reloadGroup = new System.Windows.Forms.GroupBox();
            this.reloadDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.filesTime = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.edRadio = new System.Windows.Forms.RadioButton();
            this.eRadio = new System.Windows.Forms.RadioButton();
            this.menuBox = new System.Windows.Forms.GroupBox();
            this.dRadio = new System.Windows.Forms.RadioButton();
            this.reloadGroup.SuspendLayout();
            this.menuBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(57, 10);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(410, 20);
            this.folderBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Folder:";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(473, 8);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // fixBtn
            // 
            this.fixBtn.Location = new System.Drawing.Point(386, 148);
            this.fixBtn.Name = "fixBtn";
            this.fixBtn.Size = new System.Drawing.Size(153, 32);
            this.fixBtn.TabIndex = 3;
            this.fixBtn.Text = "Fix";
            this.fixBtn.UseVisualStyleBackColor = true;
            this.fixBtn.Click += new System.EventHandler(this.fixBtn_Click);
            // 
            // rBox
            // 
            this.rBox.AutoSize = true;
            this.rBox.Location = new System.Drawing.Point(247, 66);
            this.rBox.Name = "rBox";
            this.rBox.Size = new System.Drawing.Size(109, 17);
            this.rBox.TabIndex = 5;
            this.rBox.Text = "Reload resources";
            this.rBox.UseVisualStyleBackColor = true;
            this.rBox.CheckedChanged += new System.EventHandler(this.rBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Folder:";
            // 
            // reloadFBox
            // 
            this.reloadFBox.Location = new System.Drawing.Point(51, 14);
            this.reloadFBox.Name = "reloadFBox";
            this.reloadFBox.Size = new System.Drawing.Size(395, 20);
            this.reloadFBox.TabIndex = 7;
            // 
            // browseRBtn
            // 
            this.browseRBtn.Location = new System.Drawing.Point(452, 12);
            this.browseRBtn.Name = "browseRBtn";
            this.browseRBtn.Size = new System.Drawing.Size(75, 23);
            this.browseRBtn.TabIndex = 8;
            this.browseRBtn.Text = "Browse";
            this.browseRBtn.UseVisualStyleBackColor = true;
            this.browseRBtn.Click += new System.EventHandler(this.browseRBtn_Click);
            // 
            // reloadGroup
            // 
            this.reloadGroup.Controls.Add(this.reloadFBox);
            this.reloadGroup.Controls.Add(this.browseRBtn);
            this.reloadGroup.Controls.Add(this.label3);
            this.reloadGroup.Location = new System.Drawing.Point(15, 37);
            this.reloadGroup.Name = "reloadGroup";
            this.reloadGroup.Size = new System.Drawing.Size(533, 48);
            this.reloadGroup.TabIndex = 9;
            this.reloadGroup.TabStop = false;
            this.reloadGroup.Text = "Reload";
            // 
            // filesTime
            // 
            this.filesTime.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.filesTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.filesTime.Location = new System.Drawing.Point(386, 110);
            this.filesTime.Name = "filesTime";
            this.filesTime.Size = new System.Drawing.Size(153, 20);
            this.filesTime.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Files Date:";
            // 
            // edRadio
            // 
            this.edRadio.AutoSize = true;
            this.edRadio.Location = new System.Drawing.Point(6, 19);
            this.edRadio.Name = "edRadio";
            this.edRadio.Size = new System.Drawing.Size(128, 17);
            this.edRadio.TabIndex = 12;
            this.edRadio.Text = "Encodings And Dates";
            this.edRadio.UseVisualStyleBackColor = true;
            // 
            // eRadio
            // 
            this.eRadio.AutoSize = true;
            this.eRadio.Location = new System.Drawing.Point(6, 42);
            this.eRadio.Name = "eRadio";
            this.eRadio.Size = new System.Drawing.Size(99, 17);
            this.eRadio.TabIndex = 13;
            this.eRadio.Text = "Only Encodings";
            this.eRadio.UseVisualStyleBackColor = true;
            // 
            // menuBox
            // 
            this.menuBox.Controls.Add(this.edRadio);
            this.menuBox.Controls.Add(this.rBox);
            this.menuBox.Controls.Add(this.dRadio);
            this.menuBox.Controls.Add(this.eRadio);
            this.menuBox.Location = new System.Drawing.Point(15, 91);
            this.menuBox.Name = "menuBox";
            this.menuBox.Size = new System.Drawing.Size(362, 95);
            this.menuBox.TabIndex = 14;
            this.menuBox.TabStop = false;
            this.menuBox.Text = "Menu";
            // 
            // dRadio
            // 
            this.dRadio.AutoSize = true;
            this.dRadio.Location = new System.Drawing.Point(6, 65);
            this.dRadio.Name = "dRadio";
            this.dRadio.Size = new System.Drawing.Size(77, 17);
            this.dRadio.TabIndex = 13;
            this.dRadio.Text = "Only Dates";
            this.dRadio.UseVisualStyleBackColor = true;
            // 
            // FixerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 194);
            this.Controls.Add(this.menuBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.filesTime);
            this.Controls.Add(this.reloadGroup);
            this.Controls.Add(this.fixBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FixerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FixerForm_FormClosing);
            this.Load += new System.EventHandler(this.FixerForm_Load);
            this.reloadGroup.ResumeLayout(false);
            this.reloadGroup.PerformLayout();
            this.menuBox.ResumeLayout(false);
            this.menuBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Button fixBtn;
        private System.Windows.Forms.FolderBrowserDialog mainDlg;
        private System.Windows.Forms.CheckBox rBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox reloadFBox;
        private System.Windows.Forms.Button browseRBtn;
        private System.Windows.Forms.GroupBox reloadGroup;
        private System.Windows.Forms.FolderBrowserDialog reloadDlg;
        private System.Windows.Forms.DateTimePicker filesTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton edRadio;
        private System.Windows.Forms.RadioButton eRadio;
        private System.Windows.Forms.GroupBox menuBox;
        private System.Windows.Forms.RadioButton dRadio;
    }
}

