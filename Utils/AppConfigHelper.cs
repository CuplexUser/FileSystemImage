using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemImage.Utils
{
    public class AppConfigHelper
    {
        public static string GetProductAndVersionString()
        {
            var appInfo = Assembly.GetExecutingAssembly().GetName();
            return string.Concat(appInfo.FullName, "-", appInfo.Version.ToString(4));
        }
    }
}
