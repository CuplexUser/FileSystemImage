using System.Collections;

namespace FileSystemImage.FileTree
{
    public class FileSystemTree
    {
        //Storage for all tree nodes

        // Root node created on init

        public FileSystemTree()
        {
            FileRecords = new FileAllocationTable();
            Root = new TreeNode(false, "Root", 0, 0);
        }

        public TreeNode Root { get; }

        private FileAllocationTable FileRecords { get; }

        public byte[] ToArray()
        {
            byte[] result = new byte[10];

            return result;
        }

        public static FileSystemTree RestoreInstance(byte[] data)
        {
            var fileSystemTree = new FileSystemTree();
            return fileSystemTree;
        }
    }

    public class FileAllocationTable
    {
        private long _cursor;

        public FileAllocationTable()
        {
            FileRecords = new Hashtable();
        }

        public Hashtable FileRecords { get; private set; }

        public long AddTreeNode(TreeNode node)
        {
            FileRecords.Add(_cursor, node);
            return _cursor++;
        }

        public void RemoveTreeNode(long key)
        {
            FileRecords.Remove(key);
        }
    }
}