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
        public bool WriteCodeHierarchyFile()
        {
            BackupCopyPreviousCodeHierarchyFile();
            try {
                
                using (var writer = new System.IO.StreamWriter(GetCodeHierarchyFilePath))
                {
                    writer.Write(TreeNodeRecursive.TreeNodeToTextRecursive(treeViewHierarchy.Nodes[0]));
                }
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
            /*There is always only ONE root node because
            It makes drag-n-drop for parent nodes both easier and safer
            It makes add/remove nodes both easier and safer.
            */
            treeViewHierarchy.Nodes.Add("root","Code Hierarchy");
            string allText="";
            try
            {
                allText = System.IO.File.ReadAllText(GetCodeHierarchyFilePath);
            }
            catch (Exception ex)
            {
                textLog.Text += string.Join(" ", "Error reading code hierarchy file: ", GetCodeHierarchyFilePath, ex.Message);
            }
            if (allText == "") return;
            // Break the file into lines.
            string[] lines = allText.Split(
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
