﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WordCommentsAnalyzer
{
    class Models
    {
        public static void ClearData()
        {
            CodesInHierarchy.Clear(); 
            CodesDictionary.Clear(); 
            DataExtracts.Clear();
            FileInfosDictionary.Clear();
        }

        public class DataExtract
        {
            public string Id { get; set; }
            /// <summary>
            /// The key that relates this dataextract to a FileInfo object in FileInfosDictionary
            /// </summary>
            public string FileInfoKey{ get; set; }
            public string ReferenceText { get; set; }
            public List<string> ImagePartIds { get; set; }
            public System.IO.FileInfo FileInfo { get
                {
                    return FileInfosDictionary[FileInfoKey];
                }
            }
            public List<System.Drawing.Image> GetImages()
            {
                using (var fs = System.IO.File.Open(FileInfo.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite))
                using (var wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(fs, false))
                {
                    var main = wordDoc.MainDocumentPart;
                    var images = ImagePartIds.Select(id=>System.Drawing.Image.FromStream(main.GetPartById(id).GetStream())).ToList();
                    return images;
                }
            }
        }

        public class Code
        {
            public string Value { get; set; }
            /// <summary>
            /// From version 2.0.3.0 onward, We store DataExtractIds instead of DataExtract_Code_Maps in the code, so that we could easily look them up in codes dictionary
            /// </summary>
            public List<string> DataExtractsIds { get; set;}
            public List<DataExtract> DataExtracts
            {
                get
                {
                    return DataExtractsQuery.ToList();
                }
            }

            public int DataExtractsCount
            {
                get
                {  
                    return DataExtractsIds.Count();
                }
            }

            private IEnumerable<DataExtract> DataExtractsQuery
            {
                get
                {
                    var q = from id in DataExtractsIds
                            join d in Models.DataExtracts on id equals d.Id
                            select d;
                    return q;
                }
            }
        }


        public class CodeStat
        {
            public Code Code { get; set; }
            public int Frequency { get; set; }
            public bool IsSelected { get; set; }
        }

        public static List<DataExtract> DataExtracts = new List<DataExtract>();
        public static Dictionary<string, Code> CodesDictionary
            = new Dictionary<string, Code>();
        /// <summary>
        /// This dictionary is used to store each FileInfo for use in DataExtract to get FileName and also
        /// images, the key is base64 converted fullname
        /// </summary>
        public static Dictionary<string, System.IO.FileInfo> FileInfosDictionary 
            = new Dictionary<string, System.IO.FileInfo>();

        public static string AddFileInfo(System.IO.FileInfo fi)
        {
            var key = fi.FullName.UTF8ToBase64Ext();
            FileInfosDictionary.Add(key, fi);
            return key;
        }

        /// <summary>
        /// to know which codes (from document codes) are present in the code hierarchy 
        /// this needs to be an observable collection because we only want to change color of 
        /// codes that are changed. It may have a better performance than checking every code after a change in 
        /// hierarchy.
        /// </summary>
        public static ObservableCollection<string> CodesInHierarchy = new ObservableCollection<string>();

        /// <summary>
        /// To know which codes are seleted. This does not need to be observable because selected codes are usually reset on every selection
        /// and updated after selection.
        /// </summary>
        public static List<string> SelectedCodes = new List<string>();
        public static List<CodeStat> CodeStatList = new List<CodeStat>();
        public static List<CodeStat> FilteredCodeStatList = new List<CodeStat>();

        //pass textCulture.Text for culturetext
        public static void SortCodeStatListByCode(string cultureText)
        {
            var culture = new System.Globalization.CultureInfo(cultureText);
            CodeStatList = CodeStatList.OrderBy(
                i => i.Code.Value,
                StringComparer.Create(culture, false)
                ).ToList();
        }

        public static void SortCodeStatListByFrequency(string cultureText)
        {
            var culture = new System.Globalization.CultureInfo(cultureText);
            CodeStatList = CodeStatList
                .OrderByDescending(
                    i => i.Frequency)
                .ThenBy(
                    i => i.Code.Value,
                    StringComparer.Create(culture, false)
                ).ToList();
        }

        public static void ComputeCodeStats()
        {
            Models.CodeStatList =
                Models.CodesDictionary
                .Select(
                        kv => new Models.CodeStat
                        {
                            Code = kv.Value,
                            Frequency = kv.Value.DataExtractsCount
                        }
                        ).ToList();

        }

        public static bool CodeExists (string code)
        {
            return Models.CodesDictionary.ContainsKey(code); 
        }
    }
}
