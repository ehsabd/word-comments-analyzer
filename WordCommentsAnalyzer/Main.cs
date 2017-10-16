using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
// see this: https://msdn.microsoft.com/en-us/library/office/bb463579.aspx
//https://msdn.microsoft.com/en-us/library/office/cc850832.aspx
// https://msdn.microsoft.com/en-us/library/documentformat.openxml.wordprocessing.comment(v=office.14).aspx
using Microsoft.Win32;
using System.IO;
using DocumentFormat.OpenXml;

namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {
        private class MyComment
        {
            public string Guid { get; set; }
            public string Text { get; set; }
            public string FileName { get; set; }
            public string ReferenceText { get; set; }
           
        }
        private const string app_reg_key = @"HKEY_LOCAL_MACHINE\SOFTWARE\ehsabd_WordCommentsAnalyzer";
        private const string working_dir_value_name = "wd";
        private List<MyComment> CommentsList = new List<MyComment>();
        private List<MyComment> FilteredComments = new List<MyComment>();
        private string filtered_by = "";
        private short numClickedNodes = 0;
        private List<short> ClickedNodesHistory = new List<short>();
        private int minutesPassed = 0;
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
            RegistryKey key = Application.UserAppDataRegistry;

            //var path = (string)Registry.GetValue(app_reg_key, working_dir_value_name,null);
            var path = (string)key.GetValue(working_dir_value_name);
            textWorkingDir.Text = path ?? "";
            PrepareTooltips(this);
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var path = folderBrowserDialog1.SelectedPath;
                textWorkingDir.Text = path;
                //Registry.SetValue(app_reg_key, "wd",path);
                RegistryKey key = Application.UserAppDataRegistry;
                key.SetValue("wd", path);
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            textLog.Text = "";
            System.IO.FileInfo[] files = null;
            // First, process all the files directly under this folder
            try
            {
                var wd = new DirectoryInfo(textWorkingDir.Text);
                files = wd.GetFiles("*.docx");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException ex)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.

            }
          
            if (files != null)
            {
                CommentsList = new List<MyComment>();
                foreach (System.IO.FileInfo fi in files)
                {
                    if (fi.Name.StartsWith("~")) continue;
                    try {
                        
                        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fi.FullName, false))
                        {
                            WordprocessingCommentsPart commentsPart = wordDoc.MainDocumentPart.WordprocessingCommentsPart;
                            
                            
                            if (commentsPart != null && commentsPart.Comments != null)
                            {
                                foreach (Comment comment in commentsPart.Comments.Elements<Comment>())
                                {
                                    var id = comment.Id.ToString();
                                    var commentRangeStarts = wordDoc.MainDocumentPart.Document.Descendants<CommentRangeStart>();

                                   var commentRangeStart = commentRangeStarts.Where(cr => (cr.Id.ToString() == id))
                                        .FirstOrDefault(); ;
                                    string ref_text = "";
                                    ref_text = GetReferenceText(commentRangeStart);
                                    CommentsList.Add(new MyComment
                                    {
                                        Guid=Guid.NewGuid().ToString(),
                                        Text = string.Join("|",
                                        comment
                                        .Descendants<Paragraph>()
                                        .Select(el=>el.InnerText)
                                        .Where(s => !string.IsNullOrWhiteSpace(s))
                                        ),
                                        FileName = fi.Name,
                                        ReferenceText=ref_text
                                    });

                                    
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        textLog.Text += Environment.NewLine + string.Format("{0}: {1}", fi.Name, ex.Message);
                    }
                }
                var culture = new System.Globalization.CultureInfo("fa-IR");
                CommentsList = CommentsList.OrderBy(c => c.Text, StringComparer.Create(culture, false)).ToList();

                UpdateFilteredComments();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FilteredComments = CommentsList.Where(c => c.Text.Contains(filtered_by)).ToList();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (filtered_by != textFilter.Text)
            {
                filtered_by = textFilter.Text;
                backgroundWorker1.RunWorkerAsync();
            }
            else {
                UpdateTree();
                
            }
        }
        private void UpdateTree()
        {
            treeView1.Nodes.Clear();
            treeView1.BeginUpdate();
            var treeNodes = new List<TreeNode>();
            for (var i= 0;i< FilteredComments.Count;i++)
            {
                var comment = FilteredComments[i];
  
                var subcomms = new string[0];
                
                   
                subcomms = comment.Text.Split('|');
                for (var headInd = 0; headInd < subcomms.Length; headInd++)
                {
                    var file = string.Format("[{0}]", comment.FileName);
                    var node = new TreeNode();
                    node.Name = comment.Guid;
                    for (var j = 0; j < subcomms.Length; j++)
                    {
                        if (j == headInd)
                        {
                            node.Text = subcomms[j] + file;
                            continue;
                        }
                        //  System.Diagnostics.Debug.WriteLine(subcomms[j]);
                        node.Nodes.Add(subcomms[j]);
                    }
                    treeNodes.Add(node);
                }
            }
            treeNodes = treeNodes.OrderBy(n => n.Text).ToList();
            foreach (var n in treeNodes)
            {
                treeView1.Nodes.Add(n);
            }

            treeView1.EndUpdate();
       
            labelNumberOfNodes.Text = string.Format("{0} Nodes", treeView1.Nodes.Count);
        }
        private void textFilter_TextChanged(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
            {
                UpdateFilteredComments();
            }
        }

        private void UpdateFilteredComments()
        {
            filtered_by = textFilter.Text;
            backgroundWorker1.RunWorkerAsync();
        }

        private void checkRTL_CheckedChanged(object sender, EventArgs e)
        {
            treeView1.RightToLeft = checkRTL.Checked? RightToLeft.Yes: RightToLeft.No;
            treeView1.RightToLeftLayout = checkRTL.Checked;
            textReference.RightToLeft = treeView1.RightToLeft;
        }

      
        public static string GetReferenceText(CommentRangeStart commentRangeStart)
        {
            string ref_text = "";
            if (commentRangeStart != null)
            {
                var elms = CommentRangeElements(commentRangeStart);
                foreach (var elm in elms)
                {
                    ref_text += elm.InnerText;
                    if (elm.GetType() == typeof(Paragraph))
                    {
                        ref_text += ' ';
                    }
                }
            }
            return ref_text;
        }

        public static IEnumerable<OpenXmlElement> CommentRangeElements(CommentRangeStart commentStart, OpenXmlElement searchStartElement=null)
        {
            List<OpenXmlElement> commentedNodes = new List<OpenXmlElement>();
            if (searchStartElement == null)
            {
                searchStartElement = commentStart;
            }
            else
            {
                commentedNodes.Add(searchStartElement);
            }
            var element = searchStartElement;
            var commentEndFound = false;
           
            while (true)
            {

                element = element.NextSibling();

                // check that the item exists
                if (element == null)
                {
                    break;
                }

                //check that the item is matching comment end
                if (IsMatchingCommentEnd(element, commentStart.Id.Value))
                {
                    commentEndFound = true;
                    break;
                }

                //check that there is a matching element in the current element's descendants
                var descendantsCommentEnd = element.Descendants<CommentRangeEnd>();
                if (descendantsCommentEnd != null)
                {
                    foreach (CommentRangeEnd rangeEndNode in descendantsCommentEnd)
                    {
                        if (IsMatchingCommentEnd(rangeEndNode, commentStart.Id.Value))
                        {
                            commentEndFound = true;
                            break;
                        }
                    }
                }
                
                
                commentedNodes.Add(element);
                if (commentEndFound)
                {
                    break;
                }
            }
            if (commentEndFound)
            {
                return commentedNodes;
            }
            else
            {
                return CommentRangeElements(commentStart, searchStartElement.Parent);
            }
        }
        public static bool IsMatchingCommentEnd(OpenXmlElement element, string commentId)
        {
            CommentRangeEnd commentEnd = element as CommentRangeEnd;
            if (commentEnd != null)
            {
                return commentEnd.Id == commentId;
            }
            return false;
        }

       

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            textComment.Text = System.Text.RegularExpressions.Regex.Replace(e.Node.Text, @"\[.*\]", "");
            var guid = e.Node.Name;
            System.Diagnostics.Debug.WriteLine(guid);
            var nodeNumber = 0;
            if (guid == "")
            {
                guid = e.Node.Parent.Name;
                nodeNumber = e.Node.Parent.Index + 1;
            }
            else
            {
                numClickedNodes++;
                e.Node.Expand();
                nodeNumber = e.Node.Index + 1;
            }
            labelNumberOfNodes.Text = string.Format("{0} / {1} Nodes", nodeNumber, treeView1.Nodes.Count);
            var comment = FilteredComments.Where(c => c.Guid == guid).FirstOrDefault();
            textReference.Text = comment.ReferenceText;
        }

        private void buttonCopyComment_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textComment.Text))
            {

                Clipboard.SetText(textComment.Text);
            }
        }

        private void buttonCopyRef_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textReference.Text))
            {
                Clipboard.SetText(textReference.Text);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}
