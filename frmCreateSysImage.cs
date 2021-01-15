using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileSystemImage.DataModels;
using FileSystemImage.Library.Delegates;
using FileSystemImage.Models;
using FileSystemImage.Services;
using Serilog;
using GeneralToolkitLib.Converters;

namespace FileSystemImage
{
    public partial class FrmCreateSysImage : Form
    {
        private readonly object _fileSystemDriveLock = new object();
        private DriveModel _currentFileSystemDrive;
        private FormMain _mainWindow;
        private readonly DiskScanService _diskScanService;

        public FrmCreateSysImage(DiskScanService diskScanService)
        {
            _diskScanService = diskScanService;
            InitializeComponent();
        }

        public void SetMainWindow(FormMain frm)
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

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if(drpDrive.SelectedIndex >= 0)
            {
                btnStart.Enabled = false;
                btnCancel.Enabled = true;
                btnLoadFileSys.Enabled = false;
                
                await _diskScanService.CreateFileSystemDriveData(((ListItem)drpDrive.Items[drpDrive.SelectedIndex]).Value, ProgressUpdate, SetFileSystemDrive).ConfigureAwait(true);    
            }
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnCancel.Enabled = false;
            await _diskScanService.CancelCreateFileSystemDriveData();            
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
        public void SetFileSystemDrive(DriveModel driveModel)
        {
            lock (_fileSystemDriveLock)
            {
                _currentFileSystemDrive = driveModel;
            }
            if(Visible)
                Invoke(new CreateFileSystemImageComplete(SetFileSystemDriveComplete));

            _diskScanService.DeAllocateWorkerThread();
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
            if(_diskScanService.IsRunning)
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