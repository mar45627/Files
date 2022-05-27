namespace GameVersion
{
    partial class TruncatorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "game.version";
            // 
            // fileBox
            // 
            this.fileBox.AllowDrop = true;
            this.fileBox.Location = new System.Drawing.Point(88, 6);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(641, 20);
            this.fileBox.TabIndex = 1;
            this.fileBox.Text = "game.version";
            this.fileBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileBox_DragDrop);
            this.fileBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileBox_DragEnter);
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(654, 32);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 2;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(12, 32);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(165, 23);
            this.readButton.TabIndex = 3;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(183, 32);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(160, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TruncatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 295);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TruncatorForm";
            this.Text = "Reader for game.version";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TruncatorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.Button saveButton;
    }
}

