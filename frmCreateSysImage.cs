using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileSystemImage.FileSystem;
using GeneralToolkitLib.Converters;
using Serilog;

namespace FileSystemImage
{
    public partial class frmCreateSysImage : Form
    {
        private readonly object _fileSystemDriveLock = new object();
        private FileSystemDrive currentFileSystemDrive;
        private FrmMain mainWindow;

        public frmCreateSysImage()
        {
            this.InitializeComponent();
        }

        public void SetMainWindow(FrmMain frm)
        {
            this.mainWindow = frm;
        }

        private void frmCreateSysImage_Load(object sender, EventArgs e)
        {
            DriveInfo[] driveInfoArr = null;
            try
            {
                driveInfoArr = DriveInfo.GetDrives();
            }
            catch(Exception ex)
            {
                Log.Error(ex,"Error in frmCreateSysImage.frmCreateSysImage_Load() @ DriveInfo.GetDrives(): ");
                return;
            }

            foreach (DriveInfo di in driveInfoArr.Where(d => d.IsReady))
            {
                try
                {
                    this.drpDrive.Items.Add(new ListItem(GetDriveInfoListItemText(di), di.Name));
                    //this.drpDrive.Items.Add(string.IsNullOrEmpty(di.VolumeLabel)
                    //    ? new ListItem(di.Name + " ( " + GeneralConverters.FormatFileSizeToString(di.TotalSize) + " )", di.Name)
                    //    : new ListItem(di.Name + " [" + di.VolumeLabel + "]" + " ( " + GeneralConverters.FormatFileSizeToString(di.TotalSize) + " )", di.Name));
                }
                catch(IOException ioException)
                {
                    Log.Error(ioException, "Error in frmCreateSysImage.frmCreateSysImage_Load(): {Message}", ioException.Message);
                }
            }

            if(this.drpDrive.Items.Count > 0)
                this.drpDrive.SelectedIndex = 0;
        }

        private string GetDriveInfoListItemText(DriveInfo driveInfo)
        {
            string driveInfoText = driveInfo.VolumeLabel ?? "";
            if(!string.IsNullOrEmpty(driveInfo.Name))
                driveInfoText += string.Format(" ({0}) ", driveInfo.Name.Replace("\\", ""));
            else
                driveInfoText +=  " [" + driveInfo.VolumeLabel + "]";

            driveInfoText += string.Format("{0} free of {1} [{2}, {3}]", GeneralConverters.FormatFileSizeToString(driveInfo.TotalFreeSpace), GeneralConverters.FormatFileSizeToString(driveInfo.TotalSize),
                driveInfo.DriveType, driveInfo.DriveFormat);

            return driveInfoText;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(this.drpDrive.SelectedIndex >= 0)
            {
                FileUtils.CreateFileSystemDriveData(((ListItem)this.drpDrive.Items[this.drpDrive.SelectedIndex]).Value, this.ProgressUpdate, this.SetFileSystemDrive);
                this.btnStart.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnSave.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileUtils.CancelCreateFileSystemDriveData();
            this.btnStart.Enabled = true;
            this.btnCancel.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(this.mainWindow != null)
            {
                this.mainWindow.LoadFileSystemDrive(this.currentFileSystemDrive);
                Close();
            }
        }

        //Forign thread
        public void ProgressUpdate(double percentComplete)
        {
            Invoke(new ProgressCallback(this.ProgressUpdateNativeThead), percentComplete);
        }

        //NativeThead
        protected void ProgressUpdateNativeThead(double percentComplete)
        {
            int pbarUpdateValue = Convert.ToInt32(Math.Round(this.progressBar1.Maximum*percentComplete, 0));
            if(pbarUpdateValue >= 0 && pbarUpdateValue < this.progressBar1.Maximum)
                this.progressBar1.Value = pbarUpdateValue;
            else
                this.progressBar1.Value = this.progressBar1.Maximum;
        }

        //Forign thread
        public void SetFileSystemDrive(FileSystemDrive fileSystemDrive)
        {
            lock (this._fileSystemDriveLock)
            {
                this.currentFileSystemDrive = fileSystemDrive;
            }
            if(Visible)
                Invoke(new CreateFileSystemImageComplete(this.SetFileSystemDriveComplete));
            FileUtils.DeAllocateWorkerThread();
        }

        //NativeThead
        protected void SetFileSystemDriveComplete()
        {
            if(this.currentFileSystemDrive != null)
            {
                this.btnSave.Enabled = true;
                this.btnCancel.Enabled = false;
                this.btnStart.Enabled = true;
            }
        }

        private void frmCreateSysImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(FileUtils.IsRunning)
            {
                e.Cancel = true;
                MessageBox.Show("Please cancel the drive scan operation before closing this window");
            }
        }

        private delegate void CreateFileSystemImageComplete();
    }
}