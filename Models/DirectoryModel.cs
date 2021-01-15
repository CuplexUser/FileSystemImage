using AutoMapper;
using System;
using System.Collections.Generic;
using FileSystemImage.DataModels;

namespace FileSystemImage.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class DirectoryModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether [sub dir access denied].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [sub dir access denied]; otherwise, <c>false</c>.
        /// </value>
        public bool SubDirAccessDenied { get; set; }
        /// <summary>
        /// Gets or sets the directory list.
        /// </summary>
        /// <value>
        /// The directory list.
        /// </value>
        public List<DirectoryModel> DirectoryList { get; set; }
        /// <summary>
        /// Gets or sets the file list.
        /// </summary>
        /// <value>
        /// The file list.
        /// </value>
        public List<FileModel> FileList { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        /// <value>
        /// The modified date.
        /// </value>
        public DateTime ModifiedDate { get; set; }
        /// <summary>
        /// Gets or sets the file size total.
        /// </summary>
        /// <value>
        /// The file size total.
        /// </value>
        public Int64 FileSizeTotal { get; set; }
        /// <summary>
        /// Gets or sets the files total.
        /// </summary>
        /// <value>
        /// The files total.
        /// </value>
        public Int64 FilesTotal { get; set; }
        /// <summary>
        /// Gets or sets the sub directories total.
        /// </summary>
        /// <value>
        /// The sub directories total.
        /// </value>
        public Int64 SubDirectoriesTotal { get; set; }

        /// <summary>
        /// Creates the mapping.
        /// </summary>
        /// <param name="expression">The expression.</param>
        public static void CreateMapping(IProfileExpression expression)
        {
            expression.CreateMap<DirectoryModel, FileSystemDirectory>().ReverseMap();
        }
    }
}
