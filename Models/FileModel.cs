using System.ComponentModel;
using AutoMapper;
using FileSystemImage.DataModels;
using GeneralToolkitLib.Converters;

namespace FileSystemImage.Models
{
    [DataObject]
    public class FileModel
    {
        public FileModel()
        {

        }

        public static FileModel ConvertObject(FileSystemFile fileSystemFile)
        {
            var fsWrapper = new FileModel()
            {
                Name = fileSystemFile.Name,
                FullPath = fileSystemFile.FullName,
                FileSize = fileSystemFile.FileSize,
                FileSizeParsed = GeneralConverters.FormatFileSizeToString(fileSystemFile.FileSize, 2),
                ModifiedDate = fileSystemFile.ModifiedDate.ToString("yyyy-MM-dd hh:mm:ss"),
                CreateDate = fileSystemFile.CreateDate.ToString("yyyy-MM-dd hh:mm:ss"),
                Attributes = GeneralConverters.FileAttributesToString(fileSystemFile.FileAttributes)
            };

            return fsWrapper;
        }

        public string Name { get; set; }

        public string FullPath { get; set; }

        public long FileSize { get; set; }

        public string FileSizeParsed { get; set; }

        public string Attributes { get; set; }

        public string CreateDate { get; set; }

        public string ModifiedDate { get; set; }


        public static void CreateMapping(IProfileExpression expression) => expression.CreateMap<FileSystemFile, FileModel>()
                                                                                     .ConvertUsing(x => ConvertObject(x));

    }
}