using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WordCommentsAnalyzer
{
    class ArabicPersianTextHelper
    {
        public static bool IsTextArabicOrPersian(string text)
        {
            var match = Regex.Match(text, "[\u0600-\u06ff].*|[\u0750-\u077f].*|[\ufb50-\ufc3f].*|[\ufe70-\ufefc]*");
            return match.Length > text.Length / 2;
            
        }
        
    }
}
