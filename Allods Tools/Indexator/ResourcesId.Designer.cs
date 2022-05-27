namespace IndexEditor
{
    partial class ResourcesId
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
            this.resView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathBox = new System.Windows.Forms.TextBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // resView
            // 
            this.resView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.resView.Location = new System.Drawing.Point(12, 12);
            this.resView.MultiSelect = false;
            this.resView.Name = "resView";
            this.resView.Size = new System.Drawing.Size(579, 316);
            this.resView.TabIndex = 0;
            this.resView.UseCompatibleStateImageBehavior = false;
            this.resView.View = System.Windows.Forms.View.Details;
            this.resView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.resView_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ResourceId";
            this.columnHeader1.Width = 81;
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 334);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(579, 20);
            this.pathBox.TabIndex = 1;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Path";
            this.columnHeader2.Width = 494;
            // 
            // ResourcesId
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 363);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.resView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResourcesId";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resources";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResourcesId_FormClosing);
            this.Load += new System.EventHandler(this.ResourcesId_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView resView;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}