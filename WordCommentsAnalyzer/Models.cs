using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
namespace WordCommentsAnalyzer
{
    class Models
    {
        public static void ClearData()
        {
            CodesDictionary.Clear();
            DataExtractsDictionary.Clear();
            FilesDictionary.Clear();
        }

        public class DataExtract
        {
            /// <summary>
            /// The key that relates this dataextract to a FileInfo object in FileInfosDictionary
            /// </summary>
            public string FileKey{ get; set; }
            public string ReferenceText { get; set; }
            /// <summary>
            /// Note that the codes are stored both in the CodesDictionary and here because we need
            /// fast access to reference text codes
            /// </summary>
            public string[] Codes { get; set; }
            public string[] ImagePartIds { get; set; }
            public string[] WcaTextIds { get; set; }
            public string[] WcaParagraphIds { get; set; }
            public File File { get
                {
                    return FilesDictionary[FileKey];
                }
            }
            public List<System.Drawing.Image> GetImages()
            {
                System.IO.FileStream fs = null;
                try
                {
                    fs = System.IO.File.Open(File.Info.FullName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
                    using (var wordDoc = DocumentFormat.OpenXml.Packaging.WordprocessingDocument.Open(fs, false))
                    {
                        var main = wordDoc.MainDocumentPart;
                        var images = ImagePartIds.Select(id => System.Drawing.Image.FromStream(main.GetPartById(id).GetStream())).ToList();
                        return images;
                    }

                }
                finally
                {
                    if (fs != null) fs.Dispose();
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
                    return DataExtractsQuery(DataExtractsIds).ToList();
                }
            }

            public int DataExtractsCount
            {
                get
                {  
                    return DataExtractsIds.Count();
                }
            }

            
        }


        public class CodeStat
        {
            public Code Code { get; set; }
            public int Frequency { get; set; }
        }

        public class File
        {
            public System.IO.FileInfo Info { get; set; }
            /// <summary>
            /// Note that we calculate File Code Matrix based on the number of data extracts pertaining to each code
            /// </summary>
            public Dictionary<string,Code> CodesDictionary { get; set; }

        }

        /// <summary>
        /// DataExtracts are stored in a dictionary for faster retrieval
        /// The keys are DataExtractIds
        /// </summary>
        public static Dictionary<string, DataExtract> DataExtractsDictionary = new Dictionary<string, DataExtract>();
        public static Dictionary<string, Code> CodesDictionary = new Dictionary<string, Code>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// This dictionary is used to store each FileInfo and CodesDataExtractIdsDictionary:
        /// - to use in DataExtract to get FileName
        /// - to get images
        /// - to cound data extracts per code per file
        ///  see how the key is produced in AddFile method.
        /// </summary>
        public static Dictionary<string, File> FilesDictionary 
            = new Dictionary<string, File>();

        public static string AddFile(System.IO.FileInfo fi)
        {
            var key = fi.Name.UTF8ToBase64Ext();
            FilesDictionary.Add(key, new File
            {
                Info = fi,
                CodesDictionary = new Dictionary<string, Code>()
            });
            return key;
        }

        public static List<CodeStat> CodeStatList = new List<CodeStat>();
        public static List<CodeStat> FilteredCodeStatList = new List<CodeStat>();

        public static int ParagraphsCount =0;

        public static void AddUpdateCodesDictionary(ref Dictionary<string, Code> dict, IEnumerable<string> codes, string dataExtractId)
        {
            foreach (var c in codes)
            {
                if (!dict.ContainsKey(c))
                {
                    var code = new Models.Code { Value = c, DataExtractsIds = new List<string>() };
                    dict[c] = code;
                }
                dict[c].DataExtractsIds.Add(dataExtractId);
            }
        }

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

        public static void MakeCodesArabicPersianCharactersUniform()
        {
            var CodesHavingYehOrKafCount = CodesDictionary.Where(p => Regex.IsMatch(p.Key, "[\u064A\u0643]")).Count();
            var CodesHavingFarsiYehOrKehehCount = CodesDictionary.Where(p => Regex.IsMatch(p.Key, "[\u06CC\u06A9]")).Count();
            if (CodesHavingFarsiYehOrKehehCount == 0 & CodesHavingYehOrKafCount == 0) return;
            bool FarsiDominance = CodesHavingFarsiYehOrKehehCount > CodesHavingYehOrKafCount;
            /*NOTE that because we need to use Regex many times we use compiled Regex
            see https://stackoverflow.com/questions/513412/how-does-regexoptions-compiled-work
            */
            var regexYeh_FarsiYeh = new Regex("[\u06CC\u064A]", RegexOptions.Compiled);
            var regexKaf_Keheh = new Regex("[\u06A9\u0643]", RegexOptions.Compiled);
            var replaceYeh_Farsi = FarsiDominance ?  "\u06CC":"\u064A";
            var replaceKaf_Keheh = FarsiDominance ?  "\u06A9":"\u0643";
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var t0 = sw.ElapsedMilliseconds;
            /*NOTE that we need to statically store current codes because
            we can enumerate the dicionary and add/remove items at the same time
            Also note that we need ToArray or ToList for this
            */
            var currentCodes = CodesDictionary.Select(p => p.Key).ToArray();
            foreach (var code in currentCodes)
            {
                var codeObject = CodesDictionary[code];
                var replacedCode = regexKaf_Keheh.Replace(code, replaceKaf_Keheh);
                replacedCode = regexYeh_FarsiYeh.Replace(code, replaceYeh_Farsi);
                if (code != replacedCode)
                {
                    if (CodesDictionary.ContainsKey(replacedCode))
                    {
                        CodesDictionary[replacedCode].DataExtractsIds =
                            CodesDictionary[replacedCode].DataExtractsIds.Union(codeObject.DataExtractsIds).ToList();
                    }
                    else 
                    {
                        codeObject.Value = replacedCode;
                        CodesDictionary.Add(replacedCode, codeObject);
                    }
                    CodesDictionary.Remove(code);
                }
            }
            var t1 = sw.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("Time of replacing the codes in CodesDictionary (ms):" + (t1 - t0).ToString());
            foreach (var pair in DataExtractsDictionary)
            {
                var dxt = pair.Value;
                dxt.Codes = (from code in dxt.Codes
                            let a = regexKaf_Keheh.Replace(code, replaceKaf_Keheh)
                            let b = regexYeh_FarsiYeh.Replace(a, replaceYeh_Farsi)
                            select b).ToArray();
            }
            var t2 = sw.ElapsedMilliseconds;
            System.Diagnostics.Debug.WriteLine("Time of replacing the codes in DataExtracts (ms):" + (t2 - t1).ToString());

        }
        public static IEnumerable<DataExtract> DataExtractsQuery(IEnumerable<string> dataExtractIds)
        {
            var q = dataExtractIds.Select(id => DataExtractsDictionary[id]);
            return q;
        }
    }
}
