namespace IndexEditor
{
    partial class Srv
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Srv));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dupCleanerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dupNewCleanerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexNullResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexAllResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateZipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemBox = new System.Windows.Forms.TextBox();
            this.resBox = new System.Windows.Forms.TextBox();
            this.fileList = new System.Windows.Forms.ListView();
            this.fileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.addRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootPak = new System.Windows.Forms.ToolStripMenuItem();
            this.addRootPaks = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getResIdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.LoadWorker = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.fileMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dupCleanerToolStripMenuItem,
            this.dupNewCleanerToolStripMenuItem,
            this.indexNullResourcesToolStripMenuItem,
            this.indexAllResourcesToolStripMenuItem,
            this.generateZipToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // dupCleanerToolStripMenuItem
            // 
            this.dupCleanerToolStripMenuItem.Name = "dupCleanerToolStripMenuItem";
            this.dupCleanerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.dupCleanerToolStripMenuItem.Text = "Dup-Cleaner";
            this.dupCleanerToolStripMenuItem.Click += new System.EventHandler(this.dupCleanerToolStripMenuItem_Click);
            // 
            // dupNewCleanerToolStripMenuItem
            // 
            this.dupNewCleanerToolStripMenuItem.Name = "dupNewCleanerToolStripMenuItem";
            this.dupNewCleanerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.dupNewCleanerToolStripMenuItem.Text = "Dup-New-Cleaner";
            this.dupNewCleanerToolStripMenuItem.Click += new System.EventHandler(this.dupNewCleanerToolStripMenuItem_Click);
            // 
            // indexNullResourcesToolStripMenuItem
            // 
            this.indexNullResourcesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Highlight;
            this.indexNullResourcesToolStripMenuItem.Name = "indexNullResourcesToolStripMenuItem";
            this.indexNullResourcesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.indexNullResourcesToolStripMenuItem.Text = "Index Null Resources";
            this.indexNullResourcesToolStripMenuItem.Click += new System.EventHandler(this.indexNullResourcesToolStripMenuItem_Click);
            // 
            // indexAllResourcesToolStripMenuItem
            // 
            this.indexAllResourcesToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon;
            this.indexAllResourcesToolStripMenuItem.Name = "indexAllResourcesToolStripMenuItem";
            this.indexAllResourcesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.indexAllResourcesToolStripMenuItem.Text = "Index All Resources";
            this.indexAllResourcesToolStripMenuItem.Click += new System.EventHandler(this.indexAllResourcesToolStripMenuItem_Click);
            // 
            // generateZipToolStripMenuItem
            // 
            this.generateZipToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.generateZipToolStripMenuItem.Name = "generateZipToolStripMenuItem";
            this.generateZipToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.generateZipToolStripMenuItem.Text = "Generate Zip";
            this.generateZipToolStripMenuItem.Click += new System.EventHandler(this.generateZipToolStripMenuItem_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(12, 27);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(767, 20);
            this.pathBox.TabIndex = 9;
            this.pathBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pathBox_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "File:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(487, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ResourceId:";
            // 
            // itemBox
            // 
            this.itemBox.Location = new System.Drawing.Point(45, 377);
            this.itemBox.MaxLength = 32222;
            this.itemBox.Name = "itemBox";
            this.itemBox.ReadOnly = true;
            this.itemBox.Size = new System.Drawing.Size(436, 20);
            this.itemBox.TabIndex = 13;
            // 
            // resBox
            // 
            this.resBox.Location = new System.Drawing.Point(558, 377);
            this.resBox.MaxLength = 20;
            this.resBox.Name = "resBox";
            this.resBox.Size = new System.Drawing.Size(221, 20);
            this.resBox.TabIndex = 14;
            this.resBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resBox_KeyDown);
            this.resBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.resBox_KeyPress);
            // 
            // fileList
            // 
            this.fileList.AllowDrop = true;
            this.fileList.ContextMenuStrip = this.fileMenu;
            this.fileList.Location = new System.Drawing.Point(12, 53);
            this.fileList.Name = "fileList";
            this.fileList.Size = new System.Drawing.Size(767, 318);
            this.fileList.TabIndex = 12;
            this.fileList.UseCompatibleStateImageBehavior = false;
            this.fileList.View = System.Windows.Forms.View.List;
            this.fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.fileList_DragDrop);
            this.fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.fileList_DragEnter);
            this.fileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.fileList_MouseDoubleClick);
            // 
            // fileMenu
            // 
            this.fileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.getResIdToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(154, 92);
            this.fileMenu.Opening += new System.ComponentModel.CancelEventHandler(this.fileMenu_Opening);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryToolStripMenuItem,
            this.addRootItem,
            this.addItem,
            this.addCurrent,
            this.addRoot,
            this.addRootPak,
            this.addRootPaks,
            this.addFolderToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // addRootItem
            // 
            this.addRootItem.BackColor = System.Drawing.SystemColors.Window;
            this.addRootItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.addRootItem.Name = "addRootItem";
            this.addRootItem.Size = new System.Drawing.Size(163, 22);
            this.addRootItem.Text = "Create Root Item";
            this.addRootItem.Click += new System.EventHandler(this.addRootItem_Click);
            // 
            // addItem
            // 
            this.addItem.BackColor = System.Drawing.SystemColors.Window;
            this.addItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(163, 22);
            this.addItem.Text = "Create Item";
            this.addItem.Click += new System.EventHandler(this.addItem_Click);
            // 
            // addCurrent
            // 
            this.addCurrent.ForeColor = System.Drawing.Color.DarkGreen;
            this.addCurrent.Name = "addCurrent";
            this.addCurrent.Size = new System.Drawing.Size(163, 22);
            this.addCurrent.Text = "Add Current";
            this.addCurrent.Click += new System.EventHandler(this.addCurrent_Click);
            // 
            // addRoot
            // 
            this.addRoot.ForeColor = System.Drawing.Color.DarkGreen;
            this.addRoot.Name = "addRoot";
            this.addRoot.Size = new System.Drawing.Size(163, 22);
            this.addRoot.Text = "Add Root";
            this.addRoot.Click += new System.EventHandler(this.addRoot_Click);
            // 
            // addRootPak
            // 
            this.addRootPak.ForeColor = System.Drawing.Color.DarkMagenta;
            this.addRootPak.Name = "addRootPak";
            this.addRootPak.Size = new System.Drawing.Size(163, 22);
            this.addRootPak.Text = "Add Root Pak";
            this.addRootPak.Click += new System.EventHandler(this.addRootPak_Click);
            // 
            // addRootPaks
            // 
            this.addRootPaks.ForeColor = System.Drawing.Color.DarkMagenta;
            this.addRootPaks.Name = "addRootPaks";
            this.addRootPaks.Size = new System.Drawing.Size(163, 22);
            this.addRootPaks.Text = "Add Root Paks";
            this.addRootPaks.Click += new System.EventHandler(this.addRootPaks_Click);
            // 
            // addFolderToolStripMenuItem
            // 
            this.addFolderToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.addFolderToolStripMenuItem.Name = "addFolderToolStripMenuItem";
            this.addFolderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addFolderToolStripMenuItem.Text = "Add Folder";
            this.addFolderToolStripMenuItem.Click += new System.EventHandler(this.addFolderToolStripMenuItem_Click);
            // 
            // createDirectoryToolStripMenuItem
            // 
            this.createDirectoryToolStripMenuItem.ForeColor = System.Drawing.Color.Navy;
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.createDirectoryToolStripMenuItem.Text = "Create Directory";
            this.createDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // getResIdToolStripMenuItem
            // 
            this.getResIdToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.getResIdToolStripMenuItem.ForeColor = System.Drawing.Color.MediumBlue;
            this.getResIdToolStripMenuItem.Name = "getResIdToolStripMenuItem";
            this.getResIdToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.getResIdToolStripMenuItem.Text = "Get ResourceId";
            this.getResIdToolStripMenuItem.Click += new System.EventHandler(this.getResIdToolStripMenuItem_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 403);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(768, 34);
            this.progressBar1.TabIndex = 18;
            // 
            // LoadWorker
            // 
            this.LoadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadWorker_DoWork);
            // 
            // Srv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 449);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.itemBox);
            this.Controls.Add(this.resBox);
            this.Controls.Add(this.fileList);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Srv";
            this.Text = "Srv";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Srv_FormClosing);
            this.Load += new System.EventHandler(this.Srv_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.fileMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox itemBox;
        private System.Windows.Forms.TextBox resBox;
        private System.Windows.Forms.ListView fileList;
        private System.Windows.Forms.ContextMenuStrip fileMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRootItem;
        private System.Windows.Forms.ToolStripMenuItem addItem;
        private System.Windows.Forms.ToolStripMenuItem addCurrent;
        private System.Windows.Forms.ToolStripMenuItem addRoot;
        private System.Windows.Forms.ToolStripMenuItem addRootPak;
        private System.Windows.Forms.ToolStripMenuItem addRootPaks;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker LoadWorker;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dupCleanerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dupNewCleanerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getResIdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexNullResourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexAllResourcesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateZipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDirectoryToolStripMenuItem;
    }
}