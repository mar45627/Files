namespace IndexEditor
{
    partial class AddIndex
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
            this.resBox = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.getMaxBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resBox
            // 
            this.resBox.Location = new System.Drawing.Point(79, 9);
            this.resBox.Name = "resBox";
            this.resBox.Size = new System.Drawing.Size(202, 20);
            this.resBox.TabIndex = 0;
            this.resBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resBox_KeyPress);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 35);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(127, 23);
            this.okBtn.TabIndex = 1;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Index:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(145, 35);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(136, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // getMaxBtn
            // 
            this.getMaxBtn.Location = new System.Drawing.Point(12, 64);
            this.getMaxBtn.Name = "getMaxBtn";
            this.getMaxBtn.Size = new System.Drawing.Size(269, 23);
            this.getMaxBtn.TabIndex = 3;
            this.getMaxBtn.Text = "Get Max Free ResourceId";
            this.getMaxBtn.UseVisualStyleBackColor = true;
            this.getMaxBtn.Click += new System.EventHandler(this.getMaxBtn_Click);
            // 
            // AddIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 95);
            this.Controls.Add(this.getMaxBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.resBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddIndex";
            this.Text = "AddIndex";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox resBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button getMaxBtn;
    }
}