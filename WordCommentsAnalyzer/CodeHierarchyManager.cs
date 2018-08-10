using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {
        public string GetCodeHierarchyFilePath
        {
            get
            {
                return  WorkingDirectory + @"\" + CodeHierarchyFileName;
            }
        }
        public void BackupCopyPreviousCodeHierarchyFile()
        {
            var BackUpDir = WorkingDirectory + @"\Backups";
            if (!Directory.Exists(BackUpDir))
            {
                Directory.CreateDirectory(BackUpDir);
            }
            if (System.IO.File.Exists(GetCodeHierarchyFilePath))
            {
                var lastWriteTime = File.GetLastWriteTime(GetCodeHierarchyFilePath);
                var backupFilePath = string.Format(@"{0}\codehierarchy{1:yyyy_MM_dd_HH_mm}.txt", BackUpDir, lastWriteTime);
                if (File.Exists(backupFilePath)) { //We don't take backups for less than one minutes
                    return;
                   }
                File.Copy(GetCodeHierarchyFilePath,
                    backupFilePath);
            }
        }
        //NOTE this method returns true when no changes, but the true/false value is not currently used. If it were to use in future, the more suitable variable is a status type
        public bool WriteCodeHierarchyFile()
        {
            
            var text = TreeNodeRecursive.TreeNodeToTextRecursive(treeViewHierarchy.Nodes[0]);
            if (text== CodeHierarchyNodesText) //no changes
            {
                return true;
            }
           
            BackupCopyPreviousCodeHierarchyFile();
            try {
                
                using (var writer = new System.IO.StreamWriter(GetCodeHierarchyFilePath))
                {
                    writer.Write(text);
                }
                CodeHierarchyNodesText = text;
                return true;
            }
            catch (Exception ex)
            {
                textLog.Text += string.Join(" ", "Error writing code hierarchy file: ", GetCodeHierarchyFilePath, ex.Message);
                return false;
            }
        }

        /*An adaptation from http://csharphelper.com/blog/2014/09/load-a-treeview-from-a-tab-delimited-file-in-c/
            */
        public void ReadCodeHierarchyFile()
        {
            treeViewHierarchy.Nodes.Clear();
            var path = GetCodeHierarchyFilePath;
            CodeHierarchyNodesText = "";
            /*There is always only ONE root node because
            It makes drag-n-drop for parent nodes both easier and safer
            It makes add/remove nodes both easier and safer.
            */
            treeViewHierarchy.Nodes.Add("root","Code Hierarchy");
            if (!File.Exists(path)) return;
            try
            {
                CodeHierarchyNodesText = System.IO.File.ReadAllText(path);
                
            }
            catch (Exception ex)
            {
                textLog.Text += string.Join(" ", "Error reading code hierarchy file: ", GetCodeHierarchyFilePath, ex.Message);
            }
            if (CodeHierarchyNodesText == "") return;
            // Break the file into lines.
            string[] lines = CodeHierarchyNodesText.Split(
                new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);
            
            Dictionary<int, TreeNode> currentParents =
                    new Dictionary<int, TreeNode>();
            try {
                foreach (var l in lines)
                {
                    var trimmed = l.TrimStart('\t');

                    int level = l.Length - trimmed.Length;

                    // Add the new node.
                    if (level == 0)
                        currentParents[level] = treeViewHierarchy.Nodes[0].Nodes.Add(trimmed, trimmed);//both key and text equals to the code string
                    else
                        currentParents[level] = currentParents[level - 1].Nodes.Add(trimmed, trimmed);//both key and text equals to the code string
                    Models.CodesInHierarchy.Add(trimmed);
                    currentParents[level].EnsureVisible();
                }
            }
            catch (Exception ex)
            {
                textLog.Text += string.Join(" ", "Error converting code hierarchy file content to tree: ", ex.Message);
            }

        }

      

    }
}
