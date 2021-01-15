using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FileSystemImage.DataModels;
using FileSystemImage.Library.Delegates;
using Serilog;

namespace FileSystemImage.FileSystem
{
        public class FileSystemWorker : IDisposable
        {
            private const int PROGRESS_UPDATE_INTERVAL = 100; //10 times a second
            private const int MAX_THREADS = 8;
            private readonly string _driveName;
            private readonly FileDataReturnCallback _fileDataReturnCallback;
            private readonly ProgressCallback _progressCallback;            
            private double _currentProgress;
            private double _maxProgress;
            private bool _runThMain;

            public bool TaskIsRunning { get; private set; }

            public FileSystemWorker(string driveName, ProgressCallback progressCallback, FileDataReturnCallback fileDataReturnCallback)
            {
                _driveName = driveName;
                _progressCallback = progressCallback;
                _fileDataReturnCallback = fileDataReturnCallback;                

            }

            private Task ThProgressMonitor(CancellationToken token)
            {
                return Task.Factory.StartNew(() =>
                {
                    while (_runThMain)
                    {
                        if (_progressCallback != null && _maxProgress > 0)
                            _progressCallback.Invoke(_currentProgress / _maxProgress);



                        //_taskSynchronizer.AutoResetEvent.WaitOne(100);

                    }

                    if (_progressCallback != null)
                        _progressCallback.Invoke(1);

                }, token);
            }

            public FileSystemDrive FileSystemDrive { get; private set; }

            private void ThMain()
            {
                FileSystemDrive = null;
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
                    _maxProgress = GetDirectoryCount(rootDir, 0, 4);
                    //_taskSynchronizer.AutoResetEvent.Set();

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
                            Task t = Task.Factory.StartNew(() => fileSystemDrive.DirectoryList.Add(GetFileSystemDirectory(dir, 0, 2)));
                            awaitTasksList.Add(t);
                        }

                        while (awaitTasksList.Count >= MAX_THREADS)
                        {
                            Task awaitTask = awaitTasksList.First();
                            awaitTask.Wait();
                            awaitTasksList.Remove(awaitTask);
                        }

                        //_taskSynchronizer.AutoResetEvent.Set();
                    }

                    Task.WaitAll(awaitTasksList.ToArray());
                }

                FileSystemDrive = fileSystemDrive;
                //_taskSynchronizer.AutoResetEvent.Set();
                _fileDataReturnCallback?.Invoke(fileSystemDrive);

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
                    Log.Error(ex, "Error in FileSystemWorker.GetDirectoryCount() : {Message}", ex.Message);
                }

                return count;
            }

            public async Task<bool> Start()
            {
                if (_runThMain)
                    return false;

                _runThMain = true;

                
                var token = new CancellationToken(false);
                Task mainTask = Task.Factory.StartNew(ThMain, token); 
                await mainTask;

                //_taskSynchronizer.UpdateTask = ThProgressMonitor(//_taskSynchronizer.CancelToken);
                ////_taskSynchronizer.UpdateTask.Start();
                //_taskSynchronizer.AutoResetEvent.Set();

              //  await //_taskSynchronizer.MainTask;

                return true;
            }

            public bool Stop()
            {
                return false;
              
            }

            public void Dispose()
            {
                

                //_taskSynchronizer.Dispose();
            }
        }
   
}