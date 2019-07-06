using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemImage.FileSystem;
using FileSystemImage.Utils;
using System.Data.Linq;

namespace FileSystemImage.FileTree
{
    public class TreeSearch
    {
        private readonly string _driveLetter;
        private readonly FileSystemDirectory _root;
        private bool _ignoreCase;
        private bool _includeFolderNames;
        private Regex _regularExpression;
        private string[] _folderSequenceArray = null;

        public TreeSearch(FileSystemDrive fileSystemDrive)
        {
            _root = new FileSystemDirectory { DirectoryList = fileSystemDrive.DirectoryList, FileList = fileSystemDrive.RootFileList };
            _driveLetter = fileSystemDrive.DriveLetter.Replace("\\", "");
        }

        /// <summary>Perform a Search in the virtual file system</summary>
        /// <param name="searchString">The search string.</param>
        /// <param name="isRegex">isRegexp defines if the search string should be interpreted and validated as a regex search pattern without modifications.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <param name="includeFolderNames">if set to <c>true</c> [include folder names].</param>
        /// <returns></returns>
        public async Task<List<TreeSearchResult>> Search(string searchString, bool isRegex, bool ignoreCase, bool includeFolderNames)
        {
            List<TreeSearchResult> searchRes = null;
            _ignoreCase = ignoreCase;
            _includeFolderNames = includeFolderNames;

            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentException("Search string must be defined", nameof(searchString));
            }

            if (_includeFolderNames)
            {
                _folderSequenceArray = searchString.Split('\\');
                if (_folderSequenceArray.Length == 0 && string.IsNullOrEmpty(_folderSequenceArray[0]))
                {
                    throw new ArgumentException("Search string is not valid", nameof(searchString));
                }
            }

            // If isRegular expression only match on fileName when includeFolderNames is false
            // When includeFolderNames is true match on inputs like "Windows\System32\drivers\etc\hosts" where pattern must be sequentially matched and stored to eliminate multiple equivalent recursive matches or searching beyond the area of possible matches.

            if (isRegex)
            {

                if (_includeFolderNames)
                {

                }

                if (!IsValidRegex(searchString))
                {
                    throw new ArgumentException(@"Invalid regular expression syntax", nameof(searchString));
                }



            }
            else
            {
                //searchString = Regex.Escape(searchString);
                searchString = WildcardRegExpConverter.WildcardToRegex(searchString, out var error);

                if (!string.IsNullOrEmpty(error))
                {
                    throw new ArgumentException(error, new Exception("WildcardRegExpConverter.WildcardToRegex was unable to generate a regexp pattern from search string"));
                }

            }

            _regularExpression = ignoreCase ? new Regex(searchString, RegexOptions.IgnoreCase) : new Regex(searchString);

            searchRes = await SearchAsync(searchString, includeFolderNames, _root, _driveLetter, 0);
            return searchRes;
        }

        private async Task<List<TreeSearchResult>> SearchAsync(string searchString, bool includeFolderNames, FileSystemDirectory rootDirectory, string currentPath, int depth)
        {
            var searchRes = new List<TreeSearchResult>();

            if (includeFolderNames && depth >= _folderSequenceArray.Length)
            {
                System.Data.Linq.
                if (_folderSequenceArray.)   
            }

            if (rootDirectory.FileList != null)
            {
                foreach (FileSystemFile fileSystemFile in rootDirectory.FileList)
                {
                    if (_regularExpression.IsMatch(fileSystemFile.Name))
                        searchRes.Add(new TreeSearchResult(fileSystemFile, currentPath));
                }
            }

            if (rootDirectory.DirectoryList != null)
            {
                foreach (FileSystemDirectory fsd in rootDirectory.DirectoryList)
                {
                    if (includeFolderNames &&  depth>=_folderSequenceArray.Length) 
                    {
                        //searchRes.Add(new TreeSearchResult());
                    }

                    //if (includeFolderNames && _regularExpression.IsMatch(fsd.Name

                    var recursiveResult = await SearchAsync(searchString, includeFolderNames, fsd, currentPath + "\\" + fsd.Name, depth + 1);
                    if (recursiveResult.Count > 0)
                        searchRes.AddRange(recursiveResult);
                }
            }

            return searchRes;
        }

        private static bool IsValidRegex(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return false;

            try
            {
                // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                Regex.Match("", pattern);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }
    }

    public class TreeSearchResult
    {
        public TreeSearchResult(FileSystemFile fileSystemFile, string path)
        {
            file = fileSystemFile;
            this.Path = path;
        }

        public FileSystemFile file { get; }
        public string Path { get; }

        public override string ToString()
        {
            return Path + "\\" + file.Name;
        }
    }


}