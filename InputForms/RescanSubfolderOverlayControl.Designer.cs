namespace FileSystemImage.InputForms
{
    partial class RescanSubfolderOverlayControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbScanProgress = new System.Windows.Forms.ProgressBar();
            this.grpBoxMain = new System.Windows.Forms.GroupBox();
            this.bwScanFileSystem = new System.ComponentModel.BackgroundWorker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentFolder = new System.Windows.Forms.Label();
            this.listViewHistory = new System.Windows.Forms.ListView();
            this.grpBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbScanProgress
            // 
            this.pbScanProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScanProgress.Location = new System.Drawing.Point(5, 230);
            this.pbScanProgress.Margin = new System.Windows.Forms.Padding(5);
            this.pbScanProgress.Name = "pbScanProgress";
            this.pbScanProgress.Size = new System.Drawing.Size(490, 20);
            this.pbScanProgress.TabIndex = 0;
            // 
            // grpBoxMain
            // 
            this.grpBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxMain.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxMain.Controls.Add(this.listViewHistory);
            this.grpBoxMain.Controls.Add(this.lblCurrentFolder);
            this.grpBoxMain.Controls.Add(this.label3);
            this.grpBoxMain.Controls.Add(this.label2);
            this.grpBoxMain.Controls.Add(this.label1);
            this.grpBoxMain.Controls.Add(this.btnCancel);
            this.grpBoxMain.Location = new System.Drawing.Point(10, 10);
            this.grpBoxMain.Name = "grpBoxMain";
            this.grpBoxMain.Size = new System.Drawing.Size(485, 212);
            this.grpBoxMain.TabIndex = 1;
            this.grpBoxMain.TabStop = false;
            this.grpBoxMain.Text = "Scaning {0}";
            // 
            // bwScanFileSystem
            // 
            this.bwScanFileSystem.WorkerReportsProgress = true;
            this.bwScanFileSystem.WorkerSupportsCancellation = true;
            this.bwScanFileSystem.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BwScanFileSystem_DoWork);
            this.bwScanFileSystem.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BwScanFileSystem_ProgressChanged);
            this.bwScanFileSystem.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BwScanFileSystem_RunWorkerCompleted);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Location = new System.Drawing.Point(384, 178);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 28);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Root Folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(Master Folder)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Scanning:";
            // 
            // lblCurrentFolder
            // 
            this.lblCurrentFolder.AutoSize = true;
            this.lblCurrentFolder.Location = new System.Drawing.Point(7, 67);
            this.lblCurrentFolder.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCurrentFolder.Name = "lblCurrentFolder";
            this.lblCurrentFolder.Size = new System.Drawing.Size(76, 13);
            this.lblCurrentFolder.TabIndex = 4;
            this.lblCurrentFolder.Text = "(CurrentFolder)";
            // 
            // listViewHistory
            // 
            this.listViewHistory.AutoArrange = false;
            this.listViewHistory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listViewHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewHistory.HideSelection = false;
            this.listViewHistory.Location = new System.Drawing.Point(6, 88);
            this.listViewHistory.MultiSelect = false;
            this.listViewHistory.Name = "listViewHistory";
            this.listViewHistory.Size = new System.Drawing.Size(370, 119);
            this.listViewHistory.TabIndex = 5;
            this.listViewHistory.UseCompatibleStateImageBehavior = false;
            this.listViewHistory.View = System.Windows.Forms.View.List;
            // 
            // RescanSubfolderOverlayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.grpBoxMain);
            this.Controls.Add(this.pbScanProgress);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "RescanSubfolderOverlayControl";
            this.Size = new System.Drawing.Size(500, 255);
            this.Load += new System.EventHandler(this.RescanSubfolderOverlayControl_Load);
            this.grpBoxMain.ResumeLayout(false);
            this.grpBoxMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbScanProgress;
        private System.Windows.Forms.GroupBox grpBoxMain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker bwScanFileSystem;
        private System.Windows.Forms.ListView listViewHistory;
        private System.Windows.Forms.Label lblCurrentFolder;
    }
}
