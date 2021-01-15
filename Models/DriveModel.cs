using System;
using AutoMapper;
using System.Collections.Generic;
using System.IO;
using FileSystemImage.DataModels;

namespace FileSystemImage.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DriveModel
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
        /// Gets or sets the root file list.
        /// </summary>
        /// <value>
        /// The root file list.
        /// </value>
        public List<FileModel> RootFileList { get; set; }
        /// <summary>
        /// Gets or sets the directory list.
        /// </summary>
        /// <value>
        /// The directory list.
        /// </value>
        public List<DirectoryModel> DirectoryList { get; set; }
        /// <summary>
        /// Gets or sets the total space.
        /// </summary>
        /// <value>
        /// The total space.
        /// </value>
        public Int64 TotalSpace { get; set; }
        /// <summary>
        /// Gets or sets the free space.
        /// </summary>
        /// <value>
        /// The free space.
        /// </value>
        public Int64 FreeSpace { get; set; }
        /// <summary>
        /// Gets or sets the type of the drive.
        /// </summary>
        /// <value>
        /// The type of the drive.
        /// </value>
        public DriveType DriveType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public struct FileTreeSummaryInfoModel
        {
            /// <summary>
            /// The file size total
            /// </summary>
            public long FileSizeTotal;
            /// <summary>
            /// The files total
            /// </summary>
            public long FilesTotal;
            /// <summary>
            /// The sub directories total
            /// </summary>
            public long SubDirectoriesTotal;
        }

        /// <summary>
        /// Creates the mapping.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public static void CreateMapping(IProfileExpression expression)
        {
            expression.CreateMap<DriveModel, FileSystemDrive>().
                ForMember(s => s.DriveLetter, o => o.MapFrom(d => d.DriveLetter))
                .ForMember(s => s.VolumeLabel, o => o.MapFrom(d => d.VolumeLabel))
                .ForMember(s => s.TotalSpace, o => o.MapFrom(d => d.TotalSpace))
                .ForMember(s => s.FreeSpace, o => o.MapFrom(d => d.FreeSpace))
                .ForMember(s=>s.RootFileList, o=>o.MapFrom(d=>d.RootFileList))
                .ForMember(s => s.DirectoryList, o => o.MapFrom(d => d.DirectoryList))
                .ReverseMap();
        }
    }
}
