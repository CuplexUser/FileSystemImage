using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace FileSystemImage.FileSystem
{
    [Serializable]
    [DataContract]
    public class FileSystemDrive
    {
        [DataMember(Order = 1)]
        public string DriveLetter { get; set; }
        [DataMember(Order = 2)]
        public string VolumeLabel { get; set; }
        [DataMember(Order = 3)]
        public List<FileSystemFile> RootFileList { get; set; }
        [DataMember(Order = 4)]
        public List<FileSystemDirectory> DirectoryList { get; set; }
        [DataMember(Order = 5)]
        public Int64 TotalSpace { get; set; }
        [DataMember(Order = 6)]
        public Int64 FreeSpace { get; set; }
        [DataMember(Order = 7)]
        public DriveType DriveType { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FileSystemDirectory 
    {
        [DataMember(Order = 1)]
        public bool SubDirAccessDenied { get; set; }
        [DataMember(Order = 2)]
        public List<FileSystemDirectory> DirectoryList { get; set; }
        [DataMember(Order = 3)]
        public List<FileSystemFile> FileList { get; set; }
        [DataMember(Order = 4)]
        public string Name { get; set; }
        [DataMember(Order = 5)]
        public DateTime CreateDate { get; set; }
        [DataMember(Order = 6)]
        public DateTime ModifiedDate { get; set; }
        [DataMember(Order = 7)]
        public Int64 FileSizeTotal { get; set; }
        [DataMember(Order = 8)]
        public Int64 FilesTotal { get; set; }
        [DataMember(Order = 9)]
        public Int64 SubDirectoriesTotal { get; set; }
    }

    [Serializable]
    [DataContract]
    public class FileSystemFile  
    {
        [DataMember(Order = 1)]
        public Int64 FileSize { get; set; }
        [DataMember(Order = 2)]
        public FileAttributes FileAttributes { get; set; }
        [DataMember(Order = 3)]
        public string Name { get; set; }
        [DataMember(Order = 4)]
        public string FullName { get; set; }
        [DataMember(Order = 5)]
        public DateTime CreateDate { get; set; }
        [DataMember(Order = 6)]
        public DateTime ModifiedDate { get; set; }
        [DataMember(Order = 7)]
        public DateTime LastAccessDate { get; set; }
    }

    public struct FileTreeSummaryInfo
    {
        public long FileSizeTotal;
        public long FilesTotal;
        public long SubDirectoriesTotal;

    }
}