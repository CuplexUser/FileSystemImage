using AutoMapper;
using FileSystemImage.DataModels;

namespace FileSystemImage.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DriveInfoModel
    {
        /// <summary>
        /// Gets or sets the drive letter.
        /// </summary>
        /// <value>
        /// The drive letter.
        /// </value>
        public string DriveLetter { get; set; }
        /// <summary>
        /// Gets or sets the volume label.
        /// </summary>
        /// <value>
        /// The volume label.
        /// </value>
        public string VolumeLabel { get; set; }
        /// <summary>
        /// Gets or sets the type of the drive.
        /// </summary>
        /// <value>
        /// The type of the drive.
        /// </value>
        public string DriveType { get; set; }
        /// <summary>
        /// Gets or sets the free space.
        /// </summary>
        /// <value>
        /// The free space.
        /// </value>
        public string FreeSpace { get; set; }
        /// <summary>
        /// Gets or sets the total space.
        /// </summary>
        /// <value>
        /// The total space.
        /// </value>
        public string TotalSpace { get; set; }
        /// <summary>
        /// Gets or sets the root directory count.
        /// </summary>
        /// <value>
        /// The root directory count.
        /// </value>
        public string RootDirectoryCount { get; set; }
        /// <summary>
        /// Gets or sets the root file count.
        /// </summary>
        /// <value>
        /// The root file count.
        /// </value>
        public string RootFileCount { get; set; }


        /// <summary>
        /// Creates the mapping.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public static void CreateMapping(IProfileExpression expression)
        {
            expression.CreateMap<DriveInfoModel, FileSystemDriveInfo>().ReverseMap();
        }
    }
}
