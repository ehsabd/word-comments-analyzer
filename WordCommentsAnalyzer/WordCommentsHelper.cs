using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;
namespace WordCommentsAnalyzer
{
    class WordCommentsHelper
    {
        public static IEnumerable<Comment> GetWordDocumentComments(MainDocumentPart mainPart)
        {
            WordprocessingCommentsPart commentsPart = mainPart.WordprocessingCommentsPart;

            if (commentsPart == null || commentsPart.Comments == null)
            {
                return Enumerable.Empty<Comment>();
            }
            else
            {
                return commentsPart.Comments.Elements<Comment>();
            }

        }

        public static List<string> ExtractCodesFromComment(Comment comment)
        {
            string replaceSpacePattern = "[" + "\u200C" //Zero Width Non-Joiner
                + "]";

            string removePattern = "[" + "\u200D" //Zero Width Joiner
                + "]";

            char[] trimChars = { ':',';', '"', '\'', ',', '.', '،', '؛','\t','\n','\r',' '};
            return comment.Descendants<Paragraph>()
                .Select(
                el => Regex.Replace(
                    Regex.Replace(el.InnerText,removePattern,""),
                    replaceSpacePattern," ")
                    .Trim(trimChars)
                    )
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }

        /*The methods GetElementsInnerText, GetCommentRangeElements, and IsMatchingCommentEnd are adapted from
        the answer to "Getting OpenXmlElements between CommentRangeStart and CommentRangeEnd - Stack Overflow" at
        https://stackoverflow.com/questions/12175491/getting-openxmlelements-between-commentrangestart-and-commentrangeend,
        copyright 2012 by Mike B, licensed under CC BY-SA 3.0 with attribution required (https://creativecommons.org/licenses/by-sa/3.0/)
        */
        public static string GetElementsInnerText(IEnumerable<OpenXmlElement> elms)
        {
            string refText = "";
            if (elms != null)
            {

                foreach (var elm in elms)
                {
                    refText += elm.InnerText;
                    if (elm.GetType() == typeof(Paragraph))
                    {
                        refText += ' ';
                    }
                }
                return refText;
            }
            else
            {
                return "";
            }

        }

        public static IEnumerable<OpenXmlElement> GetCommentRangeElements(MainDocumentPart mainPart, string commentId)
        {
            var commentRangeStart = mainPart
                                    .Document
                                    .Descendants<CommentRangeStart>()
                                    .Where(cr => (cr.Id.ToString() == commentId))
                                    .FirstOrDefault(); ;

            if (commentRangeStart != null)
            {
                return CommentRangeElementsRecursive(commentRangeStart);

            }
            else
            {
                return null;
            }

        }

        private static IEnumerable<OpenXmlElement> CommentRangeElementsRecursive(CommentRangeStart commentStart, OpenXmlElement searchStartElement = null)
        {
            List<OpenXmlElement> commentedNodes = new List<OpenXmlElement>();
            if (searchStartElement == null)
            {
                searchStartElement = commentStart;
            }
            else
            {
                commentedNodes.Add(searchStartElement);
            }
            var element = searchStartElement;
            var commentEndFound = false;

            while (true)
            {

                element = element.NextSibling();

                // check that the item exists
                if (element == null)
                {
                    break;
                }

                //check that the item is matching comment end
                if (IsMatchingCommentEnd(element, commentStart.Id.Value))
                {
                    commentEndFound = true;
                    break;
                }

                //check that there is a matching element in the current element's descendants
                var descendantsCommentEnd = element.Descendants<CommentRangeEnd>();
                if (descendantsCommentEnd != null)
                {
                    foreach (CommentRangeEnd rangeEndNode in descendantsCommentEnd)
                    {
                        if (IsMatchingCommentEnd(rangeEndNode, commentStart.Id.Value))
                        {
                            commentEndFound = true;
                            break;
                        }
                    }
                }


                commentedNodes.Add(element);
                if (commentEndFound)
                {
                    break;
                }
            }
           
            if (commentEndFound)
            {
                return commentedNodes;
            }
            else
            {
                return CommentRangeElementsRecursive(commentStart, searchStartElement.Parent);
            }
        }

        private static bool IsMatchingCommentEnd(OpenXmlElement element, string commentId)
        {
            CommentRangeEnd commentEnd = element as CommentRangeEnd;
            if (commentEnd != null)
            {
                return commentEnd.Id == commentId;
            }
            return false;
        }


    }
}
