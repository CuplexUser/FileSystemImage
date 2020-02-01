namespace FileSystemImage
{
    partial class FormFolderProperties
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
            this.grpBoxFolderProps = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewFolderProperties = new System.Windows.Forms.ListView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dataSetFolderNode = new System.Data.DataSet();
            this.grpBoxFolderProps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFolderNode)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxFolderProps
            // 
            this.grpBoxFolderProps.Controls.Add(this.btnClose);
            this.grpBoxFolderProps.Controls.Add(this.label1);
            this.grpBoxFolderProps.Controls.Add(this.listViewFolderProperties);
            this.grpBoxFolderProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxFolderProps.Location = new System.Drawing.Point(0, 0);
            this.grpBoxFolderProps.Margin = new System.Windows.Forms.Padding(8);
            this.grpBoxFolderProps.Name = "grpBoxFolderProps";
            this.grpBoxFolderProps.Size = new System.Drawing.Size(409, 281);
            this.grpBoxFolderProps.TabIndex = 0;
            this.grpBoxFolderProps.TabStop = false;
            this.grpBoxFolderProps.Text = "FolderNameHere";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(323, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Details:";
            // 
            // listViewFolderProperties
            // 
            this.listViewFolderProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFolderProperties.BackColor = System.Drawing.SystemColors.Window;
            this.listViewFolderProperties.FullRowSelect = true;
            this.listViewFolderProperties.GridLines = true;
            this.listViewFolderProperties.HideSelection = false;
            this.listViewFolderProperties.Location = new System.Drawing.Point(8, 51);
            this.listViewFolderProperties.Margin = new System.Windows.Forms.Padding(5);
            this.listViewFolderProperties.MultiSelect = false;
            this.listViewFolderProperties.Name = "listViewFolderProperties";
            this.listViewFolderProperties.Size = new System.Drawing.Size(390, 192);
            this.listViewFolderProperties.TabIndex = 0;
            this.listViewFolderProperties.UseCompatibleStateImageBehavior = false;
            this.listViewFolderProperties.View = System.Windows.Forms.View.List;
            // 
            // dataSetFolderNode
            // 
            this.dataSetFolderNode.DataSetName = "NewDataSet";
            // 
            // FormFolderProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 281);
            this.Controls.Add(this.grpBoxFolderProps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormFolderProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Folder Properties";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormFolderProperties_Load);
            this.grpBoxFolderProps.ResumeLayout(false);
            this.grpBoxFolderProps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetFolderNode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxFolderProps;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewFolderProperties;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Data.DataSet dataSetFolderNode;
    }
}