using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Windows.Forms;
using System.IO;
namespace WordCommentsAnalyzer
{
    public partial class Main : Form
    {

        public void AnalyzeFiles(string workingDirectory, 
            System.ComponentModel.BackgroundWorker bw = null)
        {
            System.IO.FileInfo[] files = null;
            // First, process all the files directly under this folder
            try
            {
                var wd = new DirectoryInfo(workingDirectory);
                files = wd.GetFiles("*.docx");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException ex)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                bw?.ReportProgress(0, "Error getting directory info, " + ex.Message);
            }

            if (files != null)
            {

                Models.ClearData();
                for (var i = 0; i < files.Length; i++)
                {
                    string errorLog = null;
                    var fi = files[i];
                    if (!fi.Name.StartsWith("~") && !(fi.Name.ToLower() == CodeHierarchyFileName))
                    {

                        try
                        {
                            ExtractDataFromWordFile(fi);
                        }
                        catch (Exception ex)
                        {
                            errorLog = string.Format("{0}: {1}", fi.Name, ex.Message);
                        }
                    }
                    bw?.ReportProgress((i + 1) * 100 / files.Length, errorLog);

                }

                Models.ComputeCodeStats();
                Models.SortCodeStatListByFrequency(textCulture.Text);

            }
        }



        public void ExtractDataFromWordFile(FileInfo fi)
        {
            //This counter runs for every data extracts, so the app supports 2,147,483,647 - 1 data extracts
            int dataExtractCounter = 1;
            using (FileStream fs = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fs, false))
                {

                    var allComments = WordCommentsHelper.GetWordDocumentComments(wordDoc);
                            
                        foreach (Comment comment in allComments)
                        {
                            var id = comment.Id.ToString();  
                            var refText = WordCommentsHelper.GetReferenceText(wordDoc, id);

                            var dataExtractId = fi.Name.UTF8ToBase64Ext() +"_"+ dataExtractCounter;
                            Models.DataExtracts.Add(new Models.DataExtract
                            {
                                FileName = fi.Name,
                                Id = dataExtractId,
                                ReferenceText = refText
                            });

                            var codes = WordCommentsHelper.ExtractCodesFromComment(comment);
                            foreach (var p in codes)
                            {
                                
                                if (!Models.CodesDictionary.ContainsKey(p))
                                {
                                    var code = new Models.Code { Value = p , DataExtractsIds = new List<string>()};
                                    Models.CodesDictionary[p] = code;
                                }
                                Models.CodesDictionary[p].DataExtractsIds.Add(dataExtractId);
                            }

                            dataExtractCounter++;

                        }
                    
                }
            }
        }

        
    }
}
