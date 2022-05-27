namespace IndexEditor
{
    partial class IndexForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.filesView = new System.Windows.Forms.ListView();
            this.fileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootPak = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootPaks = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.directoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.itemBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fileMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filesView
            // 
            this.filesView.ContextMenuStrip = this.fileMenu;
            this.filesView.Location = new System.Drawing.Point(12, 53);
            this.filesView.Name = "filesView";
            this.filesView.Size = new System.Drawing.Size(767, 318);
            this.filesView.TabIndex = 6;
            this.filesView.UseCompatibleStateImageBehavior = false;
            this.filesView.View = System.Windows.Forms.View.List;
            this.filesView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesView_MouseDoubleClick);
            // 
            // fileMenu
            // 
            this.fileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(108, 48);
            this.fileMenu.Opening += new System.ComponentModel.CancelEventHandler(this.fileMenu_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRootItem,
            this.addItem,
            this.addCurrent,
            this.addRoot,
            this.addRootPak,
            this.addRootPaks});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addRootItem
            // 
            this.addRootItem.BackColor = System.Drawing.SystemColors.Window;
            this.addRootItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.addRootItem.Name = "addRootItem";
            this.addRootItem.Size = new System.Drawing.Size(151, 22);
            this.addRootItem.Text = "Add Root Item";
            this.addRootItem.Click += new System.EventHandler(this.addRootItem_Click);
            // 
            // addItem
            // 
            this.addItem.BackColor = System.Drawing.SystemColors.Window;
            this.addItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(151, 22);
            this.addItem.Text = "Add Item";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // addCurrent
            // 
            this.addCurrent.ForeColor = System.Drawing.Color.DarkGreen;
            this.addCurrent.Name = "addCurrent";
            this.addCurrent.Size = new System.Drawing.Size(151, 22);
            this.addCurrent.Text = "Add Current";
            this.addCurrent.Click += new System.EventHandler(this.addCurrent_Click);
            // 
            // addRoot
            // 
            this.addRoot.ForeColor = System.Drawing.Color.DarkGreen;
            this.addRoot.Name = "addRoot";
            this.addRoot.Size = new System.Drawing.Size(151, 22);
            this.addRoot.Text = "Add Root";
            this.addRoot.Click += new System.EventHandler(this.addRoot_Click);
            // 
            // addRootPak
            // 
            this.addRootPak.ForeColor = System.Drawing.Color.DarkMagenta;
            this.addRootPak.Name = "addRootPak";
            this.addRootPak.Size = new System.Drawing.Size(151, 22);
            this.addRootPak.Text = "Add Root Pak";
            this.addRootPak.Click += new System.EventHandler(this.addRootPak_Click);
            // 
            // addRootPaks
            // 
            this.addRootPaks.ForeColor = System.Drawing.Color.DarkMagenta;
            this.addRootPaks.Name = "addRootPaks";
            this.addRootPaks.Size = new System.Drawing.Size(151, 22);
            this.addRootPaks.Text = "Add Root Paks";
            this.addRootPaks.Click += new System.EventHandler(this.addRootPaks_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 27);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(767, 20);
            this.pathBox.TabIndex = 8;
            this.pathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathBox_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(794, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // directoryToolStripMenuItem
            // 
            this.directoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.directoryToolStripMenuItem.Name = "directoryToolStripMenuItem";
            this.directoryToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.directoryToolStripMenuItem.Text = "Directory";
            this.directoryToolStripMenuItem.DropDownOpening += new System.EventHandler(this.directoryToolStripMenuItem_DropDownOpening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // resBox
            // 
            this.resBox.Location = new System.Drawing.Point(558, 377);
            this.resBox.MaxLength = 20;
            this.resBox.Name = "resBox";
            this.resBox.Size = new System.Drawing.Size(221, 20);
            this.resBox.TabIndex = 10;
            this.resBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resBox_KeyDown);
            this.resBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ResourceId:";
            // 
            // itemBox
            // 
            this.itemBox.Location = new System.Drawing.Point(45, 377);
            this.itemBox.MaxLength = 32222;
            this.itemBox.Name = "itemBox";
            this.itemBox.ReadOnly = true;
            this.itemBox.Size = new System.Drawing.Size(436, 20);
            this.itemBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "File:";
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.resBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.filesView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "IndexForm";
            this.Text = "Index Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IndexForm_FormClosing);
            this.Load += new System.EventHandler(this.IndexForm_Load);
            this.fileMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView filesView;
        private System.Windows.Forms.ContextMenuStrip fileMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.ToolStripMenuItem addRootItem;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem addCurrent;
        private System.Windows.Forms.ToolStripMenuItem addRoot;
        private System.Windows.Forms.ToolStripMenuItem addRootPak;
        private System.Windows.Forms.ToolStripMenuItem addRootPaks;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem directoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox resBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemBox;
        private System.Windows.Forms.Label label2;
    }
}

