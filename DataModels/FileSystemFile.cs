using System;
using System.IO;
using System.Runtime.Serialization;

namespace FileSystemImage.DataModels
{
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
}