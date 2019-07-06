namespace FileSystemImage
{
    partial class frmDriveInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDriveInfo));
            this.btnOk = new System.Windows.Forms.Button();
            this.driveInfoListView = new System.Windows.Forms.ListView();
            this.properyColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(382, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 26);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // driveInfoListView
            // 
            this.driveInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.properyColumn,
            this.valueColumn});
            this.driveInfoListView.FullRowSelect = true;
            this.driveInfoListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.driveInfoListView.Location = new System.Drawing.Point(12, 12);
            this.driveInfoListView.Name = "driveInfoListView";
            this.driveInfoListView.Size = new System.Drawing.Size(455, 215);
            this.driveInfoListView.TabIndex = 1;
            this.driveInfoListView.UseCompatibleStateImageBehavior = false;
            this.driveInfoListView.View = System.Windows.Forms.View.Details;
            // 
            // properyColumn
            // 
            this.properyColumn.Text = "";
            this.properyColumn.Width = 163;
            // 
            // valueColumn
            // 
            this.valueColumn.Text = "";
            this.valueColumn.Width = 189;
            // 
            // frmDriveInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 271);
            this.Controls.Add(this.driveInfoListView);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDriveInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drive info";
            this.Load += new System.EventHandler(this.frmDriveInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ListView driveInfoListView;
        private System.Windows.Forms.ColumnHeader properyColumn;
        private System.Windows.Forms.ColumnHeader valueColumn;
    }
}