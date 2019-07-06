using System;
using System.Windows.Forms;
using FileSystemImage.FileSystem;
using GeneralToolkitLib.Converters;

namespace FileSystemImage
{
    public partial class frmDriveInfo : Form
    {
        private FileSystemDrive currentFileSystemDrive;

        public frmDriveInfo()
        {
            this.InitializeComponent();
        }

        private void frmDriveInfo_Load(object sender, EventArgs e)
        {
            if(this.currentFileSystemDrive != null)
            {
                string[] items = new string[2];
                items[0] = "DriveLetter";
                items[1] = this.currentFileSystemDrive.DriveLetter;
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "VolumeLabel";
                items[1] = this.currentFileSystemDrive.VolumeLabel;
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "DriveType";
                items[1] = this.currentFileSystemDrive.DriveType.ToString();
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "FreeSpace";
                items[1] = GeneralConverters.FormatFileSizeToString(this.currentFileSystemDrive.FreeSpace);
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "TotalSpace";
                items[1] = GeneralConverters.FormatFileSizeToString(this.currentFileSystemDrive.TotalSpace);
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "Root directory count";
                items[1] = this.currentFileSystemDrive.DirectoryList.Count.ToString();
                this.driveInfoListView.Items.Add(new ListViewItem(items));

                items = new string[2];
                items[0] = "Root file count";
                items[1] = this.currentFileSystemDrive.RootFileList.Count.ToString();
                this.driveInfoListView.Items.Add(new ListViewItem(items));
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetFileSystemDrive(FileSystemDrive fileSystemDrive)
        {
            this.currentFileSystemDrive = fileSystemDrive;
        }
    }
}