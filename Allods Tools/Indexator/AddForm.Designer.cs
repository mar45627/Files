namespace IndexEditor
{
    partial class AddForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.fileBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // fileBox
            // 
            this.fileBox.Location = new System.Drawing.Point(44, 15);
            this.fileBox.Name = "fileBox";
            this.fileBox.Size = new System.Drawing.Size(557, 20);
            this.fileBox.TabIndex = 1;
            this.fileBox.TextChanged += new System.EventHandler(this.fileBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "ResId:";
            // 
            // resBox
            // 
            this.resBox.Location = new System.Drawing.Point(56, 41);
            this.resBox.MaxLength = 20;
            this.resBox.Name = "resBox";
            this.resBox.Size = new System.Drawing.Size(545, 20);
            this.resBox.TabIndex = 1;
            this.resBox.TextChanged += new System.EventHandler(this.resBox_TextChanged);
            this.resBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resBox_KeyPress);
            // 
            // okButton
            // 
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(216, 67);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(297, 67);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 99);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.resBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddForm";
            this.Text = "Adding";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox resBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button closeButton;
    }
}