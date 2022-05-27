namespace IndexEditor
{
    partial class ZipForm
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
            this.folderBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.zipBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.packBtn = new System.Windows.Forms.Button();
            this.compLevel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.zipWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.compLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // folderBox
            // 
            this.folderBox.Location = new System.Drawing.Point(57, 12);
            this.folderBox.Name = "folderBox";
            this.folderBox.Size = new System.Drawing.Size(495, 20);
            this.folderBox.TabIndex = 0;
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
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(477, 36);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 2;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // zipBox
            // 
            this.zipBox.Location = new System.Drawing.Point(71, 38);
            this.zipBox.Name = "zipBox";
            this.zipBox.Size = new System.Drawing.Size(400, 20);
            this.zipBox.TabIndex = 0;
            this.zipBox.Text = "result.zip";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ZipName:";
            // 
            // packBtn
            // 
            this.packBtn.Location = new System.Drawing.Point(15, 70);
            this.packBtn.Name = "packBtn";
            this.packBtn.Size = new System.Drawing.Size(411, 38);
            this.packBtn.TabIndex = 3;
            this.packBtn.Text = "Pack";
            this.packBtn.UseVisualStyleBackColor = true;
            this.packBtn.Click += new System.EventHandler(this.packBtn_Click);
            // 
            // compLevel
            // 
            this.compLevel.Location = new System.Drawing.Point(432, 70);
            this.compLevel.Name = "compLevel";
            this.compLevel.Size = new System.Drawing.Size(120, 20);
            this.compLevel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(474, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "CompressLevel";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 114);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(537, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // zipWorker
            // 
            this.zipWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.zipWorker_DoWork);
            // 
            // ZipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 146);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.compLevel);
            this.Controls.Add(this.packBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zipBox);
            this.Controls.Add(this.folderBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ZipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ZipForm";
            ((System.ComponentModel.ISupportInitialize)(this.compLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox folderBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox zipBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button packBtn;
        private System.Windows.Forms.NumericUpDown compLevel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker zipWorker;
    }
}