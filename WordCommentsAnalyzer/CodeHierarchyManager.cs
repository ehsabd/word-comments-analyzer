﻿using System;
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
            
            var text = TreeNodeRecursive.TreeNodeToTextTopDownRecursive(treeViewHierarchy.Nodes[0]);
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
                Log(string.Join(" ", "Error writing code hierarchy file: ", GetCodeHierarchyFilePath, ex.Message));
                return false;
            }
        }

        public void AddCodeHierarchyRootNode()
        {

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
            treeViewHierarchy.Nodes.Add("root", "Code Hierarchy");
            
            try
            {
                if (File.Exists(path))
                {
                    CodeHierarchyNodesText = System.IO.File.ReadAllText(path);
                }
            }
            catch (Exception ex)
            {
                Log ( string.Join(" ", "Error reading code hierarchy file: ", GetCodeHierarchyFilePath, ex.Message));
            }

            treeViewHierarchy.BeginUpdate();
            // Break the file into lines.
            string[] lines = CodeHierarchyNodesText.Split(
                new char[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, TreeNode> currentParents =
                    new Dictionary<int, TreeNode>();
            var codesInHierarchy = new System.Collections.ObjectModel.ObservableCollection<string>();

            try
            {
                if (CodeHierarchyNodesText != "")
                {
                    foreach (var l in lines)
                    {
                        var trimmed = l.TrimStart('\t');

                        int level = l.Length - trimmed.Length;

                        // Add the new node.
                        if (level == 0)
                            currentParents[level] = AddNodeWithFullPathKey( treeViewHierarchy.Nodes[0],trimmed);
                        else
                            currentParents[level] = AddNodeWithFullPathKey(currentParents[level - 1], trimmed);
                        codesInHierarchy.Add(trimmed);
                        
                        currentParents[level].EnsureVisible();
                    }
                }
            }
            catch (Exception ex)
            {
                Log(string.Join(" ", "Error converting code hierarchy file content to tree: ", ex.Message));
            }
            finally
            {
                treeViewHierarchy.EndUpdate();
                UpdateHierarchyNodeNumbers();
            }
        }
        

        public void UpdateHierarchyNodeNumbers()
        {
            var count = TreeNodeRecursive.GetTreeNodeTextsTopDownRecursive(treeViewHierarchy.Nodes[0]).Count();
            labelCodeHierarchy.Text = System.Text.RegularExpressions.Regex.Replace(labelCodeHierarchy.Text, @"\(.*\)", string.Format("({0})", count));

        }



    }
}
