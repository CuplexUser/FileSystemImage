using AutoMapper;
using FileSystemImage.Models;

namespace FileSystemImage.Library.AutomapperProfile
{
    public class FileSysImgMapperProfile: Profile
    {
        public FileSysImgMapperProfile() 
        {
            FileModel.CreateMapping(this);
            DriveModel.CreateMapping(this);
            DirectoryModel.CreateMapping(this);
            DriveInfoModel.CreateMapping(this);
            
        }          
    }
}
