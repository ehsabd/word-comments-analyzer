using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {
        private static bool isTreeViewHierarchyDoingDragOver = false;

        private void listViewCodes_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // We copy the dragged node when the left mouse button is used. We don't want to remove codes
            if (e.Button == MouseButtons.Left)
            {
                var d = new DataObject();
                d.SetData(typeof(ListViewItem), e.Item);
                var lvi = (ListViewItem)(e.Item);
                d.SetData(lvi.Text);
                DoDragDrop(d, DragDropEffects.Copy);
            }
        }

        private void treeViewComments_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // We copy the dragged node when the left mouse button is used. We don't want to remove comments
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        private void treeViewHierarchy_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used. 
            // We facilitate move between hierarchy code nodes.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void treeViewHierarchy_DragEnter(object sender, DragEventArgs e)
        {
            // System.Diagnostics.Debug.WriteLine("treeViewHierarchy_DragEnter");
            e.Effect = e.AllowedEffect;
        }

        private void treeViewHierarchy_DragOver(object sender, DragEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("treeViewHierarchy_DragOver");
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeViewHierarchy.PointToClient(new Point(e.X, e.Y));
            // Get the node at the mouse position.
            var nodeAt = treeViewHierarchy.GetNodeAt(targetPoint);
            //The IsMouseOnEmptyArea is just for reuse and readibility. I recognize that we already have the node
            //and we do this twice
            if (IsMouseOnEmptyArea(treeViewHierarchy, e.X, e.Y)) { 
                treeViewHierarchy.SelectedNode = null;
            }
            else
            {
                isTreeViewHierarchyDoingDragOver = true;
                treeViewHierarchy.SelectedNode = nodeAt;
                isTreeViewHierarchyDoingDragOver = false;
            }

        }

        private void treeViewHierarchy_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeViewHierarchy.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeViewHierarchy.GetNodeAt(targetPoint);
            if (IsMouseOnEmptyArea(treeViewHierarchy,e.X,e.Y))
            {
              var result =  MessageBox.Show("You dropped the code into an empty area. Do you want to drop the code into the root node ('Code Hierarchy')?","Drop to the root?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    targetNode = treeViewHierarchy.Nodes[0];
                }
                else return;
            }
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (draggedNode != null) //i.e., if it is of TreeNode type so a MOVE
            {
                if (e.Effect == DragDropEffects.Move)
                    MoveHierarchyNode(draggedNode, targetNode);
            }
            else //it is a new item from the listview
            {
                var draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                if (draggedItem != null)
                {
                    var text = draggedItem.Text;
                    var node = new TreeNode { Name = text, Text = text };
                    if (AddNonDuplicateNode(targetNode, node)) {
                        HandlePossibleChangeInHierarchy(text);
                    }

                }
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private bool AddNonDuplicateNode(TreeNode targetNode, TreeNode newNode)
        {
            if (targetNode.Text == newNode.Text)
            {
                MessageBox.Show("Can not append a code to itself", "Can not add", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            foreach (TreeNode n in targetNode.Nodes) //immediate children of the targetnode
            {
                if (n.Text == newNode.Text)
                {
                    MessageBox.Show("This code exists in the immediate children of the target node", "Can not add", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            } 


            targetNode.Nodes.Add(newNode);
            newNode.Name = newNode.FullPath;
            targetNode.Expand();
            return true;
            
            
            
        }

        private void MoveHierarchyNode(TreeNode move, TreeNode targetNode)
        {
            // Confirm that the node we want to move to is not the going-to-moved node or its descendant.
            // NOTE that we need this in addition to duplicate check because it only checks for text duplicates in the
            // immediate children of the node 
            if (!move.Equals(targetNode) && !ContainsNode(move, targetNode))
            {
                //We clone the node for both copy and move because we do not know in advance whether it 
                //is duplicate or not (this will be determined in AddNonDuplicateNode)
                //then we remove it if it wasn't duplicate 

                var result = AddNonDuplicateNode(targetNode, (TreeNode)move.Clone());

                if (result)
                {
                    move.Remove();
                }
            }
        }

    }
}
