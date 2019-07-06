using System;
using FileSystemImage.FileSystem;
using GeneralToolkitLib.Converters;

namespace FileSystemImage.DataModels
{
    public class FileSystemFileWrapper
    {
        private readonly FileSystemFile _fileSystemFile;
        public FileSystemFileWrapper(FileSystemFile fileSystemFile)
        {
            
            this._fileSystemFile = fileSystemFile;
        }

        public static FileSystemFileWrapper ConvertObject(FileSystemFile fileSystemFile)
        {
            return new FileSystemFileWrapper(fileSystemFile);
        }

        public string Name
        {
            get { return this._fileSystemFile.Name; }
        }

        public string FilePath
        {
            get { return this._fileSystemFile.FullName; }
        }

        public string FileSize
        {
            get { return GeneralConverters.FileSizeToStringFormater.ConvertFileSizeToString(this._fileSystemFile.FileSize, 2); }
        }

        public string Attributes
        {
            get { return GeneralConverters.FileAttributesToString(this._fileSystemFile.FileAttributes); }
        }

        public string CreateDate
        {
            get { return this._fileSystemFile.CreateDate.ToString("yyyy-mm-dd"); }
        }

        public string ModifiedDate
        {
            get { return this._fileSystemFile.ModifiedDate.ToString("yyyy-mm-dd"); }
        }
    }
}