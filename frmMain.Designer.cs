﻿namespace FileSystemImage
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node5", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node8");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node9");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imgIconImgList = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFilePathMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyFileToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driveInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MainContentPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.FileListDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileSystemFileWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LoadAndSaveProgressInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.DirectoryInfoDataLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.LoadAndSaveProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.ChecksumFileGenerationLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStripFile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.createSFVFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createMD5FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripFolder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemUpdateFolderRecursive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemUpdateFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItemShowInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemFolderProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemCopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuItemDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.FileInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu.SuspendLayout();
            this.MainContentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemFileWrapperBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStripFile.SuspendLayout();
            this.contextMenuStripFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FileInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // imgIconImgList
            // 
            this.imgIconImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIconImgList.ImageStream")));
            this.imgIconImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIconImgList.Images.SetKeyName(0, "Folder_32.ico");
            this.imgIconImgList.Images.SetKeyName(1, "Devices-drive-harddisk_32.ico");
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(834, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem3,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyFileMenuItem,
            this.copyFilePathMenuItem,
            this.copyFileToolStripMenuItem,
            this.selectAllMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyFileMenuItem
            // 
            this.copyFileMenuItem.Name = "copyFileMenuItem";
            this.copyFileMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyFileMenuItem.Size = new System.Drawing.Size(203, 22);
            this.copyFileMenuItem.Text = "&Copy";
            this.copyFileMenuItem.Click += new System.EventHandler(this.copyFileMenuItem_Click);
            // 
            // copyFilePathMenuItem
            // 
            this.copyFilePathMenuItem.Name = "copyFilePathMenuItem";
            this.copyFilePathMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.copyFilePathMenuItem.Size = new System.Drawing.Size(203, 22);
            this.copyFilePathMenuItem.Text = "Copy &Path";
            this.copyFilePathMenuItem.Click += new System.EventHandler(this.copyFilePathMenuItem_Click);
            // 
            // copyFileToolStripMenuItem
            // 
            this.copyFileToolStripMenuItem.Name = "copyFileToolStripMenuItem";
            this.copyFileToolStripMenuItem.Size = new System.Drawing.Size(200, 6);
            // 
            // selectAllMenuItem
            // 
            this.selectAllMenuItem.Name = "selectAllMenuItem";
            this.selectAllMenuItem.Size = new System.Drawing.Size(203, 22);
            this.selectAllMenuItem.Text = "&Select All";
            this.selectAllMenuItem.Click += new System.EventHandler(this.selectAllMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driveInfoToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripMenuItem6,
            this.clearToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // driveInfoToolStripMenuItem
            // 
            this.driveInfoToolStripMenuItem.Name = "driveInfoToolStripMenuItem";
            this.driveInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.driveInfoToolStripMenuItem.Text = "Drive info";
            this.driveInfoToolStripMenuItem.Click += new System.EventHandler(this.driveInfoToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainContentPanel
            // 
            this.MainContentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainContentPanel.Controls.Add(this.splitContainer1);
            this.MainContentPanel.Location = new System.Drawing.Point(0, 27);
            this.MainContentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainContentPanel.Name = "MainContentPanel";
            this.MainContentPanel.Size = new System.Drawing.Size(834, 431);
            this.MainContentPanel.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.FolderTreeView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.FileListDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(834, 431);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 4;
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderTreeView.ImageIndex = 0;
            this.FolderTreeView.ImageList = this.imgIconImgList;
            this.FolderTreeView.ItemHeight = 22;
            this.FolderTreeView.Location = new System.Drawing.Point(0, 0);
            this.FolderTreeView.Name = "FolderTreeView";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node4";
            treeNode2.Text = "Node4";
            treeNode3.Name = "Node6";
            treeNode3.Text = "Node6";
            treeNode4.Name = "Node5";
            treeNode4.Text = "Node5";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Node7";
            treeNode7.Name = "Node8";
            treeNode7.Text = "Node8";
            treeNode8.Name = "Node9";
            treeNode8.Text = "Node9";
            treeNode9.Name = "Node3";
            treeNode9.Text = "Node3";
            treeNode10.Name = "Node0";
            treeNode10.Text = "Node0";
            this.FolderTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.FolderTreeView.SelectedImageIndex = 0;
            this.FolderTreeView.ShowLines = false;
            this.FolderTreeView.ShowRootLines = false;
            this.FolderTreeView.Size = new System.Drawing.Size(250, 431);
            this.FolderTreeView.TabIndex = 0;
            this.FolderTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeExpand);
            this.FolderTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterExpand);
            this.FolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            this.FolderTreeView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FolderTreeView_MouseClick);
            // 
            // FileListDataGridView
            // 
            this.FileListDataGridView.AllowUserToAddRows = false;
            this.FileListDataGridView.AllowUserToDeleteRows = false;
            this.FileListDataGridView.AllowUserToOrderColumns = true;
            this.FileListDataGridView.AllowUserToResizeRows = false;
            this.FileListDataGridView.AutoGenerateColumns = false;
            this.FileListDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.FileListDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileListDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FileListDataGridView.ColumnHeadersHeight = 25;
            this.FileListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.FileListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.FileListDataGridView.DataSource = this.fileSystemFileWrapperBindingSource;
            this.FileListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.FileListDataGridView.Location = new System.Drawing.Point(0, 0);
            this.FileListDataGridView.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.FileListDataGridView.Name = "FileListDataGridView";
            this.FileListDataGridView.ReadOnly = true;
            this.FileListDataGridView.RowHeadersVisible = false;
            this.FileListDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.FileListDataGridView.RowTemplate.Height = 15;
            this.FileListDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FileListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FileListDataGridView.Size = new System.Drawing.Size(576, 431);
            this.FileListDataGridView.TabIndex = 0;
            this.FileListDataGridView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FileListDataGridView_MouseUp);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "FullPath";
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "FullPath";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FileSize";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn3.HeaderText = "FileSize";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 75;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Attributes";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Attributes";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 25;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 88;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CreateDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "CreateDate";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 94;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ModifiedDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "ModifiedDate";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 108;
            // 
            // fileSystemFileWrapperBindingSource
            // 
            this.fileSystemFileWrapperBindingSource.DataSource = typeof(FileSystemImage.DataModels.FileSystemFileWrapper);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadAndSaveProgressInfoLabel,
            this.DirectoryInfoDataLabel,
            this.LoadAndSaveProgressBar,
            this.ChecksumFileGenerationLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 22);
            this.statusStrip1.TabIndex = 6;
            // 
            // LoadAndSaveProgressInfoLabel
            // 
            this.LoadAndSaveProgressInfoLabel.Name = "LoadAndSaveProgressInfoLabel";
            this.LoadAndSaveProgressInfoLabel.Size = new System.Drawing.Size(21, 17);
            this.LoadAndSaveProgressInfoLabel.Text = "A2";
            // 
            // DirectoryInfoDataLabel
            // 
            this.DirectoryInfoDataLabel.Name = "DirectoryInfoDataLabel";
            this.DirectoryInfoDataLabel.Size = new System.Drawing.Size(21, 17);
            this.DirectoryInfoDataLabel.Text = "A1";
            // 
            // LoadAndSaveProgressBar
            // 
            this.LoadAndSaveProgressBar.Name = "LoadAndSaveProgressBar";
            this.LoadAndSaveProgressBar.Size = new System.Drawing.Size(175, 16);
            this.LoadAndSaveProgressBar.Step = 1;
            // 
            // ChecksumFileGenerationLabel
            // 
            this.ChecksumFileGenerationLabel.Name = "ChecksumFileGenerationLabel";
            this.ChecksumFileGenerationLabel.Size = new System.Drawing.Size(21, 17);
            this.ChecksumFileGenerationLabel.Text = "A3";
            // 
            // contextMenuStripFile
            // 
            this.contextMenuStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.toolStripSeparator1,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.renameToolStripMenuItem,
            this.toolStripMenuItem4,
            this.createSFVFileToolStripMenuItem,
            this.createMD5FileToolStripMenuItem,
            this.toolStripMenuItem5,
            this.deleteToolStripMenuItem});
            this.contextMenuStripFile.Name = "contextMenuStripFile";
            this.contextMenuStripFile.Size = new System.Drawing.Size(158, 204);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.updateToolStripMenuItem.Text = "Update Folder";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 6);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(154, 6);
            // 
            // createSFVFileToolStripMenuItem
            // 
            this.createSFVFileToolStripMenuItem.Name = "createSFVFileToolStripMenuItem";
            this.createSFVFileToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.createSFVFileToolStripMenuItem.Text = "Create SFV File";
            this.createSFVFileToolStripMenuItem.Click += new System.EventHandler(this.createSFVFileToolStripMenuItem_Click);
            // 
            // createMD5FileToolStripMenuItem
            // 
            this.createMD5FileToolStripMenuItem.Name = "createMD5FileToolStripMenuItem";
            this.createMD5FileToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.createMD5FileToolStripMenuItem.Text = "Create MD5 File";
            this.createMD5FileToolStripMenuItem.Click += new System.EventHandler(this.createMD5FileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(154, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // contextMenuStripFolder
            // 
            this.contextMenuStripFolder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemUpdateFolderRecursive,
            this.tsMenuItemUpdateFolder,
            this.toolStripSeparator2,
            this.tsMenuItemShowInExplorer,
            this.tsMenuItemFolderProperties,
            this.tsMenuItemCopyPath,
            this.toolStripSeparator3,
            this.tsMenuItemDeleteFolder});
            this.contextMenuStripFolder.Name = "contextMenuStripFolder";
            this.contextMenuStripFolder.Size = new System.Drawing.Size(203, 148);
            // 
            // tsMenuItemUpdateFolderRecursive
            // 
            this.tsMenuItemUpdateFolderRecursive.Name = "tsMenuItemUpdateFolderRecursive";
            this.tsMenuItemUpdateFolderRecursive.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.tsMenuItemUpdateFolderRecursive.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemUpdateFolderRecursive.Text = "Rescan";
            this.tsMenuItemUpdateFolderRecursive.Click += new System.EventHandler(this.TsMenuItemUpdateFolderRecursive_Click);
            // 
            // tsMenuItemUpdateFolder
            // 
            this.tsMenuItemUpdateFolder.Name = "tsMenuItemUpdateFolder";
            this.tsMenuItemUpdateFolder.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemUpdateFolder.Text = "Rescan Content";
            this.tsMenuItemUpdateFolder.Click += new System.EventHandler(this.TsMenuItemUpdateFolder_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
            // 
            // tsMenuItemShowInExplorer
            // 
            this.tsMenuItemShowInExplorer.Name = "tsMenuItemShowInExplorer";
            this.tsMenuItemShowInExplorer.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsMenuItemShowInExplorer.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemShowInExplorer.Text = "Open In Explorer";
            this.tsMenuItemShowInExplorer.Click += new System.EventHandler(this.TsMenuItemShowInExplorer_Click);
            // 
            // tsMenuItemFolderProperties
            // 
            this.tsMenuItemFolderProperties.Name = "tsMenuItemFolderProperties";
            this.tsMenuItemFolderProperties.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemFolderProperties.Text = "Show Properties";
            this.tsMenuItemFolderProperties.Click += new System.EventHandler(this.TsMenuItemFolderProperties_Click);
            // 
            // tsMenuItemCopyPath
            // 
            this.tsMenuItemCopyPath.Name = "tsMenuItemCopyPath";
            this.tsMenuItemCopyPath.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsMenuItemCopyPath.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemCopyPath.Text = "CopyPath";
            this.tsMenuItemCopyPath.Click += new System.EventHandler(this.TsMenuItemCopyPath_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(199, 6);
            // 
            // tsMenuItemDeleteFolder
            // 
            this.tsMenuItemDeleteFolder.Name = "tsMenuItemDeleteFolder";
            this.tsMenuItemDeleteFolder.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsMenuItemDeleteFolder.Size = new System.Drawing.Size(202, 22);
            this.tsMenuItemDeleteFolder.Text = "Delete...";
            this.tsMenuItemDeleteFolder.Click += new System.EventHandler(this.TsMenuItemDeleteFolder_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(177, 6);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 483);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.MainContentPanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File system image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainContentPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemFileWrapperBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStripFile.ResumeLayout(false);
            this.contextMenuStripFolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FileInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driveInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ImageList imgIconImgList;
        private System.Windows.Forms.Panel MainContentPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.DataGridView FileListDataGridView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel DirectoryInfoDataLabel;
        private System.Windows.Forms.ToolStripStatusLabel LoadAndSaveProgressInfoLabel;
        private System.Windows.Forms.ToolStripProgressBar LoadAndSaveProgressBar;
        private System.Windows.Forms.ToolStripMenuItem copyFileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyFilePathMenuItem;
        private System.Windows.Forms.ToolStripSeparator copyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFile;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem createSFVFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createMD5FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel ChecksumFileGenerationLabel;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripFolder;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemUpdateFolderRecursive;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemUpdateFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemShowInExplorer;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemFolderProperties;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemCopyPath;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemDeleteFolder;
        private System.Windows.Forms.BindingSource fileSystemFileWrapperBindingSource;
        private System.Windows.Forms.BindingSource FileInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullPathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn attributesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
    }
}

