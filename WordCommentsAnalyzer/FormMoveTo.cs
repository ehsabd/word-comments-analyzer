using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCommentsAnalyzer
{
    public partial class FormMoveTo : Form
    {
        private string nodeToMoveName { get; set; }
        public string SelectedNodeName { get; set; }
        public FormMoveTo(string text, string nodeToMoveName)
        {
            InitializeComponent();
            this.Text = text;
            this.nodeToMoveName = nodeToMoveName;
        }

        private void FormMoveTo_Load(object sender, EventArgs e)
        {
       
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            
            var main = (Main)this.Owner;
            treeViewMoveTo.Nodes.Clear();
            if (textFilter.Text.Length < 2) return;
            var filterBy = textFilter.Text;
            var hierarchyRoot = main.GetHierarchyRootNode();
            treeViewMoveTo.Nodes.Add((TreeNode)hierarchyRoot.Clone());
            var nodes =
                TreeNodeRecursive.GetTreeNodesTopDownRecursive(treeViewMoveTo.Nodes[0]);


          
            var sortedByLevel =  new Dictionary<int, List<TreeNode>>();
            foreach (var n in nodes)
            {
                var level = n.Level;
                if (!sortedByLevel.ContainsKey(n.Level))
                {
                    sortedByLevel.Add(level, new List<TreeNode>());
                }
                    sortedByLevel[level].Add(n); 
            }

            var maxLevel = sortedByLevel.Max(pair => pair.Key);

            //Prunning the tree (Bottom-Up)
            for (var lv=maxLevel; lv >= 0; lv--)
                {
                    for (var i = sortedByLevel[lv].Count-1; i >=0; i--)
                    {
                        var node = sortedByLevel[lv][i];
                        //NOTE That we do not include nodes that starts with the name (i.e., full path) of the node we are moving (i.e., its decendants)
                        if (
                        node.Name.StartsWith(nodeToMoveName, StringComparison.OrdinalIgnoreCase)
                        || // Also we must prune nodes that niether match to our filter nor have any children
                        !node.Text.Contains(filterBy, StringComparison.OrdinalIgnoreCase)
                            && node.Nodes.Count == 0
                        )
                        {
                            RemoveNodeWithName(node.Name);
                            sortedByLevel[lv].RemoveAt(i);
                            
                            
                        }
                       
                    }
                }

            treeViewMoveTo.ExpandAll();
            
        }
        private void RemoveNodeWithName(string name)
        {
            var found = treeViewMoveTo.Nodes.Find(name, true);
            found[0].Remove();
        }
        // Draws a node.
        private void treeViewMoveTo_DrawNode(
            object sender, DrawTreeNodeEventArgs e)
        {
            var g = e.Graphics;
            
            // Draw the background and node text for a selected node.
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.DrawDefault = true;
                return; //TODO: remove the code below
                // Draw the background of the selected node. The NodeBounds
                // method makes the highlight rectangle large enough to
                // include the text of a node tag, if one is present.
                g.FillRectangle(Brushes.Green,e.Bounds );//NodeBounds(e.Node));

                // Retrieve the node font. If the node font has not been set,
                // use the TreeView font.
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                // Draw the node text.
                g.DrawString(e.Node.Text, nodeFont, Brushes.White,
                    Rectangle.Inflate(e.Bounds, 0, 0));
            }

            else
            {
                var textOffset = 6; //This is for the plus/minus sign
                // Retrieve the node font. If the node font has not been set,
                // use the TreeView font.
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;

                var ind = e.Node.Text.IndexOf(textFilter.Text);
                if (ind > -1)
                {
                    int beforeWidth = (int)g.MeasureString(e.Node.Text.Substring(0,ind), nodeFont).Width;
                    int highlightWidth = (int)g.MeasureString(textFilter.Text, nodeFont).Width;
                    int alltextWidth = (int)g.MeasureString(e.Node.Text, nodeFont).Width;
                    var bounds = Rectangle.Inflate(e.Bounds, 0, 0);
                    bounds.Width = highlightWidth;
                    bounds.Offset(textOffset, 0);
                    if (ArabicPersianTextHelper.IsTextArabicOrPersian(e.Node.Text)){
                        bounds.Offset(alltextWidth - beforeWidth-highlightWidth, 0);
                    }
                    else
                    {
                        bounds.Offset(beforeWidth, 0);
                    }
                    g.FillRectangle(Brushes.Yellow, bounds);//NodeBounds(e.Node));

                }

                // Draw the node text.
                var textRect = Rectangle.Inflate(e.Bounds, textOffset/2, 0);
                textRect.Offset(textOffset, 0);
                g.DrawString(e.Node.Text, nodeFont, Brushes.Black, textRect
                    );
            }
            
        }

    }
}
