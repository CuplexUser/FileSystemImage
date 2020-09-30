using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileSystemImage.FileSystem;
using GeneralToolkitLib.Converters;
using FileSystemImage.DataModels;
using Serilog;

namespace FileSystemImage
{
    public partial class FrmCreateSysImage : Form
    {
        private readonly object _fileSystemDriveLock = new object();
        private FileSystemDrive _currentFileSystemDrive;
        private FrmMain _mainWindow;

        public FrmCreateSysImage()
        {
            InitializeComponent();
        }

        public void SetMainWindow(FrmMain frm)
        {
            _mainWindow = frm;
        }

        protected void frmCreateSysImage_Load(object sender, EventArgs e)
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
                    drpDrive.Items.Add(new ListItem(GetDriveInfoListItemText(di), di.Name));                    
                }
                catch(IOException ioException)
                {
                    Log.Error(ioException, "Error in frmCreateSysImage.frmCreateSysImage_Load(): {Message}", ioException.Message);
                }
            }

            if(drpDrive.Items.Count > 0)
                drpDrive.SelectedIndex = 0;
        }

        private string GetDriveInfoListItemText(DriveInfo driveInfo)
        {
            string driveInfoText = driveInfo.VolumeLabel ?? "";
            if(!string.IsNullOrEmpty(driveInfo.Name))
                driveInfoText += $" ({driveInfo.Name.Replace("\\", "")}) ";
            else
                driveInfoText +=  " [" + driveInfo.VolumeLabel + "]";

            driveInfoText +=
                $"{GeneralConverters.FormatFileSizeToString(driveInfo.TotalFreeSpace)} free of {GeneralConverters.FormatFileSizeToString(driveInfo.TotalSize)} [{driveInfo.DriveType}, {driveInfo.DriveFormat}]";

            return driveInfoText;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(drpDrive.SelectedIndex >= 0)
            {
                FileUtils.CreateFileSystemDriveData(((ListItem)drpDrive.Items[drpDrive.SelectedIndex]).Value, ProgressUpdate, SetFileSystemDrive);
                btnStart.Enabled = false;
                btnCancel.Enabled = true;
                btnLoadFileSys.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FileUtils.CancelCreateFileSystemDriveData();
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
        }

        //Foreign thread
        public void ProgressUpdate(double percentComplete)
        {
            Invoke(new ProgressCallback(ProgressUpdateNativeThead), percentComplete);
        }

        //NativeThead
        protected void ProgressUpdateNativeThead(double percentComplete)
        {
            int pbarUpdateValue = Convert.ToInt32(Math.Round(progressBar1.Maximum*percentComplete, 0));
            if(pbarUpdateValue >= 0 && pbarUpdateValue < progressBar1.Maximum)
                progressBar1.Value = pbarUpdateValue;
            else
                progressBar1.Value = progressBar1.Maximum;
        }

        //Foreign thread
        public void SetFileSystemDrive(FileSystemDrive fileSystemDrive)
        {
            lock (_fileSystemDriveLock)
            {
                _currentFileSystemDrive = fileSystemDrive;
            }
            if(Visible)
                Invoke(new CreateFileSystemImageComplete(SetFileSystemDriveComplete));
            FileUtils.DeAllocateWorkerThread();
        }

        //NativeThead
        protected void SetFileSystemDriveComplete()
        {
            if(_currentFileSystemDrive != null)
            {
                btnLoadFileSys.Enabled = true;
                btnCancel.Enabled = false;
                btnStart.Enabled = true;
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

        private void btnLoadFileSys_Click(object sender, EventArgs e)
        {
            if (_mainWindow != null)
            {
                _mainWindow.LoadFileSystemDrive(_currentFileSystemDrive);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}