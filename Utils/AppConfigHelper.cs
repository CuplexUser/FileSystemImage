using System.Reflection;

namespace FileSystemImage.Utils
{
    public class AppConfigHelper
    {
        public static string GetProductAndVersionString()
        {
            var assemblyNameInfo = Assembly.GetCallingAssembly().GetName();
            string version = assemblyNameInfo.Version.ToString(3);
            return string.Concat(assemblyNameInfo.Name, " - ", version);
        }
    }
}
