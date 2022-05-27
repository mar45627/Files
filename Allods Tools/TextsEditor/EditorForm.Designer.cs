namespace TextsEditor
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            this.FileBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.ExButton = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.ProgressBar();
            this.ReadButton = new System.Windows.Forms.Button();
            this.WorkThread = new System.ComponentModel.BackgroundWorker();
            this.OutputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DirBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ArcBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileBox
            // 
            this.FileBox.AllowDrop = true;
            this.FileBox.Location = new System.Drawing.Point(69, 11);
            this.FileBox.Name = "FileBox";
            this.FileBox.Size = new System.Drawing.Size(622, 20);
            this.FileBox.TabIndex = 0;
            this.FileBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileBox_DragDrop);
            this.FileBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileBox_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "File:";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(697, 9);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(62, 23);
            this.BrowseButton.TabIndex = 2;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // ExButton
            // 
            this.ExButton.Location = new System.Drawing.Point(579, 38);
            this.ExButton.Name = "ExButton";
            this.ExButton.Size = new System.Drawing.Size(180, 38);
            this.ExButton.TabIndex = 3;
            this.ExButton.Text = "Extract";
            this.ExButton.UseVisualStyleBackColor = true;
            this.ExButton.Click += new System.EventHandler(this.ExButton_Click);
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(12, 81);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(747, 23);
            this.statusBar.TabIndex = 4;
            // 
            // ReadButton
            // 
            this.ReadButton.Location = new System.Drawing.Point(301, 209);
            this.ReadButton.Name = "ReadButton";
            this.ReadButton.Size = new System.Drawing.Size(172, 38);
            this.ReadButton.TabIndex = 6;
            this.ReadButton.Text = "Pack";
            this.ReadButton.UseVisualStyleBackColor = true;
            this.ReadButton.Click += new System.EventHandler(this.ReadButton_Click);
            // 
            // WorkThread
            // 
            this.WorkThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.WorkThread_DoWork);
            // 
            // OutputBox
            // 
            this.OutputBox.AllowDrop = true;
            this.OutputBox.Location = new System.Drawing.Point(147, 183);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(612, 20);
            this.OutputBox.TabIndex = 0;
            this.OutputBox.Text = "Compiled/pack.loc";
            this.OutputBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileBox_DragDrop);
            this.OutputBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileBox_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Output pack:";
            // 
            // DirBox
            // 
            this.DirBox.AllowDrop = true;
            this.DirBox.Location = new System.Drawing.Point(147, 157);
            this.DirBox.Name = "DirBox";
            this.DirBox.Size = new System.Drawing.Size(612, 20);
            this.DirBox.TabIndex = 0;
            this.DirBox.Text = "Extracted";
            this.DirBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileBox_DragDrop);
            this.DirBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileBox_DragEnter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Directory:";
            // 
            // ArcBox
            // 
            this.ArcBox.AllowDrop = true;
            this.ArcBox.Location = new System.Drawing.Point(151, 45);
            this.ArcBox.Name = "ArcBox";
            this.ArcBox.Size = new System.Drawing.Size(422, 20);
            this.ArcBox.TabIndex = 0;
            this.ArcBox.Text = "GameTexts.pak";
            this.ArcBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileBox_DragDrop);
            this.ArcBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileBox_DragEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Jokerman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 28);
            this.label4.TabIndex = 1;
            this.label4.Text = "Out Archive:";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusLabel.Location = new System.Drawing.Point(12, 107);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(0, 20);
            this.StatusLabel.TabIndex = 7;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 133);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.ReadButton);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ExButton);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DirBox);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ArcBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texts Editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FileBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Button ExButton;
        private System.Windows.Forms.ProgressBar statusBar;
        private System.Windows.Forms.Button ReadButton;
        private System.ComponentModel.BackgroundWorker WorkThread;
        private System.Windows.Forms.TextBox OutputBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DirBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ArcBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StatusLabel;
    }
}

