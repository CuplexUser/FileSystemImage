using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace FileSystemImage.DataModels
{
    [Serializable]
    [DataContract(Name = "FileSystemDrive")]
    public class FileSystemDrive
    {
        [DataMember(Name = "DriveLetter", Order = 1)]
        public string DriveLetter { get; set; }
        [DataMember(Name = "VolumeLabel", Order = 2)]
        public string VolumeLabel { get; set; }
        [DataMember(Name = "RootFileList", Order = 3)]
        public List<FileSystemFile> RootFileList { get; set; }
        [DataMember(Name = "DirectoryList", Order = 4)]
        public List<FileSystemDirectory> DirectoryList { get; set; }
        [DataMember(Name = "TotalSpace", Order = 5)]
        public Int64 TotalSpace { get; set; }
        [DataMember(Name = "FreeSpace", Order = 6)]
        public Int64 FreeSpace { get; set; }
        [DataMember(Name = "DriveType", Order = 7)]
        public DriveType DriveType { get; set; }
    }

    [Serializable]
    [DataContract]
    public struct FileTreeSummaryInfo
    {
        [DataMember(Name = "FileSizeTotal", Order = 1)]
        public long FileSizeTotal;

        [DataMember(Name = "FilesTotal", Order = 2)]
        public long FilesTotal;

        [DataMember(Name = "SubDirectoriesTotal", Order = 3)]
        public long SubDirectoriesTotal;

    }
}