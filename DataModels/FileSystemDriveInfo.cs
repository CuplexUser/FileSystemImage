using System.Runtime.Serialization;

namespace FileSystemImage.DataModels
{
    [DataContract]
    public class FileSystemDriveInfo
    {
        [DataMember(Name = "Drive Letter", Order = 1)]
        public string DriveLetter { get; set; }

        [DataMember(Name = "Volume Label", Order = 2)]
        public string VolumeLabel { get; set; }

        [DataMember(Name = "Drive Type", Order = 3)]
        public string DriveType { get; set; }

        [DataMember(Name = "Free Space", Order = 4)]
        public string FreeSpace { get; set; }

        [DataMember(Name = "Total Space", Order = 5)]
        public string TotalSpace { get; set; }

        [DataMember(Name = "Root Directory Count", Order = 6)]
        public string RootDirectoryCount { get; set; }

        [DataMember(Name = "Root File Count", Order = 7)]
        public string RootFileCount { get; set; }
    }
}