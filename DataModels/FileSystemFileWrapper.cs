using System;
using System.ComponentModel;
using FileSystemImage.FileSystem;
using GeneralToolkitLib.Converters;

namespace FileSystemImage.DataModels
{
    [DataObject]
    public class FileSystemFileWrapper
    {
        public FileSystemFileWrapper()
        {

        }

        public static FileSystemFileWrapper ConvertObject(FileSystemFile fileSystemFile)
        {
            var fsWrapper = new FileSystemFileWrapper()
            {
                Name = fileSystemFile.Name,
                FullPath = fileSystemFile.FullName,
                FileSize = GeneralConverters.FormatFileSizeToString(fileSystemFile.FileSize, 2),
                ModifiedDate = fileSystemFile.ModifiedDate.ToString("yyyy-MM-dd hh:mm:ss"),
                CreateDate = fileSystemFile.CreateDate.ToString("yyyy-MM-dd hh:mm:ss"),
                Attributes = GeneralConverters.FileAttributesToString(fileSystemFile.FileAttributes)
            };

            return fsWrapper;
        }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public string FileSize { get; set; }

        public string Attributes { get; set; }

        public string CreateDate { get; set; }

        public string ModifiedDate { get; set; }
    }
}