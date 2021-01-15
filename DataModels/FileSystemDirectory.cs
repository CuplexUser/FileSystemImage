using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FileSystemImage.DataModels
{
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
}