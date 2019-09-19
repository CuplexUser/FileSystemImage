using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemImage.FileTree
{
    public class TreeNode
    {
        #region Properties

        private List<long> _children;

        public string Name { get; }

        public long Parent { get; }

        public List<long> Children
        {
            get
            {
                if (_children == null)
                    PopulateChildNodes();
                return _children;
            }
        }

        public long Key { get; }

        public bool IsFile { get; private set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public long FileSize { get; set; }

        public FileAttributes FileAttributes { get; set; }

        #endregion

        public TreeNode(bool isFile, string name, long key, long parent)
        {
            IsFile = isFile;
            Name = name;
            Key = key;
            Parent = parent;
        }

        public void AddChild(TreeNode n, FileAllocationTable fat)
        {
            long treeNode = fat.AddTreeNode(n);
        }

        private void PopulateChildNodes()
        {
            _children = new List<long>();
        }
    }
}