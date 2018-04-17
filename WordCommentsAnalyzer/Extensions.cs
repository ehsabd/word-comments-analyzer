using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCommentsAnalyzer
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
        public static string UTF8ToBase64Ext(this string source)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            string base64 = Convert.ToBase64String(bytes);
            return base64;
        }
        public static string RemoveInBracketExt(this string s)
        {
            return System.Text.RegularExpressions.Regex.Replace(s, @"\[.*\]", "");
        }
    }
}
