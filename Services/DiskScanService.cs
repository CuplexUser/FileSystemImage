using FileSystemImage.Repositories;
using System;
using System.Threading.Tasks;
using FileSystemImage.DataModels;
using FileSystemImage.FileSystem;
using FileSystemImage.Library.Delegates;
using FileSystemImage.Models;

namespace FileSystemImage.Services
{
    public class DiskScanService : ServiceBase, IDisposable
    {
        private readonly FileSystemImageRepository _imageRepository;

        public bool IsRunning { get; internal set; }

        public DiskScanService(FileSystemImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }



        public void Dispose()
        {
            _imageRepository.Dispose();
        }

        public async Task<FileSystemDrive> UpdateFolderAsync(DriveModel driveModel, DirectoryModel targetDirectory, ProgressCallback progressCallback)
        {
            using (var fileSystemWorker = new FileSystemWorker(driveModel.DriveLetter, progressCallback, null))
            {
                IsRunning = true;
                await fileSystemWorker.Start().ConfigureAwait(true);    
                IsRunning = false;
                return fileSystemWorker.FileSystemDrive;
            }

        }
        internal Task CreateFileSystemDriveData(string value, Action<double> progressUpdate, Action<DriveModel> setFileSystemDrive)
        {
            throw new NotImplementedException();
        }

        internal Task CancelCreateFileSystemDriveData()
        {
            throw new NotImplementedException();
        }

        internal void DeAllocateWorkerThread()
        {
            throw new NotImplementedException();
        }
    }
}
