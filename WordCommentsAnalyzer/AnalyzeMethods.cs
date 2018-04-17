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
        public void ExtractDataFromWordFile(FileInfo fi)
        {

            var dataExtractCounter = 1;
            using (FileStream fs = File.Open(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fs, false))
                {
                    //The following code retrieves comments from each document: 
                    WordprocessingCommentsPart commentsPart = 
                        wordDoc.MainDocumentPart
                               .WordprocessingCommentsPart;


                    if (commentsPart != null && commentsPart.Comments != null)
                    {
                        var allComments = commentsPart.Comments.Elements<Comment>();
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

                            var commentParas = comment.Descendants<Paragraph>()
                                                      .Select(el => el.InnerText.Trim())
                                                      .Where(s => !string.IsNullOrWhiteSpace(s));

                            foreach (var p in commentParas)
                            {
                                var code = new Models.Code { Value = p };
                                if (!Models.CodesDictionary.ContainsKey(p))
                                {
                                    Models.CodesDictionary[p] = code;
                                }
                                Models.DataExtract_Code_Maps.Add(new Models.DataExtract_Code_Map { Code = code, DataExtractId = dataExtractId });            
                            }

                            dataExtractCounter++;

                        }
                    }
                }
            }
        }

        
    }
}
