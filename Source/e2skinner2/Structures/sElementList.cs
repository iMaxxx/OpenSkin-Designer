using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace OpenSkinDesigner.Structures
{
    class sElementList
    {
        public int Handle = 0;
        public int ParentHandle = 0;
        public TreeNode TreeNode = null;
        public XmlNode Node = null;

        public sElementList(int handle, int parentHandle, TreeNode treenode, XmlNode node)
        {
            Handle = handle;
            ParentHandle = parentHandle;
            TreeNode = treenode;
            Node = node;
        }
    }
}
