using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemImage.FileTree
{
    public class TreeNode
    {
        #region Properties

        private readonly long key;
        private readonly string name;
        private readonly long parent;
        private List<long> _children;

        public string Name
        {
            get { return this.name; }
        }

        public long Parent
        {
            get { return this.parent; }
        }

        public List<long> Children
        {
            get
            {
                if(this._children == null)
                    this.PopulateChildNodes();
                return this._children;
            }
        }

        public long Key
        {
            get { return this.key; }
        }

        public bool IsFile { get; private set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public long FileSize { get; set; }

        public FileAttributes FileAttributes { get; set; }

        #endregion

        public TreeNode(bool isFile, string name, long key, long parent)
        {
            this.IsFile = isFile;
            this.name = name;
            this.key = key;
            this.parent = parent;
        }

        public void AddChild(TreeNode n, FileAllocationTable fat)
        {
            long treeNode = fat.AddTreeNode(n);

            //n.key = key;
            //n.parent = this.key;

            //if (this.next == 0)
            //{
            //    this.next = n.key;
            //    n.previous = this.key;
            //}
            //else
            //{
            //    TreeNode nextNode = fat.FileRecords[this.next] as TreeNode;

            //    this.next = n.key;
            //    n.previous = this.key;

            //    n.next = nextNode.key;
            //    nextNode.previous = n.key;
            //}
        }

        private void PopulateChildNodes()
        {
            this._children = new List<long>();
        }
    }
}