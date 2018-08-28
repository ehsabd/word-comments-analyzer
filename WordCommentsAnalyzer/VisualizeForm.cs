using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WordCommentsAnalyzer
{
   
    public partial class VisualizeForm : Form
    {
        public class CoOccurrencesStat
        {
            public string Code1 { get; set; }
            public string Code2 { get; set; }
            public int n1 { get; set; }
            public int n2 { get; set; }
            public int n12 { get; set; }
            public float C_Coefficient { get; set; }

        }

        private class TableCell
        {
            public string Text { get; set; }
            public string Background { get; set; }
            public byte BulletSize { get; set; }
        }
        private List<string> checkedCodesA = new List<string>();
        private List<string> checkedCodesB = new List<string>();
        private List<string> checkedFileKeys = new List<string>();
        private List<string> checkedFileNames = new List<string>();

        private string htmlOutput = "";

        const string generalStyle = @"
                    body{font-family: Tahoma, sans-serif; font-size: 12px;}

                    #divTable td{text-align:center;
	                    overflow: hidden;
                      white-space: nowrap;
                      text-overflow: ellipsis;
                    }

                    #divHeader td {
                    vertical-align: top;
                    } 

                    #firstCol td{
                    white-space:nowrap;
                    text-overflow:ellipsis;	
                    overflow: hidden;

                    }
                    ";

        const string fileCodeMatrixStyle = @"
                #firstCol td, #divTable td{
                  line-height: 50px;
                }
                ";

        const string generalScript = @"
var firstColWidth = 200;


fnAdjustTable = function(){
  var cellWidth = 50;
  var divTable = document.getElementById('divTable');
  var tableDivTds =  divTable.getElementsByTagName('td');
  var divHeader = document.getElementById('divHeader');
  var tableHeaders = divHeader.getElementsByTagName('td');
  
  //Set fixed width for cells
  var divTableTable = divTable.getElementsByTagName('table')[0];
  var divHeaderTable = divHeader.getElementsByTagName('table')[0];
  var tableWidth = (cellWidth * tableHeaders.length) + 'px';
  divTableTable.style['table-layout']='fixed';
  divTableTable.style.width = tableWidth
  divHeaderTable.style['table-layout']='fixed';
  divHeaderTable.style.width = tableWidth;

var firstCol = document.getElementById('firstCol');
var firstColTable = document.getElementById('firstCol').getElementsByTagName('table')[0];
firstColTable.style['table-layout']='fixed';
firstColTable.style.width = firstColWidth+'px';

/*
var tablefirstColTds = document.getElementById('firstCol').getElementsByTagName('td');//document.getElementsByClassName('tablefirstCol');
  for (var i=0;i<tablefirstColTds.length;i++){
  var td = tableDivTds[tableHeaders.length * i];
  var h1 = tablefirstColTds[i].clientHeight;
  var h2 = td.clientHeight;
  if (h1>=h2){
	tableDivTds[tableHeaders.length * i].style.height = h1 + 'px';
  }else{
	tablefirstColTds[i].style.height = h2 + 'px';
  }
}*/

}
//function to support scrolling of title and first column
fnScroll = function(){
var divTable = document.getElementById('divTable');
var header = document.getElementById('divHeader').scrollLeft = divTable.scrollLeft;
var firstCol = document.getElementById('firstCol').scrollTop = divTable.scrollTop;

};
function getViewportHeight() {
            var client = window.document.documentElement['clientHeight'],
                inner = window['innerHeight'];

            return(client < inner)?inner:client;
};
		
function onResize(){

      var doc_width = document.body.offsetWidth;
	  var divHeader = document.getElementById('divHeader');
if (divHeader == undefined) return;
	   var divTable = document.getElementById('divTable');
	 
	  var headerHeight = 50;
	  var w = doc_width-firstColWidth ;
	  var h = getViewportHeight() - headerHeight - 30;
	  
	  divHeader.style.width = (w-26)+ 'px';
	  divHeader.style.height = headerHeight+ 'px';
	  divTable.style.width = w + 'px';
	  divTable.style.height = h+ 'px';
	  firstCol.style.height = (h-20)+ 'px';
	  firstCol.style.width = firstColWidth+ 'px';

}

onResize();

fnAdjustTable();

";

        /*NOTE that one of the uses of CoOccurrencesStatsDictionary and FilesCodesDictionary 
        is to prevent recalculation of already calculated stats because the user may check the codes/files incrementally
        */

        private Dictionary<string, CoOccurrencesStat> CoOccurrencesStatsDictionary 
            = new Dictionary<string, CoOccurrencesStat>();
        /// <summary>
        /// A dictionary that stores the number of paragraphs in each code in each file
        /// </summary>
        private Dictionary<string, int> FilesCodesDictionary
           = new Dictionary<string, int>();
        public VisualizeForm(bool rightToLeft = false)
        {
            InitializeComponent();
            var rtl = rightToLeft ? RightToLeft.Yes : RightToLeft.No;
            RightToLeftLayout = rightToLeft;
            RightToLeft = rtl;
        }

        private void Form_Load(object sender, EventArgs e)
        {

            CodeListHelper.UpdateCodesListView(ref listViewCodesA, Models.CodeStatList);
            CodeListHelper.UpdateCodesListView(ref listViewCodesB, Models.CodeStatList);
            UpdateFilesListView();

            listViewCodesA.CheckBoxes = true;
            listViewCodesB.CheckBoxes = true;
            listViewFiles.CheckBoxes = true;

            //setup events after updating the listviews
            SetListViewEvents();

            webBrowser1.AllowWebBrowserDrop = false;
            
#if DEBUG
                    webBrowser1.ScriptErrorsSuppressed = false;
#else
                    webBrowser1.ScriptErrorsSuppressed = true;
                     webBrowser1.IsWebBrowserContextMenuEnabled = false;
#endif
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
           
        
            
        }

        private void SetListViewEvents()
        {
            
            this.listViewCodesA.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);
            this.listViewCodesB.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);
            this.listViewFiles.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);

        }

        private void UnsetListViewEvents()
        {
           
            this.listViewCodesA.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);
            this.listViewCodesB.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);
            this.listViewFiles.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.anylistView_ItemChecked);

        }



        private void bwFindCooccurrences_DoWork(object sender, DoWorkEventArgs e)
        {
#if DEBUG
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var m0 = GC.GetTotalMemory(false);
#endif
            for (var i = 0; i < checkedCodesA.Count; i++)
            {
                var rowCode = checkedCodesA[i];     
                for (var j = 0; j < checkedCodesB.Count; j++)
                {
                    var colCode = checkedCodesB[j];
                    if (colCode != rowCode)
                    {
                        var key = GetOrderIndependentCodeCombination(rowCode, colCode);
                        CoOccurrencesStat coOccurrencesStat =null;
                        
                        //This is because we have two symetric diagonals and this saves some calculations
                        if (CoOccurrencesStatsDictionary.ContainsKey(key))
                        {
                            coOccurrencesStat = CoOccurrencesStatsDictionary[key];
                        }
                        else
                        {
                            coOccurrencesStat = GetCoOccurrencesStat(colCode, rowCode, AnalysisLevel.Word);
                            CoOccurrencesStatsDictionary.Add(key, coOccurrencesStat);
                        }
                    } 

                    
                }
               
            }
#if DEBUG
            sw.Stop();
            System.Diagnostics.Debug.WriteLine("Matrix calculation time (ms): " + sw.ElapsedMilliseconds);

            var m1 = GC.GetTotalMemory(false);

            System.Diagnostics.Debug.WriteLine("Approx. Mem Size: " + (m1-m0) + "bytes");
            sw.Start();
#endif

            var cells = (from p in CoOccurrencesStatsDictionary
                         let stat = p.Value
                         let n12 = stat.n12
                         select new KeyValuePair<string, TableCell>(
                             p.Key,
                         n12 == 0 ? new TableCell { } :
                         new TableCell
                         {
                             Text = n12.ToString(),
                             Background = GetColorFromCoefficient(stat.C_Coefficient)
                         }))
                            .ToDictionary( p => p.Key, p => p.Value);

  
            htmlOutput = GetHTMLTable(checkedCodesB, checkedCodesA, cells);
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Matrix calculation time + html DOM building (ms): " + sw.ElapsedMilliseconds);
            sw.Stop();
#endif
        }

        /// <summary>
        /// This HTML Table is adapted from the following link and converted to a pure js form:
        ///   http://fixed-header-using-jquery.blogspot.com/2009/05/scrollable-table-with-fixed-header-and.html-->
        /// </summary>
        /// <returns></returns>
        private string GetHTMLTable(IEnumerable<string> rows, IEnumerable<string> cols, Dictionary<string,TableCell> cells)
        {
           
            var divHeader = @"<div id='divHeader' style='overflow:hidden;width:284px;'>
        <table cellspacing='0' cellpadding='0' border='1' >
          <tr>";
            foreach (var c in cols) {
                divHeader += "<td>" + c + "</td>";
            }
            divHeader += @"
          </tr>
        </table>
      </div>";

            /*NOTE that we have row codes in the firstCol*/
        var firstCol = @"
     <div id='firstCol' style='overflow: hidden;height:80px'>
        <table width='200px' cellspacing='0' cellpadding='0' border='1' >";
            foreach (var r in rows)
            {
                firstCol += "<tr><td>" + r + "</td></tr>";
            }
            firstCol +=
     @"</table>
      </div>";


            var stringBuilderLength = 2 * rows.Count() + //for <tr> and </tr> tags
                                      cols.Count() * rows.Count() + //for td tags (made in one line)
                                      2; //for wrapping tags
            /*NOTE that using StringBuilder has a huge impact on performance.
            See https://support.microsoft.com/en-us/help/306822/how-to-improve-string-concatenation-performance-in-visual-c
            */
            System.Text.StringBuilder sb = new System.Text.StringBuilder(stringBuilderLength);
            sb.Append(@"<div id='divTable' style='overflow: scroll;width:300px;height:100px;position:relative' onscroll='fnScroll()' >
        <table width='500px' cellspacing='0' cellpadding='0' border='1' >
       ");

           foreach(var r in rows)
            {
                sb.Append( "<tr>");
                foreach (var c in cols)
                {
                    string text = null;
                    string background = null;
                    byte bulletSize = 0;

                    if (r != c)
                    {
                        var key = GetOrderIndependentCodeCombination(r, c);
                        text = cells[key].Text;
                        background = cells[key].Background;
                        bulletSize = cells[key].BulletSize;
                    }

                    var tdTags = "";
                    if (bulletSize != 0)
                    {
                        tdTags = string.Format("<td style='font-size:{0}px;'>&bull;</td>", bulletSize);
                    }
                    else {
                        if (background == null)
                        {
                            if (text == null)
                            {
                                tdTags = "<td>-</td>"; //dash (-) is to avoid layout error in IE
                            }
                            else
                            {
                                tdTags = string.Format("<td>{1}</td>", background, text);
                            }
                        }
                        else
                        {
                            tdTags = string.Format("<td style='background:#{0};'>{1}</td>", background, text);
                        }
                    }
                   
                    sb.Append(tdTags);
                }
                sb.Append("</tr>");
            }

            sb.Append(@"</table></div>");

            var divTable = sb.ToString();
            /*
            {0}: divHeader
            {1}: firstCol
            {2}: divTable

            */
                    var template = @"<table cellspacing='0' cellpadding='0' border='0' >
                              <tr>
                                <td id='firstTd'>
                                </td>
                                <td>
                                  {0}
                                </td>
                              </tr>
                              <tr>
  
                                <td valign='top'>
                                  {1}
                                </td>
    
                                <td valign='top'>
                                  {2}
                                </td>
                              </tr>
                            </table>";
            return string.Format(template, divHeader, firstCol, divTable);
        }

        private static string GetColorFromCoefficient(float c)
        {
            var rb = (255 - (int)(c * 255)).ToString("X2");
            return  rb + "ff" + rb;
        }

        private enum AnalysisLevel
        {
            Paragraph = 1,
            Word = 2
        }

        private string GetDoumentText(string styleInner, string bodyInner, string scriptInner)
        {
            return string.Format(@"<!DOCTYPE html>
                                    <html>              
                                        <head>
                                            <style>{0}</style>
                                        </head>
                                        <body onresize='onResize()'>
                                            {1}
                                        </body>
                                        <script>
                                            {2}
                                        </script>
                                    </html> ", styleInner, bodyInner, scriptInner);
        }

        private CoOccurrencesStat GetCoOccurrencesStat(string code1, string code2, AnalysisLevel level)
        {
            //TODO currently this is not based on words or paragraphs, only texts so we disregard AnalysisLevel!
            //TODO improve this by storing TextIds in the codesdictionary.There are additional queries in the following queries
            //Also we should make WCAParagraph class to include paragraphId and child textIds 
            var code1TextIds = Models.CodesDictionary[code1].DataExtracts.SelectMany(dxt => dxt.WcaTextIds);
            var code2TextIds = Models.CodesDictionary[code2].DataExtracts.SelectMany(dxt => dxt.WcaTextIds);
            var n1 = code1TextIds.Count();
            var n2 = code1TextIds.Count();
            var n12 = code1TextIds.Intersect(code2TextIds).Count();
            /*Reference : Friese, S. (2014). Qualitative data analysis with ATLAS.ti. London, England: Sage.
            see also: 
            http://journals.sagepub.com/doi/full/10.1177/2158244017707797#
            */
            float c_coefficient = (float)(Convert.ToDouble(n12) / Convert.ToDouble(n1 + n2 - n12));
            return new CoOccurrencesStat
            {
                Code1 = code1,
                Code2 = code2,
                n1 = n1,
                n2 = n2,
                n12 = n12,
                C_Coefficient = c_coefficient
            };     
        }

        private int GetParagraphsCount( string fileKey, string code)
        {
            var cd = Models.FilesDictionary[fileKey].CodesDictionary;
            if (cd.ContainsKey(code))
            {
                return cd[code].DataExtracts.Sum(dxt => dxt.WcaParagraphIds.Count());
            }
            else
            {
                return 0;
            }
        }

        private string GetOrderIndependentCodeCombination (string code1, string code2 )
        {
            var compare = code1.UTF8ToBase64Ext().CompareTo(code2.UTF8ToBase64Ext());
            return compare >= 0 ? code1+"_"+ code2:code2 +"_"+ code1;
        }
      

        private void bwFindCooccurrences_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (checkedCodesA.Count == listViewCodesA.CheckedItems.Count && checkedCodesB.Count == listViewCodesB.CheckedItems.Count)
            {

                var html  = GetDoumentText(generalStyle, htmlOutput, generalScript);
                webBrowser1.DocumentText = html;
#if DEBUG
                DumpHtmlFile(html);
#endif
            }
            else
            {

                StartUpdatingCoOccurrencesGrid();
            }
            
        }
        /*NOTE that this event is set in runtime using SetListviewEvents*/
        private void anylistView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //This is to prevent the update before other checks are completed
            pseudoTimerStartUpdatingGrid.Enabled = false;
            pseudoTimerStartUpdatingGrid.Enabled = true;   
        }

        private void StartUpdatingCoOccurrencesGrid()
        {
            if (!bwFindCooccurrences.IsBusy)
            {
               
                checkedCodesA = new List<string>();
                checkedCodesB = new List<string>();
                foreach (ListViewItem a in listViewCodesA.CheckedItems)
                {
                    checkedCodesA.Add(a.Text);

                }
                foreach (ListViewItem b in listViewCodesB.CheckedItems)
                {
                    checkedCodesB.Add(b.Text);

                }

                labelCodesA.Text = checkedCodesA.Count() + " Codes";
                labelCodesB.Text = checkedCodesB.Count() + " Codes";

                if (checkedCodesB.Count > 0 && checkedCodesA.Count > 0)
                {
                    bwFindCooccurrences.RunWorkerAsync();
                }
            }
        }

        private void StartUpdatingFileCodeGrid()
        {
            if (!bwCalculateFileCodeMatrix.IsBusy)
            {

                checkedCodesA = new List<string>();
                checkedFileKeys = new List<string>();
                checkedFileNames = new List<string>();
                foreach (ListViewItem a in listViewCodesA.CheckedItems)
                {
                    checkedCodesA.Add(a.Text);

                }
                foreach (ListViewItem f in listViewFiles.CheckedItems)
                {
                    checkedFileNames.Add(f.Text);
                    checkedFileKeys.Add(f.Name);

                }

                labelCodesA.Text = checkedCodesA.Count() + " Codes";
                labelCodesB.Text = checkedCodesB.Count() + " Codes";

                if (checkedFileKeys.Count > 0 && checkedCodesA.Count > 0)
                {
                    bwCalculateFileCodeMatrix.RunWorkerAsync();
                }
            }
        }

       
        private void CheckAll (ListView lv)
        {
            UnsetListViewEvents();
            for (int i = 0; i < lv.Items.Count; i++)
            {
                    lv.Items[i].Checked = true;
            }
            SetListViewEvents();
        }

        /*NOTE this timer functions as an easily cancellable background worker. It is very important to set Enabled to false in the Tick event*/
        private void pseudoTimerStartUpdatingGrid_Tick(object sender, EventArgs e)
        {
            if (radioCodeCoOccurrences.Checked)
            {
                StartUpdatingCoOccurrencesGrid();
            }
            else
            {
                StartUpdatingFileCodeGrid();
            }
            pseudoTimerStartUpdatingGrid.Enabled = false;
        }

        private void splitterLeftRight_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void radioItemCheckedChanged(object sender, EventArgs e)
        {
            var a = radioCodeCoOccurrences.Checked; 
            listViewCodesB.Visible = a;
            labelCodesB.Visible = a;
            listViewFiles.Visible = !a;
            labelFiles.Visible = !a;
        
        }

        private void bwCalculateFileCodeMatrix_DoWork(object sender, DoWorkEventArgs e)
        {
#if DEBUG
            var sw = System.Diagnostics.Stopwatch.StartNew();
            var m0 = GC.GetTotalMemory(false);
#endif
            for (var i = 0; i < checkedCodesA.Count; i++)
            {
                var rowCode = checkedCodesA[i];
                for (var j = 0; j < checkedFileKeys.Count; j++)
                {
                    var fileKey = checkedFileKeys[j];
                    var fileName = checkedFileNames[j]; 
                        var key = GetOrderIndependentCodeCombination(rowCode, fileName);
                        int numberOfDataExtracts = 0;

                        //This is because the user may select the previous codes again and we can save some calculations
                        if (FilesCodesDictionary.ContainsKey(key))
                        {
                        numberOfDataExtracts = FilesCodesDictionary[key];
                        }
                        else
                        {
                        numberOfDataExtracts = GetParagraphsCount(fileKey, rowCode);
                        FilesCodesDictionary.Add(key, numberOfDataExtracts);
                        }

                }

            }
#if DEBUG
            sw.Stop();
            System.Diagnostics.Debug.WriteLine("Matrix calculation time (ms): " + sw.ElapsedMilliseconds);

            var m1 = GC.GetTotalMemory(false);

            System.Diagnostics.Debug.WriteLine("Approx. Mem Size: " + (m1 - m0) + "bytes");
            sw.Start();
#endif
            var maxFileCodeCount = FilesCodesDictionary.Max(p => p.Value);
                                 

            var cells = (from p in FilesCodesDictionary
                         let count = p.Value
                         select new KeyValuePair<string, TableCell>(
                             p.Key,
                         count == 0 ? new TableCell { } :
                         new TableCell
                         {
                             Text = null,
                             Background = null,
                             BulletSize = (byte)(count * 100 / maxFileCodeCount)
                         }))
                            .ToDictionary(p => p.Key, p => p.Value);


            htmlOutput = GetHTMLTable(checkedFileNames, checkedCodesA, cells);
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Matrix calculation time + html DOM building (ms): " + sw.ElapsedMilliseconds);
            sw.Stop();
#endif

        }

        private void bwCalculateFileCodeMatrix_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (checkedCodesA.Count == listViewCodesA.CheckedItems.Count && 
                checkedFileKeys.Count == listViewFiles.CheckedItems.Count)
            {
                var html = GetDoumentText(generalStyle + fileCodeMatrixStyle, htmlOutput, generalScript);
                webBrowser1.DocumentText = html;
#if DEBUG
                DumpHtmlFile(html);
#endif

            }
            else
            {
                StartUpdatingFileCodeGrid();
            }
        }

        private void UpdateFilesListView()
        {

            listViewFiles.Clear();
            ColumnHeader columnFileName = new ColumnHeader();

            listViewFiles.View = View.Details;
            listViewFiles.FullRowSelect = true;
            listViewFiles.Columns.Add(columnFileName);

            columnFileName.Text = "File Name";
            columnFileName.Width = 200;

            listViewFiles.BeginUpdate();
            foreach (var pair in Models.FilesDictionary)
            {
                listViewFiles.Items.Add(pair.Key, pair.Value.Info.Name, -1);
            }
            listViewFiles.EndUpdate();
        }

#if DEBUG
        private void DumpHtmlFile(string html)
        {
            using (var textWrite = new System.IO.StreamWriter("out" + DateTime.Now.ToString("yyyy_MMMM_dd_HH_mm_ss") + ".html"))
            {
                textWrite.Write(html);
            }
        }
#endif
    }
}
