using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystemImage
{
    public partial class FormFolderProperties : Form
    {
        private TreeNode _workingNode;
        public FormFolderProperties()
        {
            InitializeComponent();
        }

        private void FormFolderProperties_Load(object sender, EventArgs e)
        {
            grpBoxFolderProps.Text = _workingNode?.Text;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TreeNodeInit(TreeNode treeNode)
        {
            _workingNode = treeNode;
        }
    }
}
