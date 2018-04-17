using System;
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
            DataExtract_Code_Maps.Clear(); 
        }

        public class DataExtract
        {
            public string Id { get; set; }
            public string FileName { get; set; }
            public string ReferenceText { get; set; }
        }

        public class DataExtract_Code_Map
        {
            public Code Code { get; set; }
            public string DataExtractId { get; set; }
        }

        public class Code
        {
            public string Value { get; set; }
            public List<DataExtract> DataExtracts
            {
                get {   
                      return DataExtractsQuery.ToList();
                }
            }

            public int DataExtractsCount
            {
                get
                {  
                    return DataExtractsQuery.Count();
                }
            }

            private IEnumerable<DataExtract> DataExtractsQuery
            {
                get
                {
                    var q = from m in DataExtract_Code_Maps
                            join d in Models.DataExtracts on m.DataExtractId equals d.Id
                            where m.Code.Value == this.Value
                            select d;
                    
                    return q;
                }
            }
        }


        public class CodeStat
        {
            public Code Code { get; set; }
            public int Frequency { get; set; }
        }

        // public static Dictionary<string, List<DataExtract>> DataExtractsDictionary
        //     = new Dictionary<string, List<DataExtract>>();

        public static List<DataExtract_Code_Map> DataExtract_Code_Maps = new List<DataExtract_Code_Map>();
        public static List<DataExtract> DataExtracts = new List<DataExtract>();
        public static Dictionary<string, Code> CodesDictionary
            = new Dictionary<string, Code>();
        
        /// <summary>
        /// to know which codes (from document codes) are present in the code hierarchy 
        /// </summary>
        public static ObservableCollection<string> CodesInHierarchy = new ObservableCollection<string>();

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
