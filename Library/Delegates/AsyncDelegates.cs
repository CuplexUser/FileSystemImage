using FileSystemImage.DataModels;

namespace FileSystemImage.Library.Delegates
{
    public delegate void AsyncThreadExecutionCallbackMethod(object result);
    public delegate void AsyncThreadExecutionMethod();

    public delegate void ProgressCallback(double percentComplete);
    public delegate void FileDataReturnCallback(FileSystemDrive fileSystemDrive);
}
