using System.Collections;

namespace FileSystemImage.FileTree
{
    public class FileSystemTree
    {
        //Storage for all tree nodes

        // Root node created on init
        private readonly TreeNode root;

        public FileSystemTree()
        {
            this.FileRecords = new FileAllocationTable();
            this.root = new TreeNode(false, "Root", 0, 0);
        }

        public TreeNode Root
        {
            get { return this.root; }
        }

        private FileAllocationTable FileRecords { get; }

        public byte[] ToArray()
        {
            byte[] result = new byte[10];

            return result;
        }

        public static FileSystemTree RestoreInstance(byte[] data)
        {
            FileSystemTree fileSystemTree = new FileSystemTree();
            return fileSystemTree;
        }
    }

    public class FileAllocationTable
    {
        private long cursor;

        public FileAllocationTable()
        {
            this.FileRecords = new Hashtable();
        }

        public Hashtable FileRecords { get; private set; }

        public long AddTreeNode(TreeNode node)
        {
            this.FileRecords.Add(this.cursor, node);
            return this.cursor++;
        }

        public void RemoveTreeNode(long key)
        {
            this.FileRecords.Remove(key);
        }
    }
}