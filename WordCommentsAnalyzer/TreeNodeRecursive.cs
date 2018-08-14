using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
namespace WordCommentsAnalyzer
{
    class TreeNodeRecursive
    {
        /* private string TreeViewToText(TreeView treeView)
       {
           var textList = new List<string>();
           foreach (TreeNode n in treeView.Nodes)
           {
               textList.Add(TreeNodeToTextRecursive(n));
           }
           return string.Join(Environment.NewLine, textList);
       }*/

        public static string TreeNodeToTextRecursive(TreeNode treeNode)
        {
            var textList = new List<string>();
            if (treeNode.Level > 0)
            {
                textList.Add(new String('\t', treeNode.Level-1) + treeNode.Text); // (-1) is because of having a root node
            }
            foreach (TreeNode tn in treeNode.Nodes)
            {
                textList.Add(TreeNodeToTextRecursive(tn));
            }
            return string.Join(Environment.NewLine, textList);
        }

        public static List<string> GetTreeNodeTextsRecursive(TreeNode treeNode)
        {
            var texts = new List<string>();
            texts.Add(treeNode.Text);
            foreach (TreeNode tn in treeNode.Nodes)
            {
                texts = texts.Union(GetTreeNodeTextsRecursive(tn)).ToList();
            }
            return texts;
        }

        public static List<TreeNode> GetTreeNodesRecursive(TreeNode treeNode)
        {
            var nodes = new List<TreeNode>();
            nodes.Add(treeNode);//No need to check for duplicates, the list is empty!
            foreach (TreeNode tn in treeNode.Nodes)
            {
                nodes = nodes.Union(GetTreeNodesRecursive(tn)).ToList();
            }
            return nodes;
        }
    }
}
