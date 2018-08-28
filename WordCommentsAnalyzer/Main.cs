using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// see this: https://msdn.microsoft.com/en-us/library/office/bb463579.aspx
//https://msdn.microsoft.com/en-us/library/office/cc850832.aspx
// https://msdn.microsoft.com/en-us/library/documentformat.openxml.wordprocessing.comment(v=office.14).aspx
using Microsoft.Win32;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;

/*
TODO: Use async methods to improve saving code hierarchy for very large number of codes
*/

namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {




        /*Reg key and value names*/
        private const string app_reg_key = @"HKEY_LOCAL_MACHINE\SOFTWARE\ehsabd_WordCommentsAnalyzer";
        private const string working_dir_value_name = "wd";

        private const string CodeHierarchyFileName = "codehierarchy.txt";

        private const string NewHierarchyNodeName = "New Node";

       
        private string filteredBy = "";
        private string CodeHierarchyNodesText = "";
        private static string WorkingDirectory;
        private static int fullWidth = 0;

        private List<TreeNode> foundHierarchyNodes = new List<TreeNode>();
        private int foundHierarchyIndex = 0;

        public Main()
        {
            InitializeComponent();
        }

        private System.Windows.Forms.ToolTip ToolTip1;
        private void PrepareTooltips(System.Windows.Forms.Control parent)
        {
            ToolTip1 = new System.Windows.Forms.ToolTip();
            foreach (System.Windows.Forms.Control ctrl in parent.Controls)
            {
                if (ctrl is Button && ctrl.Tag is string)
                {
                    ctrl.MouseHover += new EventHandler(delegate (Object o, EventArgs a)
                    {
                        var btn = (System.Windows.Forms.Control)o;
                        ToolTip1.SetToolTip(btn, btn.Tag.ToString());
                    });
                }
                if (ctrl is Panel || ctrl is FlowLayoutPanel)
                {
                    PrepareTooltips(ctrl);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Main_Resize(new object(), new EventArgs());
            

            System.Reflection.Assembly thisAssem = typeof(WordCommentsAnalyzer.Program).Assembly;
            System.Reflection.AssemblyName thisAssemName = thisAssem.GetName();

            Version ver = thisAssemName.Version;
            this.Text = Regex.Replace(this.Text, @"\[.*\]", string.Format("[{0}]", ver));

            RegistryKey key = Application.UserAppDataRegistry;

            //var path = (string)Registry.GetValue(app_reg_key, working_dir_value_name,null);
            WorkingDirectory = (string)key.GetValue(working_dir_value_name);
            textWorkingDir.Text = WorkingDirectory ?? "";
            PrepareTooltips(this);
        }
        

        private void UpdateCodeBackground(string code)
        {
           
            var codeInListview = listViewCodes.Items.Find(code, false);
            if (codeInListview.Count() > 0)
            {
                CodeListHelper.SetListViewItemColor(codeInListview[0], IsCodeInHierarchy(code));
            }
        }

        private bool IsCodeInHierarchy(string code)
        {
            var codesInHierarchy = TreeNodeRecursive.GetTreeNodeTextsTopDownRecursive(treeViewHierarchy.Nodes[0]);
            return codesInHierarchy.Contains(code);
        }

        public void SetWorkingDirectory(string path)
        {

            WorkingDirectory = path;
            textWorkingDir.Text = WorkingDirectory ?? "";
            RegistryKey key = Application.UserAppDataRegistry;
            key.SetValue("wd", path);
        }
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                SetWorkingDirectory(path);
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            textLog.Text = "";
            textFilter.Text = "";
            textCode.Text = "";
            listViewRef.Items.Clear();
            if (!bwAnalyze.IsBusy)
            {
                bwAnalyze.RunWorkerAsync();
            }
        }




       
        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (!bwFilterCodes.IsBusy)
            {
                filteredBy = textFilter.Text;
                bwFilterCodes.RunWorkerAsync();
            }
        }







        private void checkRTL_CheckedChanged(object sender, EventArgs e)
        {
           
            var rootNode = treeViewHierarchy.Nodes.Count>0? treeViewHierarchy.Nodes[0]:null;
            treeViewHierarchy.Nodes.Clear();

            listViewCodes.BeginUpdate();
            treeViewHierarchy.BeginUpdate();
            listViewRef.BeginUpdate();

            var rtl = checkRTL.Checked ? RightToLeft.Yes : RightToLeft.No;

            listViewCodes.RightToLeftLayout = checkRTL.Checked;
            treeViewHierarchy.RightToLeftLayout = checkRTL.Checked;
            listViewRef.RightToLeftLayout = checkRTL.Checked;
            listViewCodes.RightToLeft = rtl;
            treeViewHierarchy.RightToLeft = rtl;
            listViewRef.RightToLeft = rtl;

            textCode.RightToLeft = rtl;
            if (rootNode != null)
            {
                treeViewHierarchy.Nodes.Add(rootNode);
            }
            treeViewHierarchy.ExpandAll();

            treeViewHierarchy.EndUpdate();
            listViewCodes.EndUpdate();
            listViewRef.EndUpdate();
        }






        private void buttonCopyComment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textCode.Text))
            {

                Clipboard.SetText(textCode.Text);
            }
        }

        private void buttonCopyRef_Click(object sender, EventArgs e)
        {
            var selItems = listViewRef.SelectedItems;
            if (selItems.Count > 0)
            {
                var textList = new List<string>();
                for (var i = 0; i < selItems.Count; i++)
                {
                    textList.Add(selItems[i].Text);
                }
                Clipboard.SetText(string.Join(Environment.NewLine, textList));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textComment_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAddHierarchyNode_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewHierarchy.SelectedNode;
            TreeNode addedNode;
            var code = NewHierarchyNodeName;
            var parent = selectedNode ?? treeViewHierarchy.Nodes[0];

            addedNode = AddNodeWithFullPathKey(parent, code);
            parent.Expand();

            BeginEditHierarchyNode(addedNode);
            addedNode.EnsureVisible();
            HandlePossibleChangeInHierarchy("");//code is not important here because it is NewHierarchyNodeName

        }

        private TreeNode AddNodeWithFullPathKey(TreeNode parent, string newNode)
        {
            var addedNode = parent.Nodes.Add(newNode);
            addedNode.Name = addedNode.FullPath;
            return addedNode;
        }

        private void BeginEditHierarchyNode(TreeNode node)
        {
            treeViewHierarchy.LabelEdit = true;
            node.BeginEdit();
        }


        private void treeViewHierarchy_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            treeViewHierarchy.LabelEdit = false;//we want to have full control over editing (only by edit button)
            if (e.Label == null) return;
            e.Node.Name = e.Node.Parent.FullPath + "\\" + e.Label; //change key to full path again
            HandlePossibleChangeInHierarchy(e.Label);
            if (Models.CodesDictionary.ContainsKey(e.Label))
            {
                MessageBox.Show(string.Format("Note that this code ({0}) also exists in the documents codes (i.e., Comments)",e.Label),
                    "Code in document codes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void treeViewHierarchy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (isTreeViewHierarchyDoingDragOver) return;

            textCode.Text = e.Node.Text;
            var recursiveChildNodeNames = TreeNodeRecursive.GetTreeNodeTextsTopDownRecursive(e.Node);
            var codeObjects = (from name in recursiveChildNodeNames
                               join pair in Models.CodesDictionary
                               on name equals pair.Key
                               select pair.Value);

            var dataExtractIds = codeObjects.SelectMany(c => c.DataExtractsIds).Distinct();
            labelRef.Text = Regex.Replace(labelRef.Text, @"\(.*\)", string.Format("({0})", dataExtractIds.Count()));
            
            UpdateRefListView(Models.DataExtractsQuery(dataExtractIds));

        }



        private void buttonEditHierarchyNode_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewHierarchy.SelectedNode;

            if (selectedNode != null)
            {
                BeginEditHierarchyNode(selectedNode);
            }
        }

        private void buttonDeleteHierarchyNode_Click(object sender, EventArgs e)
        {
            RemoveSelectedNode(treeViewHierarchy);
        }

        private void RemoveSelectedNode(TreeView treeView)
        {
            var selectedNode = treeView.SelectedNode;

            if (selectedNode != null)
            {
                if (selectedNode.Level == 0)
                {
                    MessageBox.Show("Can not remove the root node",
                        "Can not remove the root node", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (selectedNode.GetNodeCount(false) > 0)
                {
                    MessageBox.Show("The selected node has child nodes. Please remove the child nodes first.",
                        "Can not remove the node", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selectedNode.Remove();
                HandlePossibleChangeInHierarchy(selectedNode.Text);
               
            }
        }

        private void HandlePossibleChangeInHierarchy(string relevantCode)
        {
            UpdateCodeBackground(relevantCode);
            UpdateHierarchyNodeNumbers();
            WriteCodeHierarchyFile();

        }

        private void treeViewHierarchy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedNode(treeViewHierarchy);
            }
        }




        /// <summary>
        /// Currently this method only makes variants for the following variants of Yeh Letter:
        ///     Arabic Letter Yeh,
        ///     Arabic Letter Farsi Yeh,
        ///     Arabic Letter Farsi Yeh Isolated Form,
        ///     Arabic Letter Yeh Isolated Form
        /// </summary>
        /// <param name="str"></param>
        private string[] GetArabicPersianVariants(string str)
        {
            var yehChars = "\u064A\u06CC\uFBFC\uFEF1".ToCharArray();
            var variants =
                yehChars
                .Select(yc => Regex.Replace(str, string.Join("|", yehChars), yc.ToString()))
                .ToArray();
            return variants;
        }

        private void listViewCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCodes.SelectedItems.Count > 0)
            {
                var firstSel = listViewCodes.SelectedItems[0];
                var codeName = firstSel.Text;
                textCode.Text = codeName;
                var code = Models.CodesDictionary[codeName];
                UpdateRefListView(code.DataExtracts);

            }
        }

        private void UpdateRefListView(IEnumerable<Models.DataExtract> dataExtracts)
        {
            listViewRef.BeginUpdate();
            listViewRef.Items.Clear();
            imageListRef.Images.Clear();
            var imgInd = 0;
            //NOTE that we should set image size before adding the images
            var hasImage = dataExtracts.Any(dxt => (dxt.ImagePartIds?.Count() ?? 0) > 0);
            imageListRef.ImageSize = hasImage ? new Size(160, 100) : new Size(1, 1);
            listViewRef.LargeImageList = hasImage ? imageListRef : null;
            foreach (var dxt in dataExtracts)
            {
                if ((dxt.ImagePartIds?.Count() ?? 0) == 0)
                {
                    CreateItemFromDataExtract(dxt);
                }
                else
                {
                    foreach (var image in dxt.GetImages())
                    {
                        imageListRef.Images.Add(image);
                        CreateItemFromDataExtract(dxt, imgInd);
                        imgInd++;
                    }
                }
            }

            listViewRef.TileSize = hasImage ? new Size(listViewRef.Width - 30, 120) : new Size(listViewRef.Width - 30, 60);
            listViewRef.EndUpdate();

        }

        private ListViewItem CreateItemFromDataExtract(Models.DataExtract dxt, int imageIndex = -1)
        {
            var refText = dxt.ReferenceText;
            var codes = string.Join(", ", dxt.Codes);
            var fileName = dxt.File.Info.Name;
            ListViewItem item = null;
            if (string.IsNullOrEmpty(refText))
            {
                item = listViewRef.Items.Add(codes, imageIndex);
                item.SubItems.Add(fileName);
            }
            else
            {
                item = listViewRef.Items.Add(dxt.ReferenceText);
                item.SubItems.Add(codes);
                item.SubItems.Add(fileName);
            }
            return item;
        }

        private void timerAutoSaveHierarchy_Tick(object sender, EventArgs e)
        {
            if (treeViewHierarchy.Nodes.Count == 0) return;
            WriteCodeHierarchyFile();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (treeViewHierarchy.Nodes.Count == 0) return;
            WriteCodeHierarchyFile();
        }

        private void treeViewHierarchy_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (Models.CodeExists(e.Node.Text))
            {
                e.CancelEdit = true;
                MessageBox.Show("Can not edit codes from the documents. You may wrap this code in another, new node if necessary.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void bwAnalyze_DoWork(object sender, DoWorkEventArgs e)
        {
            AnalyzeFiles(WorkingDirectory, bwAnalyze);

        }

        private void bwAnalyze_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                Log(e.UserState.ToString());
            }
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bwAnalyze_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Log("Paragraphs Count: " + Models.ParagraphsCount);

            panelMiddle.Enabled = true;
            buttonVisualize.Enabled = true;
            filteredBy = textFilter.Text;
            /*
            NOTE that the codelist items should be cleared here before ReadCodeHierarchy
            because every addition in ReadCodeHierarchy causes the event of collection changed 
            and this event searches codelist to highlight organized codes and this event is not meant to 
            be raised when mass updating the code hierarchy
            */
            listViewCodes.Items.Clear();
            ReadCodeHierarchyFile();
            bwFilterCodes.RunWorkerAsync();
        }

        private void listViewRef_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void View_Changed(object sender, EventArgs e)
        {
            
            var listViewCodesW = listViewCodes.Width;
            var controls = new List<System.Windows.Forms.Control>();
            controls.Add(panelMiddle);
            controls.Add(splitterLeftMiddle);
            controls.Add(splitterMiddleRight);
            controls.Add(panelSidebar);
            controls.Add(panelWorkingDirBrowseAnalyze);
            foreach (var c in controls)
            {
                c.Visible = radioThreePanels.Checked;
            }
            Width = radioThreePanels.Checked ? fullWidth :
                Math.Max(listViewCodesW + listViewCodes.Margin.Right + listViewCodes.Margin.Left,260);

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (radioThreePanels.Checked)
            {
                fullWidth = Width;
            }
        }

        private void bwFilterCodes_DoWork(object sender, DoWorkEventArgs e)
        {
            var filterVariants = GetArabicPersianVariants(filteredBy);
            Models.FilteredCodeStatList = Models.CodeStatList
                .Where(c => filterVariants.Any(f => c.Code.Value.Contains(f, StringComparison.OrdinalIgnoreCase))
                // c.Code.Value.Contains(filteredBy, StringComparison.OrdinalIgnoreCase)
                ).ToList();
        }

        private void bwFilterCodes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredBy != textFilter.Text)
            {
                filteredBy = textFilter.Text;
                bwFilterCodes.RunWorkerAsync();
            }
            else {
                var codesInHierarchy = TreeNodeRecursive.GetTreeNodeTextsTopDownRecursive(treeViewHierarchy.Nodes[0]);
#if DEBUG
                
                Log( "Codes in hierarchy: " + Models.CodesDictionary.Keys.Intersect(codesInHierarchy).Count());
                
                
#endif
                CodeListHelper.UpdateCodesListView(ref listViewCodes, Models.FilteredCodeStatList,codesInHierarchy);
                labelNumberOfNodes.Text = string.Format("{0} Codes", listViewCodes.Items.Count);
            }
        }

        private void treeViewHierarchy_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsMouseOnEmptyArea(treeViewHierarchy, e.X, e.Y))
            {
                treeViewHierarchy.SelectedNode = null;
            }
        }

        private bool IsMouseOnEmptyArea(TreeView tv, int X, int Y)
        {

            Point targetPoint = tv.PointToClient(new Point(X, Y));
            var nodeAt = tv.GetNodeAt(targetPoint);
            return !(nodeAt?.Bounds.Contains(targetPoint) ?? false);
        }

        private void buttonSortTreeAZ_Click(object sender, EventArgs e)
        {
            treeViewHierarchy.Sort();
        }

        private void panelMiddleToolbar_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void treeViewHierarchy_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                // Point where the mouse is clicked.
                Point p = new Point(e.X, e.Y);

                // Get the node that the user has clicked.
                TreeNode node = treeViewHierarchy.GetNodeAt(p);
                if (node != null)
                {
                    menuItemMoveTo.Tag = node.Name;
                    menuItemMoveTo.Text = string.Format("Move {0}", node.Text);
                    deleteToolStripMenuItem.Tag = node;
                    deleteToolStripMenuItem.Text = string.Format("Delete {0}", node.Text);
                    editToolStripMenuItem.Tag = node;
                    editToolStripMenuItem.Text = string.Format("Edit {0}", node.Text);
                    addNodeToToolStripMenuItem.Tag = node;
                    addNodeToToolStripMenuItem.Text = string.Format("Add node to {0}", node.Text);
                    hierarchyContextMenu.Show(treeViewHierarchy, p);
                }
            }
        }

      

        private void menuItemMoveToDropDown_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clicked!");
        }

        private void menuItemMoveToTextBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("menuItemMoveToTextBox Clicked!");
        }

        private void menuItemMoveTo_Click(object sender, EventArgs e)
        {
            var nodeToMoveName = (string)menuItemMoveTo.Tag;
            var move = treeViewHierarchy.Nodes.Find(nodeToMoveName, true)[0];

            var moveTo = new FormMoveTo(menuItemMoveTo.Text, nodeToMoveName);
                
                var pt = Cursor.Position;
                var screenWidth = Screen.GetBounds(pt).Width;
                var screenHeight = Screen.GetBounds(pt).Height;
                moveTo.StartPosition = FormStartPosition.Manual;
                moveTo.Left = (pt.X + moveTo.Width) > screenWidth-50 ? screenWidth - moveTo.Width-50 : pt.X;
                moveTo.Top = (pt.Y + moveTo.Height) > screenHeight-50 ? screenHeight - moveTo.Height-50 : pt.Y;
                if (moveTo.ShowDialog(this) == DialogResult.OK) {
                var selectedNodeName = moveTo.treeViewMoveTo.SelectedNode?.Name;
                if (selectedNodeName == null)
                {
                    MessageBox.Show("You have not selected any nodes to move this node to", "No target node selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var targetNode = treeViewHierarchy.Nodes.Find(selectedNodeName, true)[0];
                 
                    MoveHierarchyNode(move, targetNode);
                };
                moveTo.Dispose();
        }
       
        public TreeNode GetHierarchyRootNode()
        {
            return treeViewHierarchy.Nodes[0];
        }

        private void menuItemMoveTo_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void textHierarchyFind_TextChanged(object sender, EventArgs e)
        {
             foundHierarchyNodes =
                TreeNodeRecursive.GetTreeNodesTopDownRecursive(treeViewHierarchy.Nodes[0])
                .Where(t => t.Level>0 && t.Text.Contains(textHierarchyFind.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            foundHierarchyIndex = 0;
            if (foundHierarchyNodes.Count > 0)
            {
                ShowCurrentFound();
            }
            else
            {
                labelFindHierarchyIndex.Text = "";
            }
            
        }
        private void ShowCurrentFound()
        {
            if (foundHierarchyNodes.Count > 0)
            {
                labelFindHierarchyIndex.Text = (foundHierarchyIndex+1) + "/" + foundHierarchyNodes.Count;
               var node = foundHierarchyNodes[foundHierarchyIndex];
                treeViewHierarchy.SelectedNode = node;
               
               if (node.Parent!=null && node.Parent.Nodes.Count < treeViewHierarchy.Height / 2 / node.Bounds.Height)
                {
                    treeViewHierarchy.TopNode = node.Parent;
                }
                else
                {
                    treeViewHierarchy.TopNode = node;
                }
                
                
            }
        }

        private void buttonFindHierarchyPrev_Click(object sender, EventArgs e)
        {
            if (foundHierarchyIndex > 0)
            {
                foundHierarchyIndex--;
                ShowCurrentFound();
            }
        }

        private void buttonFindHierarchyNext_Click(object sender, EventArgs e)
        {
            if (foundHierarchyIndex < foundHierarchyNodes.Count-1)
            {
                foundHierarchyIndex++;
                ShowCurrentFound();
            }
        }

        private void buttonVisualize_Click(object sender, EventArgs e)
        {
            (new VisualizeForm()).Show();
        }

        private void panelTop_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewHierarchy.SelectedNode = (TreeNode)deleteToolStripMenuItem.Tag;
            buttonDeleteHierarchyNode_Click(new object(), new EventArgs());
        }

        private void addNodeToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewHierarchy.SelectedNode = (TreeNode)addNodeToToolStripMenuItem.Tag;
            buttonAddHierarchyNode_Click(new object(), new EventArgs());
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeViewHierarchy.SelectedNode = (TreeNode)editToolStripMenuItem.Tag;
            buttonEditHierarchyNode_Click(new object(), new EventArgs());
        }

        private void linkCredits_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new Credits()).ShowDialog();
        }

        private void Log (string text)
        {
            textLog.Text += Environment.NewLine + text;
            textLog.Select(textLog.Text.Length, 0);
            textLog.ScrollToCaret();
        }
    }
}
