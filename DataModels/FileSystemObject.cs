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
    [DataContract(Name = "FileSystemDirectory")]
    public class FileSystemDirectory
    {
        [DataMember(Name = "SubDirAccessDenied", Order = 1)]
        public bool SubDirAccessDenied { get; set; }
        [DataMember(Name = "DirectoryList", Order = 2)]
        public List<FileSystemDirectory> DirectoryList { get; set; }
        [DataMember(Name = "FileList", Order = 3)]
        public List<FileSystemFile> FileList { get; set; }
        [DataMember(Name = "Name", Order = 4)]
        public string Name { get; set; }
        [DataMember(Name = "CreateDate", Order = 5)]
        public DateTime CreateDate { get; set; }
        [DataMember(Name = "ModifiedDate", Order = 6)]
        public DateTime ModifiedDate { get; set; }
        [DataMember(Name = "FileSizeTotal", Order = 7)]
        public Int64 FileSizeTotal { get; set; }
        [DataMember(Name = "FilesTotal", Order = 8)]
        public Int64 FilesTotal { get; set; }
        [DataMember(Name = "SubDirectoriesTotal", Order = 9)]
        public Int64 SubDirectoriesTotal { get; set; }
    }

    [Serializable]
    [DataContract(Name = "FileSystemFile")]
    public class FileSystemFile
    {
        [DataMember(Name = "FileSize", Order = 1)]
        public Int64 FileSize { get; set; }
        [DataMember(Name = "FileAttributes", Order = 2)]
        public FileAttributes FileAttributes { get; set; }
        [DataMember(Name = "Name", Order = 3)]
        public string Name { get; set; }
        [DataMember(Name = "FullName", Order = 4)]
        public string FullName { get; set; }
        [DataMember(Name = "CreateDate", Order = 5)]
        public DateTime CreateDate { get; set; }
        [DataMember(Name = "ModifiedDate", Order = 6)]
        public DateTime ModifiedDate { get; set; }
        [DataMember(Name = "LastAccessDate", Order = 7)]
        public DateTime LastAccessDate { get; set; }
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