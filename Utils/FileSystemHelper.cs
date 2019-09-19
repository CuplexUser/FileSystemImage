using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSystemImage.Utils
{
    public static class FileSystemHelper
    {
        internal const char NodeSeparator = '\\';
        public static string GetCorrectFullPath(TreeNode node)
        {
            Stack<string> pathStack = new Stack<string>();
            StringBuilder sbPath = new StringBuilder();

            TreeNode cursor = node;
            while (cursor != null)
            {
                string name = cursor.Text.Trim(NodeSeparator);
                pathStack.Push(NodeSeparator + name);
                cursor = cursor.Parent;
            }
            
            while (pathStack.Count>0)
            {
                sbPath.Append(pathStack.Pop());
            }

            return sbPath.ToString().TrimStart(NodeSeparator);
        }
    }
}