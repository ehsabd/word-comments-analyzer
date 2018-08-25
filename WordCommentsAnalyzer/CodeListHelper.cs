using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace WordCommentsAnalyzer
{
    class CodeListHelper
    {
        public static void UpdateCodesListView(ref ListView listViewCodes, IEnumerable<Models.CodeStat> codeStats, List<string> codesToHighlight = null)
        {
            ColumnHeader columnCode = new ColumnHeader();
            ColumnHeader columnFreq = new ColumnHeader();
            listViewCodes.Clear();
            listViewCodes.View = View.Details;
            listViewCodes.FullRowSelect = true;
            listViewCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnCode,
            columnFreq});
            // 
            // columnCode
            // 
            columnCode.Text = "Code";
            columnCode.Width = 200;
            // 
            // columnFreq
            // 
             columnFreq.Text = "Frequency";
             columnFreq.Width = 100;
            listViewCodes.BeginUpdate();
            foreach (var cs in codeStats)
            {
                var code = cs.Code.Value;
                var item = new ListViewItem(new string[] { code, cs.Frequency.ToString() });
                item.Name = code;
                if (codesToHighlight != null)
                {
                    SetListViewItemColor(item,
                        codesToHighlight.Contains(code) //NOTE that codesInHierarchy is built locally in this method
                        );
                }
                listViewCodes.Items.Add(item);
            }

            listViewCodes.EndUpdate();
 
        }

        private static System.Drawing.Color highightBackColor = System.Drawing.Color.FromArgb(255, 235, 255, 150);
        private static System.Drawing.Color highightForeColor = System.Drawing.Color.Black;

        public static void SetListViewItemColor(ListViewItem lvt, bool highlight )
        {
            lvt.BackColor = highlight ? highightBackColor : System.Drawing.Color.White;
            lvt.ForeColor = highlight ? highightForeColor : System.Drawing.Color.Black;

        }
    }
}
