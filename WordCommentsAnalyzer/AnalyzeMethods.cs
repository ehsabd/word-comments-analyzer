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
#if DEBUG
                var sw = System.Diagnostics.Stopwatch.StartNew();
                var m0 = GC.GetTotalMemory(false);
#endif

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

#if DEBUG
                sw.Stop();
                System.Diagnostics.Debug.WriteLine("Analysis time (ms): " + sw.ElapsedMilliseconds);

                var m1 = GC.GetTotalMemory(false);

                System.Diagnostics.Debug.WriteLine("Approx. Mem Size: " + (m1 - m0) + "bytes");
                sw.Start();
#endif
            }


        }



        public void ExtractDataFromWordFile(string fileInfoKey)
        {
            //This counter runs for every data extract in this file,
            //so the app supports around 2 billion data extracts per each file
            int thisFileDataCounter = 1;
            var fi = Models.FileInfosDictionary[fileInfoKey];
            FileStream fs = null;
            fs = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            try {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fs, false))
                {
                    /*NOTE We use wca:wcaTextId and  wca:wcaParagraphId as attributes identifying particular Paragraphs or Runs 
                        Storing these data is only needed for complex queries or finding co-occurrences
                    */
                    long wcaTextId = 0, wcaParagraphId = 0;
                    string wcaTextIdLocalName = "wcaTextId", wcaParagraphIdLocalName = "wcaParagraphId";
                    WordprocessingDocument clone = (WordprocessingDocument)wordDoc.Clone();
                    var main = clone.MainDocumentPart;
                    //Set wcaTextId and wcaParagraphId attribute for all runs so that they will be identifiable
                    //NOTE that we could only add this attributes to runs or paragraphs that are commented
                    //but then we would have to check each time whether they have the attribute or not
                    //because of overlaps. So this method seems to be more efficient
                    foreach (var p in main.Document.Descendants<Paragraph>())
                    {
                        foreach (var t in p.Descendants<Text>())
                        {
                            wcaTextId++;
                            t.SetAttribute(new DocumentFormat.OpenXml.OpenXmlAttribute("wca", wcaTextIdLocalName, null, fileInfoKey + "_t_" + wcaTextId.ToString()));
                        }
                        wcaParagraphId++;
                        p.SetAttribute(new DocumentFormat.OpenXml.OpenXmlAttribute("wca", wcaParagraphIdLocalName, null, fileInfoKey + "_p_" + wcaParagraphId.ToString()));
                    }

                    var allComments = WordCommentsHelper.GetWordDocumentComments(main);
                    foreach (Comment comment in allComments)
                    {
                        var commentRangeEls = WordCommentsHelper.GetCommentRangeElements(main, comment.Id.Value);

                        var refText = WordCommentsHelper.GetElementsInnerText(commentRangeEls);
                        var innerImageDatas = commentRangeEls.SelectMany(
                            e => e.Descendants<DocumentFormat.OpenXml.Vml.ImageData>()
                            );

                        var imagesRelationshipIds = innerImageDatas.Select(d => d.RelationshipId.Value).ToArray();
                        /*

                        TODO: Prevent the following queries of wcaParagraphIds or wcaTextIds from crashing the program in case they failed
                        */
                        var wcaParagraphIds = new List<string>(); commentRangeEls.Where(e => e.GetType() == typeof(Paragraph)).Select(p => p.GetAttribute(wcaParagraphIdLocalName, null).Value
                            ).ToArray();
                        var wcaTextIds = commentRangeEls.SelectMany(
                            e => e.Descendants<Text>()).Select(
                            p => p.GetAttribute(wcaTextIdLocalName, null).Value
                            ).ToArray();
                        string elType = null;
                        foreach (var el in commentRangeEls)
                        {
                            /*NOTE that commentRangeEls are either consisted of Runs or consisted of Paragraphs
                            So we have to check only one of them to know the type of others*/
                            if (elType == null)
                            {
                                elType = el.GetType().Name;
                            }

                            wcaParagraphIds.Add(
                                ((elType == "Run") ? el.Parent : el)
                                .GetAttribute(wcaParagraphIdLocalName, null).Value
                                );
                        }


                        thisFileDataCounter++;
                        //NOTE that the first part of the following dataExtractId is needed to ensure unique ids
                        var dataExtractId = fileInfoKey + "_" + thisFileDataCounter;
                        var codes = WordCommentsHelper.ExtractCodesFromComment(comment);

                        Models.DataExtractsDictionary.Add(dataExtractId, new Models.DataExtract
                        {
                            FileInfoKey = fileInfoKey,

                            ReferenceText = refText,
                            ImagePartIds = imagesRelationshipIds,
                            Codes = codes,
                            WcaParagraphIds = wcaParagraphIds.ToArray(),
                            WcaTextIds = wcaTextIds
                        });
                        AddUpdateCodesDictionary(codes, dataExtractId);
                    }
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Dispose();
                }
            }
        }

        public void AddUpdateCodesDictionary(IEnumerable<string> codes, string dataExtractId)
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
