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
        public string SelectedNodeName { get; set; }
        public FormMoveTo(string text)
        {
            InitializeComponent();
            this.Text = text;
        }

        private void FormMoveTo_Load(object sender, EventArgs e)
        {
       
        }

        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            
            var main = (Main)this.Owner;
            treeViewMoveTo.Nodes.Clear();
            if (textFilter.Text.Length < 3) return;
            var nodes = main.SearchCodeHierarchyFirstLevelNodesChildren(textFilter.Text);
            foreach (var n in nodes)
            {
                treeViewMoveTo.Nodes.Add((TreeNode)n.Clone());
            }

            treeViewMoveTo.ExpandAll();
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

        private void treeViewMoveTo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedNodeName = treeViewMoveTo.SelectedNode.Name;
        }



        // Returns the bounds of the specified node, including the region 
        // occupied by the node label and any node tag displayed.
        /*
        private Rectangle NodeBounds(TreeNode node)
        {
            // Set the return value to the normal node bounds.
            Rectangle bounds = node.Bounds;
            if (node.Tag != null)
            {
                // Retrieve a Graphics object from the TreeView handle
                // and use it to calculate the display width of the tag.
                Graphics g = treeViewMoveTo.CreateGraphics();
                int tagWidth = (int)g.MeasureString
                    (node.Tag.ToString(), tagFont).Width + 6;

                // Adjust the node bounds using the calculated value.
                bounds.Offset(tagWidth / 2, 0);
                bounds = Rectangle.Inflate(bounds, tagWidth / 2, 0);
                g.Dispose();
            }

            return bounds;

        }*/


    }
}
