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

        private int checkCodeIndex = 0;

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

            Models.CodesInHierarchy.CollectionChanged +=
                new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
                    CodesInHierarchy_CollectionChanged);

            System.Reflection.Assembly thisAssem = typeof(WordCommentsAnalyzer.Program).Assembly;
            System.Reflection.AssemblyName thisAssemName = thisAssem.GetName();

            Version ver = thisAssemName.Version;
            this.Text = Regex.Replace(this.Text,@"\[.*\]",string.Format("[{0}]", ver));

            RegistryKey key = Application.UserAppDataRegistry;

            //var path = (string)Registry.GetValue(app_reg_key, working_dir_value_name,null);
            WorkingDirectory = (string)key.GetValue(working_dir_value_name);
            textWorkingDir.Text = WorkingDirectory ?? "";
            PrepareTooltips(this);
        }

        private void CodesInHierarchy_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Collection Changed");
            if (e.OldItems != null)
            {
                foreach (var item in e.OldItems)
                {
                    SetCodeBackground(item.ToString(), System.Drawing.Color.White);
                }
            }
            if (e.NewItems != null)
            {
                foreach (var item in e.NewItems)
                {
                    SetCodeBackground(item.ToString(), System.Drawing.Color.LightGoldenrodYellow);
                }
            }
        }

        private void CodesInView_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Collection Changed");
            if (e.OldItems != null)
            {
               /* foreach (var item in e.OldItems)
                {
                    SetCodeBackground(item.ToString(), System.Drawing.Color.White);
                }*/
            }
            if (e.NewItems != null)
            {
                /*foreach (var item in e.NewItems)
                {
                    SetCodeBackground(item.ToString(), System.Drawing.Color.LightGoldenrodYellow);
                }*/
            }
        }

        private void SetCodeBackground(string code,System.Drawing.Color color)
        {
            var found = listViewCodes.Items.Find(code,false);
            if (found.Count() > 0)
            {
                found[0].BackColor = color;
            }
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
            if (!bwAnalyze.IsBusy)
            {
                bwAnalyze.RunWorkerAsync();
            }
        }

      

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filteredBy != textFilter.Text)
            {
                filteredBy = textFilter.Text;
                bgwFilterCodes.RunWorkerAsync();
            }
            else {
                UpdateCodesListView();
                
            }
        }


        private void UpdateCodesListView()
        {
              listViewCodes.Items.Clear();
              listViewCodes.BeginUpdate();

              foreach (var cs in Models.FilteredCodeStatList)
              {
                  var code = cs.Code.Value;
                  var item = new ListViewItem(new string[] { code, cs.Frequency.ToString() });
                  item.Name = code;
                  item.BackColor = (
                      Models.SelectedCodes.Contains(code)) ?
                      System.Drawing.Color.Yellow 
                      : 
                      (
                      (Models.CodesInHierarchy.Contains(code))? 
                      System.Drawing.Color.LightGoldenrodYellow
                      :
                      System.Drawing.Color.White
                      );
                  listViewCodes.Items.Add(item);
              }

              listViewCodes.EndUpdate();

              labelNumberOfNodes.Text = string.Format("{0} Codes", listViewCodes.Items.Count);
        }
        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (!bgwFilterCodes.IsBusy)
            {
                filteredBy = textFilter.Text;
                bgwFilterCodes.RunWorkerAsync(); 
            }
        }

       

        

       

        private void checkRTL_CheckedChanged(object sender, EventArgs e)
        {
            var rtl = checkRTL.Checked ? RightToLeft.Yes : RightToLeft.No;
            listViewCodes.RightToLeft =rtl ;
            treeViewHierarchy.RightToLeftLayout = checkRTL.Checked;
            treeViewHierarchy.RightToLeft = rtl;
            treeViewHierarchy.ExpandAll();
            listViewRef.RightToLeft = rtl;
            textCode.RightToLeft = rtl;
            
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
            if (selItems.Count>0)
            {
                var textList = new List<string>();
                for (var i= 0;i < selItems.Count;i++)
                {
                    textList.Add(selItems[i].Text);
                }
                Clipboard.SetText(string.Join(Environment.NewLine,textList));
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
            if (selectedNode != null)
            {
                addedNode = selectedNode.Nodes.Add(code, code);
                selectedNode.Expand();
                
                EditHierarchyNode(addedNode);
            }
            
        }

        private void EditHierarchyNode(TreeNode node)
        {
            treeViewHierarchy.LabelEdit = true;
            node.BeginEdit();
        }


        private void treeViewHierarchy_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {      
            e.Node.Name = e.Label;//new text
            treeViewHierarchy.LabelEdit = false;//we want to have full control over editing (only by edit button)
        }

        private void treeViewHierarchy_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textCode.Text = e.Node.Name;
            var recursiveChildNodeNames = TreeNodeRecursive.GetTreeNodeNamesRecursive(e.Node);
            var codeObjects = (from name in recursiveChildNodeNames
                                  join pair in Models.CodesDictionary
                                  on name equals pair.Key
                                  select pair.Value);

            var dataExtractIds = codeObjects.SelectMany(c => c.DataExtractsIds).Distinct();

            var query = from id in dataExtractIds
                        join d in Models.DataExtracts on id equals d.Id
                        select d;

            UpdateRefListView(query.ToList());

        }

        

        private void buttonEditHierarchyNode_Click(object sender, EventArgs e)
        {
            var selectedNode = treeViewHierarchy.SelectedNode;

            if (selectedNode != null)
            {
                EditHierarchyNode(selectedNode);
            }
        }

        private void buttonDeleteHierarchyNode_Click(object sender, EventArgs e)
        {
            RemoveSelectedNode(treeViewHierarchy);
        }

        private void RemoveSelectedNode (TreeView treeView)
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
                Models.CodesInHierarchy.Remove(selectedNode.Text);
            }
        }

        

        private void treeViewHierarchy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                RemoveSelectedNode(treeViewHierarchy);
            }
        }


        private void bgwFilterCodes_DoWork(object sender, DoWorkEventArgs e)
        {
            Models.FilteredCodeStatList = Models.CodeStatList
                .Where(c=>
                        c.Code.Value.Contains(filteredBy, StringComparison.OrdinalIgnoreCase)
                ).ToList();

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
        
        private void UpdateRefListView(List<Models.DataExtract> dataExtracts)
        {
            listViewRef.Items.Clear();
            var maxLength = 0;
            var textWithMaxLength = "";
            foreach (var dxt in dataExtracts)
            {
                var item = listViewRef.Items.Add(dxt.ReferenceText);
                if (dxt.ReferenceText.Length > maxLength)
                {
                    maxLength = dxt.ReferenceText.Length;
                    textWithMaxLength = dxt.ReferenceText;
                }
                item.SubItems.Add(dxt.FileName);
                item.Name = dxt.Id;
            }
            labelRef.Text = Regex.Replace(labelRef.Text, @"\(.*\)", string.Format("({0})",dataExtracts.Count()));
            /*TODO this solution does not work, as listview always clips the text, even if the tile is large enough.
            I suggest using flow layout with auto creating text controls inside.
            if (maxLength == 0) return;
            var font = listViewRef.Font;
            Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            Graphics graphics = Graphics.FromImage(fakeImage);
            SizeF size = graphics.MeasureString(textWithMaxLength, font);
            var area = Convert.ToInt32(size.Height * size.Width);
            var tileW = 300;
            var tileH = area / tileW;
            listViewRef.TileSize = new Size(tileW, tileH);*/
            
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
            if (Models.CodeExists(e.Node.Name))
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
                textLog.Text += Environment.NewLine + e.UserState.ToString();
            }
            progressBar1.Value = e.ProgressPercentage;
        }

        private void bwAnalyze_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panelMiddle.Enabled = true;
            filteredBy = textFilter.Text;
            bgwFilterCodes.RunWorkerAsync();
            ReadCodeHierarchyFile();
        }
    }
}
