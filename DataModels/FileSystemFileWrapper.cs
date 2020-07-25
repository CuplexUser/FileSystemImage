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
            _fileSystemFile = fileSystemFile;
        }

        public static FileSystemFileWrapper ConvertObject(FileSystemFile fileSystemFile)
        {
            return new FileSystemFileWrapper(fileSystemFile);
        }

        public string Name => _fileSystemFile.Name;

        public string FilePath => _fileSystemFile.FullName;

        public string FileSize => GeneralConverters.FormatFileSizeToString(_fileSystemFile.FileSize, 2);

        public string Attributes => GeneralConverters.FileAttributesToString(_fileSystemFile.FileAttributes);

        public string CreateDate => _fileSystemFile.CreateDate.ToString("yyyy-MM-dd");

        public string ModifiedDate => _fileSystemFile.ModifiedDate.ToString("yyyy-MM-dd");
    }
}