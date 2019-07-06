using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeneralToolkitLib.Storage.Models;
using Serilog;

namespace FileSystemImage.FileSystem
{
    public delegate void ProgressCallback(double percentComplete);
    public delegate void FileDataReturnCallback(FileSystemDrive fileSystemDrive);

    public static class FileUtils
    {
        private static FileSystemWorker _fileSystemWorker;

        public static bool IsRunning
        {
            get
            {
                if (_fileSystemWorker == null)
                    return false;
                return _fileSystemWorker.TaskIsRunning;
            }
        }

        public static bool CreateFileSystemDriveData(string driveName, ProgressCallback progressCallback, FileDataReturnCallback fileDataReturnCallback)
        {
            if (_fileSystemWorker == null)
            {
                _fileSystemWorker = new FileSystemWorker(driveName, progressCallback, fileDataReturnCallback);
                _fileSystemWorker.Start();
                return true;
            }
            return false;
        }

        public static void CancelCreateFileSystemDriveData()
        {
            if (_fileSystemWorker != null)
            {
                _fileSystemWorker.Stop();
                _fileSystemWorker = null;
                GC.Collect();
            }
        }

        public static async Task<FileSystemDrive> UpdateFolderAsync(FileSystemDrive fileSystemDrive, FileSystemDirectory targetDirectory, IProgress<StorageManagerProgress> progress)
        {
            return await Task.Run(() => UpdateFolder(fileSystemDrive, targetDirectory));
        }

        private static FileSystemDrive UpdateFolder(FileSystemDrive fileSystemDrive, FileSystemDirectory targetDirectory)
        {
            return fileSystemDrive;
        }

        public static void DeAllocateWorkerThread()
        {
            CancelCreateFileSystemDriveData();
        }

        private class FileSystemWorker
        {
            private const int PROGRESS_UPDATE_INTERVAL = 100; //10 times a second
            private const int MAX_THREADS = 4;
            private readonly string _driveName;
            private readonly FileDataReturnCallback _fileDataReturnCallback;
            private readonly ProgressCallback _progressCallback;
            private readonly Thread _progressMonitorThread;
            private readonly Thread _workerThread;
            private readonly ManualResetEvent progressManualResetEvent;
            private double _currentProgress;
            private double _maxProgress;
            private bool _runThMain;
            public bool TaskIsRunning { get; private set; }

            public FileSystemWorker(string driveName, ProgressCallback progressCallback, FileDataReturnCallback fileDataReturnCallback)
            {
                _driveName = driveName;
                _progressCallback = progressCallback;
                _fileDataReturnCallback = fileDataReturnCallback;
                _workerThread = new Thread(ThMain);
                _progressMonitorThread = new Thread(ThProgressMonitor);
                progressManualResetEvent = new ManualResetEvent(true);
            }

            private void ThProgressMonitor()
            {
                while (_runThMain)
                {
                    if (_progressCallback != null && _maxProgress > 0)
                        _progressCallback.Invoke(_currentProgress/_maxProgress);

                    progressManualResetEvent.WaitOne(PROGRESS_UPDATE_INTERVAL);
                }
            }

            private void ThMain()
            {
                FileSystemDrive fileSystemDrive = new FileSystemDrive();
                var driveInfoArr = DriveInfo.GetDrives();
                DriveInfo driveInfo = null;
                TaskIsRunning = true;

                try
                {
                    foreach (DriveInfo di in driveInfoArr)
                    {
                        if (di.Name == _driveName)
                        {
                            driveInfo = di;
                            break;
                        }
                    }

                    if (driveInfo != null)
                    {
                        fileSystemDrive.VolumeLabel = driveInfo.VolumeLabel;
                        fileSystemDrive.DriveLetter = driveInfo.Name;
                        fileSystemDrive.DriveType = driveInfo.DriveType;
                        fileSystemDrive.FreeSpace = driveInfo.AvailableFreeSpace;
                        fileSystemDrive.TotalSpace = driveInfo.TotalSize;
                    }
                    else
                        fileSystemDrive = null;
                }
                catch
                {
                    fileSystemDrive = null;
                }

                if (fileSystemDrive != null)
                {
                    DirectoryInfo rootDir = driveInfo.RootDirectory;
                    fileSystemDrive.RootFileList = new List<FileSystemFile>();
                    fileSystemDrive.DirectoryList = new List<FileSystemDirectory>();

                    foreach (FileInfo file in rootDir.GetFiles())
                        fileSystemDrive.RootFileList.Add(new FileSystemFile
                        {
                            CreateDate = file.CreationTime,
                            FileSize = file.Length,
                            FileAttributes = file.Attributes,
                            ModifiedDate = file.LastWriteTime,
                            Name = file.Name,
                            FullName = fileSystemDrive.DriveLetter + file.Name
                        });

                    //Set progress data
                    _maxProgress = GetDirectoryCount(rootDir, 0, 2);

                    var rootDirectories = rootDir.GetDirectories();
                    var rootDirectoriesQueue = new Queue<DirectoryInfo>(rootDirectories);
                    var awaitTasksList = new List<Task>();

                    while (rootDirectoriesQueue.Count > 0)
                    {
                        if (!_runThMain)
                            break;

                        for (int i = 0; i < MAX_THREADS; i++)
                        {
                            if (rootDirectoriesQueue.Count == 0 || awaitTasksList.Count >= MAX_THREADS)
                                break;

                            DirectoryInfo dir = rootDirectoriesQueue.Dequeue();
                            Task t = Task.Run(() => fileSystemDrive.DirectoryList.Add(GetFileSystemDirectory(dir, 0, 2)));
                            awaitTasksList.Add(t);
                        }

                        while (awaitTasksList.Count >= MAX_THREADS)
                        {
                            Task awaitTask = awaitTasksList.First();
                            awaitTask.Wait();
                            awaitTasksList.Remove(awaitTask);
                        }
                    }

                    Task.WaitAll(awaitTasksList.ToArray());
                }

                progressManualResetEvent.Set();
                if (_fileDataReturnCallback != null)
                    _fileDataReturnCallback.Invoke(fileSystemDrive);

                TaskIsRunning = false;
            }

            private FileSystemDirectory GetFileSystemDirectory(DirectoryInfo rootDirectoryInfo, int level, int maxLevelToUpdateProgress)
            {
                FileSystemDirectory fileSystemDirectory = new FileSystemDirectory
                {
                    Name = rootDirectoryInfo.Name,
                    CreateDate = rootDirectoryInfo.CreationTime,
                    ModifiedDate = rootDirectoryInfo.LastWriteTime
                };

                if (!_runThMain)
                    return fileSystemDirectory;

                try
                {
                    var fileInfoArr = rootDirectoryInfo.GetFiles();
                    fileSystemDirectory.FilesTotal = fileInfoArr.Length;
                    if (fileInfoArr.Length > 0)
                    {
                        fileSystemDirectory.FileList = new List<FileSystemFile>();
                        foreach (FileInfo file in fileInfoArr)
                        {
                            fileSystemDirectory.FileList.Add(new FileSystemFile
                            {
                                Name = file.Name,
                                FullName = file.FullName,
                                FileSize = file.Length,
                                FileAttributes = file.Attributes,
                                CreateDate = file.CreationTime,
                                ModifiedDate = file.LastWriteTime,
                                LastAccessDate = file.LastAccessTime
                            });
                            fileSystemDirectory.FileSizeTotal += file.Length;
                        }
                    }

                    var subDirArr = new DirectoryInfo(rootDirectoryInfo.FullName).GetDirectories().Where(dir => !dir.Attributes.HasFlag(FileAttributes.ReparsePoint)).ToArray();
                    fileSystemDirectory.SubDirectoriesTotal = subDirArr.Length;
                    if (subDirArr.Length > 0)
                    {
                        fileSystemDirectory.DirectoryList = new List<FileSystemDirectory>();
                        foreach (DirectoryInfo dir in subDirArr)
                        {
                            if (level <= maxLevelToUpdateProgress)
                                _currentProgress++;

                            //if (!dir.Attributes.HasFlag(FileAttributes.Directory) || dir.Attributes.HasFlag(FileAttributes.ReparsePoint))
                            //    continue;

                            FileSystemDirectory subDirectory = GetFileSystemDirectory(dir, level + 1, maxLevelToUpdateProgress);
                            fileSystemDirectory.FileSizeTotal += subDirectory.FileSizeTotal;
                            fileSystemDirectory.SubDirectoriesTotal += subDirectory.SubDirectoriesTotal;
                            fileSystemDirectory.FilesTotal += subDirectory.FilesTotal;

                            fileSystemDirectory.DirectoryList.Add(subDirectory);
                        }
                    }
                }
                catch
                {
                    fileSystemDirectory.SubDirAccessDenied = true;
                }

                return fileSystemDirectory;
            }

            private int GetDirectoryCount(DirectoryInfo rootDirectoryInfo, int level, int maxLevel)
            {
                int count = 0;

                if (level > maxLevel)
                    return 0;

                try
                {
                    var subDirArr = rootDirectoryInfo.GetDirectories();
                    foreach (DirectoryInfo dir in subDirArr)
                    {
                        if (!dir.Attributes.HasFlag(FileAttributes.Directory) || dir.Attributes.HasFlag(FileAttributes.ReparsePoint))
                            continue;

                        count++;
                        count += GetDirectoryCount(dir, level + 1, maxLevel);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error in FileSystemWorker.GetDirectoryCount() : {Message}", ex.Message );
                }

                return count;
            }

            public void Start()
            {
                _runThMain = true;
                _workerThread.Start();
                _progressMonitorThread.Start();
            }

            public void Stop()
            {
                _runThMain = false;
            }
        }
    }
}