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
        private List<string> checkedCodesA = new List<string>();
        private List<string> checkedCodesB = new List<string>();
        
        private string htmlOutput = "";
        private Dictionary<string, CoOccurrencesStat> CoOccurrencesStatsDictionary 
            = new Dictionary<string, CoOccurrencesStat>();

        public VisualizeForm(bool rightToLeft = false)
        {
            InitializeComponent();
            var rtl = rightToLeft ? RightToLeft.Yes : RightToLeft.No;
            RightToLeftLayout = rightToLeft;
            RightToLeft = rtl;
        }

        private void CodeDocumentMatrixForm_Load(object sender, EventArgs e)
        {

            CodeListHelper.UpdateCodesListView(ref listViewCodesA, Models.CodeStatList);
            CodeListHelper.UpdateCodesListView(ref listViewCodesB, Models.CodeStatList);

            listViewCodesA.CheckBoxes = true;
            listViewCodesB.CheckBoxes = true;

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
            webBrowser1.DocumentText = @"<!DOCTYPE html>
<html>

<head>
<style>
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

</style>
</head>
  
<body onresize='onResize()'>
</body>
<script>

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
	  var firstCol = document.getElementById('firstCol');
	  var firstColWidth = 150;
	  var firstColTable = document.getElementById('firstCol').getElementsByTagName('table')[0];
		firstColTable.style['table-layout']='fixed';
		firstColTable.style.width = firstColWidth+'px';
	  var headerHeight = 30;
	  var w = doc_width-firstColWidth ;
	  var h = getViewportHeight() - headerHeight - 30;
	  
	  divHeader.style.width = (w-26)+ 'px';
	  divHeader.style.height = headerHeight+ 'px';
	  divTable.style.width = w + 'px';
	  divTable.style.height = h+ 'px';
	  firstCol.style.height = (h-20)+ 'px';
	  firstCol.style.width = firstColWidth+ 'px';

}




</script>
</html> ";
        
            
        }

        private void SetListViewEvents()
        {
            
            this.listViewCodesA.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewCodesAorB_ItemChecked);
            this.listViewCodesB.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewCodesAorB_ItemChecked);

        }

        private void UnsetListViewEvents()
        {
           
            this.listViewCodesA.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.listViewCodesAorB_ItemChecked);
            this.listViewCodesB.ItemChecked -= new System.Windows.Forms.ItemCheckedEventHandler(this.listViewCodesAorB_ItemChecked);

        }


       
        private void bwFindCooccurrences_DoWork(object sender, DoWorkEventArgs e)
        {
            /*NOTE that this sleep is necessary to prevent bwFindCooccurrences to finish its work before all checked events
            be raised; then there would be no chance to check for new codes (this is done in bwFindCooccurrences_RunWorkerCompleted)*/
            System.Threading.Thread.Sleep(300);
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
            htmlOutput = GetHTMLTable();
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
        private string GetHTMLTable()
        {
           
            var divHeader = @"<div id='divHeader' style='overflow:hidden;width:284px;'>
        <table cellspacing='0' cellpadding='0' border='1' >
          <tr>";
            foreach (var a in checkedCodesA) {
                divHeader += "<td>" + a + "</td>";
            }
            divHeader += @"
          </tr>
        </table>
      </div>";


            var firstCol = @"
     <div id='firstCol' style='overflow: hidden;height:80px'>
        <table width='200px' cellspacing='0' cellpadding='0' border='1' >";
            foreach (var b in checkedCodesB)
            {
                firstCol += "<tr><td>" + b + "</td></tr>";
            }
            firstCol +=
     @"</table>
      </div>";

         

            var stringBuilderLength = 2 * checkedCodesB.Count + //for <tr> and </tr> tags
                                      checkedCodesA.Count * checkedCodesB.Count + //for td tags (made in one line)
                                      2; //for wrapping tags
            /*NOTE that using StringBuilder has a huge impact on performance.
            See https://support.microsoft.com/en-us/help/306822/how-to-improve-string-concatenation-performance-in-visual-c
            */
            System.Text.StringBuilder sb = new System.Text.StringBuilder(stringBuilderLength);
            sb.Append(@"<div id='divTable' style='overflow: scroll;width:300px;height:100px;position:relative' onscroll='fnScroll()' >
        <table width='500px' cellspacing='0' cellpadding='0' border='1' >
       ");

           for(var i=0;i < checkedCodesB.Count;i++)
            {
                var backgroundRGB = (i % 2 == 0) ? 255 : 250;
                var b = checkedCodesB[i];
                sb.Append( "<tr>");
                for (var j = 0; j <checkedCodesA.Count;j++)
                {
                    var a = checkedCodesA[j];
                    string text = null;
                    
                    
                    string background = null;
                    if (a != b)
                    {
                        var key = GetOrderIndependentCodeCombination(a, b);
                        var stat = CoOccurrencesStatsDictionary[key];
                        if (stat.n12 != 0)
                        {
                            text = stat.n12.ToString();
                            var rb = (255 - (int)(stat.C_Coefficient * 255)).ToString("X2");
                            background = rb + "ff" + rb;
                        }
                    }
                    /* We currently don't use color style (for all) and background for empty cells to save some memory. This is significant in huge matrixes
                    if (background == null)
                    {
                        var rgbhex = backgroundRGB.ToString("X2");
                        background = rgbhex+ rgbhex+ rgbhex;
                        color = background;//we don't want to show anything by default even the dash
                    }
                    // var tdTags = string.Format("<td style='color:#{0};background:#{1};'>{2}</td>", color, background, text);
                    */

                    var tdTags = background == null ?
                        "<td>-</td>" : //dash (-) is to avoid error in IE
                        string.Format("<td style='background:#{0};'>{1}</td>", background, text)
                        ;

                   
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

        private enum AnalysisLevel
        {
            Paragraph = 1,
            Word = 2
        }

        private CoOccurrencesStat GetCoOccurrencesStat(string code1, string code2, AnalysisLevel level)
        {
            //TODO currently this is not based on words!
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

        private string GetOrderIndependentCodeCombination (string code1, string code2 )
        {
            return code1.CompareTo(code1) >=0 ? code1+"_"+ code2:code2 +"_"+ code1;
        }
      

        private void bwFindCooccurrences_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (checkedCodesA.Count == listViewCodesA.CheckedItems.Count && checkedCodesB.Count == listViewCodesB.CheckedItems.Count)
            {
                webBrowser1.Document.Body.InnerHtml = htmlOutput;
                using (var textWrite = new System.IO.StreamWriter("out.html"))
                {
                    textWrite.Write(htmlOutput);
                }
                webBrowser1.Document.InvokeScript("fnAdjustTable");
            }
            else
            {

                StartUpdatingGrid();
            }
            
        }
        /*NOTE that this event is set in runtime using SetListviewEvents*/
        private void listViewCodesAorB_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //This is to prevent the update before other checks are completed
            pseudoTimerStartUpdatingGrid.Enabled = false;
            pseudoTimerStartUpdatingGrid.Enabled = true;   
        }
        private void StartUpdatingGrid()
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

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(listViewCodesA);
            CheckAll(listViewCodesB);
            
            StartUpdatingGrid();
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
            StartUpdatingGrid();
            pseudoTimerStartUpdatingGrid.Enabled = false;
        }

        private void splitterLeftRight_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
