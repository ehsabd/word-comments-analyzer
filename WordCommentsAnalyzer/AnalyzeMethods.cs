using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            }catch (DirectoryNotFoundException ex)
            {
                bw?.ReportProgress(0, "The directory is not found. Please change the directory to a existing one, " + ex.Message);

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
                            var fileInfoKey = Models.AddFileInfo(fi);
                            ExtractDataFromWordFile(fileInfoKey);
                        }
                        catch (Exception ex)
                        {
                            errorLog = string.Format("{0}: {1}", fi.Name, ex.Message);
                        }
                    }
                    bw?.ReportProgress((i + 1) * 100 / files.Length, errorLog);

                }
                Models.MakeCodesArabicPersianCharactersUniform();
                Models.ComputeCodeStats();
                Models.SortCodeStatListByFrequency(textCulture.Text);

            }
        }



        public void ExtractDataFromWordFile(string fileInfoKey)
        {
            //This counter runs for every data extract in this file,
            //so the app supports around 2 billion data extracts per each file
            int thisFileDataCounter = 1;
            var fi = Models.FileInfosDictionary[fileInfoKey];
            using (FileStream fs = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fs, false))
            {
                var main = wordDoc.MainDocumentPart;
                var allComments = WordCommentsHelper.GetWordDocumentComments(main);
                foreach (Comment comment in allComments)
                {
                    var commentRangeEls = WordCommentsHelper.GetCommentRangeElements(main, comment.Id.Value);
                    var refText = WordCommentsHelper.GetElementsInnerText(commentRangeEls);
                    var innerImageDatas = commentRangeEls.SelectMany(
                        e => e.Descendants<DocumentFormat.OpenXml.Vml.ImageData>()
                        );
                    var imagesRelationshipIds = innerImageDatas.Select(d => d.RelationshipId.Value).ToList();

                    thisFileDataCounter++;
                    //NOTE that the first part of the following dataExtractId is needed to ensure unique ids
                    var dataExtractId = fileInfoKey + "_" + thisFileDataCounter;
                    var codes = WordCommentsHelper.ExtractCodesFromComment(comment);
                    Models.DataExtracts.Add(new Models.DataExtract
                    {
                        FileInfoKey = fileInfoKey,
                        Id = dataExtractId,
                        ReferenceText = refText,
                        ImagePartIds = imagesRelationshipIds,
                        Codes = codes
                    });
                    AddUpdateCodesDictionary(codes, dataExtractId);
                }
            }
        }

        public void AddUpdateCodesDictionary(List<string> codes, string dataExtractId)
        {
            foreach (var p in codes)
            {
                if (!Models.CodesDictionary.ContainsKey(p))
                {
                    var code = new Models.Code { Value = p, DataExtractsIds = new List<string>() };
                    Models.CodesDictionary[p] = code;
                }
                Models.CodesDictionary[p].DataExtractsIds.Add(dataExtractId);
            }
        }
        }
}
