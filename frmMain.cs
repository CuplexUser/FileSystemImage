using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemImage.DataModels;
using FileSystemImage.FileSystem;
using FileSystemImage.InputForms;
using FileSystemImage.Utils;
using GeneralToolkitLib.Converters;
using GeneralToolkitLib.DataTypes;
using GeneralToolkitLib.Hashing;
using GeneralToolkitLib.Storage;
using GeneralToolkitLib.Storage.Models;
using Serilog;

namespace FileSystemImage
{
    public partial class FrmMain : Form
    {
        private string _currentFileName;
        private FileSystemDrive _currentFileSystemDrive;
        private readonly ILogger _logger;

        public FrmMain()
        {
            InitializeComponent();
            FolderTreeView.Nodes.Clear();
            
            // Serilog already configured and initialized at this stage in program.cs so
            _logger = Log.Logger;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DirectoryInfoDataLabel.Text = "";
            LoadAndSaveProgressInfoLabel.Text = "";
            LoadAndSaveProgressBar.Visible = false;
            ChecksumFileGenerationLabel.Visible = false;
            InitFileListDataGridView();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new frmCreateSysImage();
            form.SetMainWindow(this);
            form.ShowDialog(this);
        }

        public void LoadFileSystemDrive(FileSystemDrive fileSystemDrive)
        {
            _currentFileSystemDrive = fileSystemDrive;
            FolderTreeView.Nodes.Clear();

            if (_currentFileSystemDrive != null)
            {
                FolderTreeView.Nodes.Add(_currentFileSystemDrive.DriveLetter);
                TreeNode root = FolderTreeView.Nodes[0];
                root.ImageIndex = 1;
                root.SelectedImageIndex = 1;
                root.StateImageIndex = 1;
                root.Name = fileSystemDrive.DriveLetter;
                root.Tag = new ROOT_Identifyer();

                foreach (FileSystemDirectory dir in _currentFileSystemDrive.DirectoryList)
                {
                    if (dir.DirectoryList == null)
                        root.Nodes.Add(dir.Name);
                    else
                    {
                        var treeNodeChildArr = new TreeNode[dir.DirectoryList.Count];
                        for (int i = 0; i < treeNodeChildArr.Length; i++)
                            treeNodeChildArr[i] = new TreeNode(dir.DirectoryList[i].Name);

                        root.Nodes.Add(new TreeNode(dir.Name, treeNodeChildArr));
                    }
                }
                if (fileSystemDrive.RootFileList != null)
                    FileListDataGridView.DataSource = fileSystemDrive.RootFileList.ConvertAll(FileSystemFileWrapper.ConvertObject);

                root.Expand();
            }
            MemoryHandler.RunGarbageCollect();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs eventArgs)
        {
            var openFileDialog = new OpenFileDialog();
            var passwordDialog = new FormGetPassword();
            openFileDialog.Filter = "FileSystemImage files (*.fsi)|*.fsi";

            if (openFileDialog.ShowDialog() == DialogResult.OK && passwordDialog.ShowDialog(this) == DialogResult.OK)
            {
                string password = passwordDialog.PasswordString;
                _currentFileSystemDrive = null;
                _currentFileName = openFileDialog.FileName;

                LoadAndSaveProgressInfoLabel.Text = "Opening file: " + openFileDialog.FileName;
                LoadFileSystemImageFromFile(_currentFileName, password);
                Log.Debug("Successfuly opened file: {FileName}", openFileDialog.FileName);
            }
        }

        private void LoadFileSystemImageFromFile(string path, string password)
        {
            var storageManagerProgress = new Progress<StorageManagerProgress>();
            LoadAndSaveProgressBar.Visible = true;
            LoadAndSaveProgressInfoLabel.Visible = true;
            openToolStripMenuItem.Enabled = false;
            storageManagerProgress.ProgressChanged += (s, e) =>
            {
                LoadAndSaveProgressBar.Value = e.ProgressPercentage;
                LoadAndSaveProgressInfoLabel.Text = e.Text;
            };
            Task.Run(async () =>
            {
                var settings = new StorageManagerSettings(true, Environment.ProcessorCount, true, password);
                var storageManager = new StorageManager(settings);

                _currentFileSystemDrive = await storageManager.DeserializeObjectFromFileAsync<FileSystemDrive>(path, storageManagerProgress);
                Invoke(new EventHandler(HandleOpenFileComplete));
            });
        }

        protected void HandleOpenFileComplete(object sender, EventArgs eventArgs)
        {
            LoadAndSaveProgressBar.Visible = false;
            LoadAndSaveProgressInfoLabel.Visible = false;
            openToolStripMenuItem.Enabled = true;

            if (_currentFileSystemDrive == null || _currentFileSystemDrive.DirectoryList == null)
                MessageBox.Show("Faild to open file!");
            else
                LoadFileSystemDrive(_currentFileSystemDrive);

            MemoryHandler.RunGarbageCollect();
        }

        protected void HandleSaveFileComplete(object sender, OutcomeEventArgs eventArgs)
        {
            LoadAndSaveProgressBar.Visible = false;
            saveAsToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            LoadAndSaveProgressInfoLabel.Text = eventArgs.Successful ? "Successfuly saved file" : "Faild to save file";

            Task.Run(async delegate
            {
                await Task.Delay(5000);
                ResetLoadAndSaveProgress();
            });

            MemoryHandler.RunGarbageCollect();
        }

        private void ResetLoadAndSaveProgress()
        {
            LoadAndSaveProgressInfoLabel.Text = "";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setPasswordDialog = new FormSetPassword();

            if (_currentFileSystemDrive == null)
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            if (_currentFileName == null)
            {
                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "FileSystemImage files (*.fsi)|*.fsi"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    _currentFileName = saveFileDialog.FileName;
                else
                    return;
            }

            if (_currentFileName != null && setPasswordDialog.ShowDialog(this) == DialogResult.OK)
            {
                string password = setPasswordDialog.VerifiedPassword;
                SaveFileSystemImageToFile(_currentFileSystemDrive, _currentFileName, password);
            }
            MemoryHandler.RunGarbageCollect();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setPasswordDialog = new FormSetPassword();

            if (_currentFileSystemDrive == null)
            {
                MessageBox.Show("Nothing to save!");
                return;
            }

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "FileSystemImage files (*.fsi)|*.fsi"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                _currentFileName = saveFileDialog.FileName;
            else
                return;

            if (_currentFileName != null && setPasswordDialog.ShowDialog(this) == DialogResult.OK)
            {
                string password = setPasswordDialog.VerifiedPassword;
                SaveFileSystemImageToFile(_currentFileSystemDrive, _currentFileName, password);
                Log.Debug("Successfuly Saved file: {FileName}", saveFileDialog.FileName);
            }
            MemoryHandler.RunGarbageCollect();
        }

        private void SaveFileSystemImageToFile(FileSystemDrive fileSystemDrive, string path, string password)
        {
            var storageManagerProgress = new Progress<StorageManagerProgress>();
            LoadAndSaveProgressBar.Visible = true;
            storageManagerProgress.ProgressChanged += (s, e) =>
            {
                LoadAndSaveProgressBar.Value = e.ProgressPercentage;
                LoadAndSaveProgressInfoLabel.Text = e.Text;
            };

            saveAsToolStripMenuItem.Enabled = false;
            saveToolStripMenuItem.Enabled = false;

            Task.Run(async () =>
            {
                var settings = new StorageManagerSettings(true, Environment.ProcessorCount, true, password);
                var storageManager = new StorageManager(settings);

                bool success = await storageManager.SerializeObjectToFileAsync(fileSystemDrive, path, storageManagerProgress);

                OutcomeEventArgs outcomeEventArgs = success ? OutcomeEventArgs.Success : OutcomeEventArgs.Failure;
                SaveFileEventHandler onSaveComplete = HandleSaveFileComplete;

                BeginInvoke(onSaveComplete, this, outcomeEventArgs);
            });
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new FormAboutBox();
            aboutBox.ShowDialog(this);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderTreeView.Nodes.Clear();
            FileListDataGridView.DataSource = null;
            _currentFileSystemDrive = null;
            _currentFileName = null;
            DirectoryInfoDataLabel.Text = "";

            MemoryHandler.RunGarbageCollect();
        }

        private void FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
        }

        private void FolderTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //Update chile nodes
            TreeNode selectedNode = e.Node;
            var nodeTreversalStack = new Stack<string>();
            TreeNode rootNode = selectedNode;
            var directoryList = _currentFileSystemDrive.DirectoryList;

            nodeTreversalStack.Push(rootNode.Text);
            while (rootNode.Parent != null)
            {
                rootNode = rootNode.Parent;
                nodeTreversalStack.Push(rootNode.Text);
            }

            while (nodeTreversalStack.Count > 0)
            {
                string currentItem = nodeTreversalStack.Pop();
                for (int i = 0; i < directoryList.Count; i++)
                {
                    FileSystemDirectory dir = directoryList[i];
                    if (dir.Name == currentItem)
                    {
                        directoryList = dir.DirectoryList;
                        break;
                    }
                }
            }

            if (directoryList == null)
                return;

            TreeNode firstNode = selectedNode.FirstNode;
            while (firstNode != null)
            {
                if (firstNode.Nodes.Count == 0)
                {
                    FileSystemDirectory subDir = directoryList.SingleOrDefault(d => d.Name == firstNode.Text);
                    if (subDir != null && subDir.DirectoryList != null)
                    {
                        foreach (FileSystemDirectory fsd in subDir.DirectoryList)
                            firstNode.Nodes.Add(new TreeNode(fsd.Name));
                    }
                }

                firstNode = firstNode.NextNode;
            }
        }

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Update file list
            TreeNode selectedNode = e.Node;
            var fileList = GetFileSystemFileListFromNode(selectedNode, true);

            if (fileList == null && _currentFileSystemDrive.RootFileList != null && (_currentFileSystemDrive != null && selectedNode.Parent == null))
                fileList = _currentFileSystemDrive.RootFileList.ConvertAll(FileSystemFileWrapper.ConvertObject);

            FileListDataGridView.DataSource = fileList;
        }

        private List<FileSystemFileWrapper> GetFileSystemFileListFromNode(TreeNode selectedNode, bool setStatusBarInfo)
        {
            var directoryList = _currentFileSystemDrive.DirectoryList;
            List<FileSystemFileWrapper> fileSystemList = null;
            var nodeTreversalStack = new Stack<string>();
            TreeNode rootNode = selectedNode;

            nodeTreversalStack.Push(rootNode.Text);

            //Root node
            if (rootNode.Parent == null)
            {
                DirectoryInfoDataLabel.Text = GetRootDirectoryData(_currentFileSystemDrive);
                if (_currentFileSystemDrive.RootFileList == null)
                    _currentFileSystemDrive.RootFileList = new List<FileSystemFile>();
                return _currentFileSystemDrive.RootFileList.ConvertAll(FileSystemFileWrapper.ConvertObject);
            }

            while (rootNode.Parent != null)
            {
                rootNode = rootNode.Parent;
                nodeTreversalStack.Push(rootNode.Text);
            }

            nodeTreversalStack.Pop();

            while (nodeTreversalStack.Count > 0)
            {
                string currentItem = nodeTreversalStack.Pop();
                for (int i = 0; i < directoryList.Count; i++)
                {
                    FileSystemDirectory dir = directoryList[i];
                    if (dir.Name == currentItem)
                    {
                        if (nodeTreversalStack.Count == 0 && dir.FileList != null)
                            fileSystemList = dir.FileList.ConvertAll(FileSystemFileWrapper.ConvertObject);
                        directoryList = dir.DirectoryList;


                        if (setStatusBarInfo)
                            DirectoryInfoDataLabel.Text = GetFileSystemDirectoryData(dir);

                        break;
                    }
                }
            }

            return fileSystemList;
        }

        private string GetFileSystemDirectoryData(FileSystemDirectory dir)
        {
            return "Sub Directories: " + dir.SubDirectoriesTotal + " | Files: " + dir.FilesTotal + " | Total file size: " + GeneralConverters.FileSizeToStringFormater.ConvertFileSizeToString(dir.FileSizeTotal, 2);
        }

        private string GetRootDirectoryData(FileSystemDrive fileSystemDrive)
        {
            long directories = 0;
            long files = fileSystemDrive.RootFileList != null ? fileSystemDrive.RootFileList.Count : 0;
            long FileSizeTotal = fileSystemDrive.RootFileList != null ? fileSystemDrive.RootFileList.Sum(f => f.FileSize) : 0;

            foreach (FileSystemDirectory fileSystemDirectory in fileSystemDrive.DirectoryList)
            {
                directories += fileSystemDirectory.SubDirectoriesTotal + 1;
                files += fileSystemDirectory.FilesTotal;
                FileSizeTotal += fileSystemDirectory.FileSizeTotal;
            }

            return "Directories: " + directories + " | Files: " + files + " | Total file size: " + GeneralConverters.FileSizeToStringFormater.ConvertFileSizeToString(FileSizeTotal, 2);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode currentExpandedNode = FolderTreeView.SelectedNode;
            if (currentExpandedNode == null)
            {
                MessageBox.Show("No selected path found");
                return;
            }
            if (currentExpandedNode.Tag is ROOT_Identifyer && MessageBox.Show(this, "Update entire drive", "Are you sure you want to update the entire drive?", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            string path = buildPathFromTreeNode(currentExpandedNode);
            FileSystemDirectory fileSystemDirectory = GetFileSystemDirectoryFromPath(path);

            try
            {
                DoPartialTreeUpdateAsync(fileSystemDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
                Log.Error(ex, "DoPartialTreeUpdateAsync failed");
            }
        }

        private void DoPartialTreeUpdateAsync(FileSystemDirectory targetDirectory)
        {
            var storageManagerProgress = new Progress<StorageManagerProgress>();
            LoadAndSaveProgressBar.Visible = true;
            openToolStripMenuItem.Enabled = false;

            storageManagerProgress.ProgressChanged += (s, e) =>
            {
                LoadAndSaveProgressBar.Value = e.ProgressPercentage;
                LoadAndSaveProgressInfoLabel.Text = e.Text;
            };

            Task.Run(async () =>
            {
                _currentFileSystemDrive = await FileUtils.UpdateFolderAsync(_currentFileSystemDrive, targetDirectory, storageManagerProgress);
                Invoke(new EventHandler(HandleOpenFileComplete));
            });
        }

        private FileSystemDirectory GetFileSystemDirectoryFromPath(string path)
        {
            FileSystemDirectory fsDirectory = null;
            var directoryList = _currentFileSystemDrive.DirectoryList;
            var pathSegmentArray = path.Split('\\');

            foreach (string dir in pathSegmentArray)
            {
                if (string.IsNullOrEmpty(dir) || dir.EndsWith(":"))
                    continue;
                fsDirectory = directoryList.FirstOrDefault(d => d.Name == dir);
                if (fsDirectory == null)
                    return null;

                directoryList = fsDirectory.DirectoryList;
            }

            return fsDirectory;
        }

        private string buildPathFromTreeNode(TreeNode node)
        {
            var sb = new StringBuilder();
            while (node != null)
            {
                sb.Append("\\" + node.Text);
                node = node.Parent;
            }

            string path = sb.ToString().Trim('\\');
            path = StringManipulation.ReverseBySeparator(path, "\\");
            return path;
        }

        private struct ROOT_Identifyer
        {
        }

        #region FileListDataGridView Custom Render

        private const int CUSTOM_CONTENT_HEIGHT = 4;
        private readonly Color GridViewSelectionBorderColor = ColorTranslator.FromHtml("#7da2ce");
        private readonly Color gridViewGradientBackgroundColorStart = ColorTranslator.FromHtml("#b2e1ff");
        private readonly Color gridViewGradientBackgroundColorStop = ColorTranslator.FromHtml("#66b6fc");

        private void InitFileListDataGridView()
        {
            //Padding newPadding = new Padding(0, 1, 0, CUSTOM_CONTENT_HEIGHT);
            //this.FileListDataGridView.RowTemplate.DefaultCellStyle.Padding = newPadding;
            FileListDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            FileListDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            FileListDataGridView.RowTemplate.Height += CUSTOM_CONTENT_HEIGHT;
            FileListDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            FileListDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FileListDataGridView.RowPrePaint += FileListDataGridView_RowPrePaint;
            FileListDataGridView.RowPostPaint += FileListDataGridView_RowPostPaint;
        }

        private void FileListDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts &= ~DataGridViewPaintParts.Focus;

            if ((e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
            {
                // Calculate the bounds of the row.
                var rowBounds = new Rectangle(0, e.RowBounds.Top, FileListDataGridView.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) - FileListDataGridView.HorizontalScrollingOffset + 1, e.RowBounds.Height);

                // Paint the custom selection background.
                using (Brush backbrush = new LinearGradientBrush(rowBounds, gridViewGradientBackgroundColorStart, gridViewGradientBackgroundColorStop, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(backbrush, rowBounds);
                    var p = new Pen(backbrush, 1);
                    p.Color = GridViewSelectionBorderColor;
                    e.Graphics.DrawRectangle(p, rowBounds);
                }
            }
        }

        private void FileListDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            SolidBrush forebrush = null;
            try
            {
                forebrush = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected ? new SolidBrush(e.InheritedRowStyle.SelectionForeColor) : new SolidBrush(e.InheritedRowStyle.ForeColor);
            }
            finally
            {
                if (forebrush != null)
                    forebrush.Dispose();
            }
        }

        #endregion

        #region Menu Events

        private void driveInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentFileSystemDrive != null)
            {
                var driveInfoForm = new frmDriveInfo();
                driveInfoForm.SetFileSystemDrive(_currentFileSystemDrive);
                driveInfoForm.ShowDialog(this);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentFileSystemDrive == null)
            {
                MessageBox.Show("Please load a file system image first");
                return;
            }
            var searchDialog = new FrmSearch(_logger);
            searchDialog.SetFileSystemDrive(_currentFileSystemDrive);
            searchDialog.ShowDialog(this);
        }

        private void FileListDataGridView_MouseUp(object sender, MouseEventArgs e)
        {
            //if (FileListDataGridView.SelectedRows.Count == 0) return;

            if (e.Button == MouseButtons.Right)
            {
                var control = sender as Control;
                if (control != null) contextMenuStripFile.Show(control, e.X, e.Y);
            }
        }

        private void copyFileMenuItem_Click(object sender, EventArgs e)
        {
            if (FileListDataGridView.SelectedRows.Count == 0) return;
            var paths = new StringCollection();

            foreach (DataGridViewRow selectedRow in FileListDataGridView.SelectedRows)
            {
                var selectedFile = selectedRow.DataBoundItem as FileSystemFileWrapper;
                if (selectedFile != null && selectedFile.FilePath != null)
                {
                    paths.Add(selectedFile.FilePath);
                }
            }

            Clipboard.Clear();
            Clipboard.SetFileDropList(paths);
        }

        private void copyFilePathMenuItem_Click(object sender, EventArgs e)
        {
            if (FileListDataGridView.SelectedRows.Count == 0) return;
            var sb = new StringBuilder();

            foreach (DataGridViewRow selectedRow in FileListDataGridView.SelectedRows)
            {
                var selectedFile = selectedRow.DataBoundItem as FileSystemFileWrapper;
                if (selectedFile != null && selectedFile.FilePath != null)
                {
                    sb.AppendLine(selectedFile.FilePath);
                }
            }

            Clipboard.Clear();
            Clipboard.SetText(sb.ToString());
        }

        private void selectAllMenuItem_Click(object sender, EventArgs e)
        {
            FileListDataGridView.SelectAll();
        }

        private void createSFVFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileListDataGridView.SelectedRows.Count == 0) return;
            var fileSystemFileWrapper = (FileListDataGridView.SelectedRows[0].DataBoundItem as FileSystemFileWrapper);

            if (fileSystemFileWrapper == null)
            {
                MessageBox.Show("Unexprected error in createSFVFile. DataBoundItem is " + FileListDataGridView.SelectedRows[0].DataBoundItem.GetType());
                return;
            }

            // Root folder?
            string sfvFilename = fileSystemFileWrapper.FilePath ?? _currentFileSystemDrive.DriveLetter + fileSystemFileWrapper.Name;
            int fileExtensionDelimiter = sfvFilename.LastIndexOf('.');
            if (fileExtensionDelimiter > 0)
            {
                sfvFilename = sfvFilename.Substring(0, fileExtensionDelimiter) + ".sfv";
            }
            else
            {
                sfvFilename += ".sfv";
            }


            LoadAndSaveProgressBar.Visible = true;
            ChecksumFileGenerationLabel.Visible = true;
            Action<ChecksumProgress> checksumProgressLamdaFunction = progress =>
            {
                ChecksumFileGenerationLabel.Text = GeneralConverters.GetFileNameFromPath(progress.Text).PadLeft(5);
                LoadAndSaveProgressBar.Value = progress.TotalProgress;

                if (progress.Completed)
                {
                    LoadAndSaveProgressBar.Visible = false;
                    ChecksumFileGenerationLabel.Visible = false;
                    MessageBox.Show("Successfully created SFV file");
                }
            };

            var checksumFileGenerator = new ChecksumFileGenerator(Application.ProductName + " " + Application.ProductVersion, new Progress<ChecksumProgress>(checksumProgressLamdaFunction));
            var paths = new StringCollection();

            foreach (DataGridViewRow selectedRow in FileListDataGridView.SelectedRows)
            {
                var selectedFile = selectedRow.DataBoundItem as FileSystemFileWrapper;
                if (selectedFile != null && selectedFile.FilePath != null)
                {
                    paths.Add(selectedFile.FilePath);
                }
            }

            checksumFileGenerator.GenrateSFVFileAsync(paths, sfvFilename);
        }

        private void createMD5FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FileListDataGridView.SelectedRows.Count == 0) return;
            var fileSystemFileWrapper = (FileListDataGridView.SelectedRows[0].DataBoundItem as FileSystemFileWrapper);

            if (fileSystemFileWrapper == null)
            {
                MessageBox.Show("Unexprected error in createMD5File. DataBoundItem is " + FileListDataGridView.SelectedRows[0].DataBoundItem.GetType());
                return;
            }

            // Root folder?
            string sfvFilename = fileSystemFileWrapper.FilePath ?? _currentFileSystemDrive.DriveLetter + fileSystemFileWrapper.Name;
            int fileExtensionDelimiter = sfvFilename.LastIndexOf('.');
            if (fileExtensionDelimiter > 0)
            {
                sfvFilename = sfvFilename.Substring(0, fileExtensionDelimiter) + ".md5";
            }
            else
            {
                sfvFilename += ".md5";
            }


            LoadAndSaveProgressBar.Visible = true;
            ChecksumFileGenerationLabel.Visible = true;
            Action<ChecksumProgress> checksumProgressLamdaFunction = progress =>
            {
                ChecksumFileGenerationLabel.Text = GeneralConverters.GetFileNameFromPath(progress.Text).PadLeft(5);
                LoadAndSaveProgressBar.Value = progress.TotalProgress;

                if (progress.Completed)
                {
                    LoadAndSaveProgressBar.Visible = false;
                    ChecksumFileGenerationLabel.Visible = false;
                    MessageBox.Show("Successfully created MD5 file");
                }
            };

            var checksumFileGenerator = new ChecksumFileGenerator(Application.ProductName + " " + Application.ProductVersion, new Progress<ChecksumProgress>(checksumProgressLamdaFunction));
            var paths = new StringCollection();

            foreach (DataGridViewRow selectedRow in FileListDataGridView.SelectedRows)
            {
                var selectedFile = selectedRow.DataBoundItem as FileSystemFileWrapper;
                if (selectedFile != null && selectedFile.FilePath != null)
                {
                    paths.Add(selectedFile.FilePath);
                }
            }

            checksumFileGenerator.GenrateMD5FileAsync(paths, sfvFilename);
        }

        #endregion
    }
}