using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;

namespace WordCommentsAnalyzer
{
    class WordCommentsHelper
    {
        public static IEnumerable<Comment> GetWordDocumentComments(WordprocessingDocument wordDoc)
        {
            WordprocessingCommentsPart commentsPart =
                wordDoc.MainDocumentPart
                       .WordprocessingCommentsPart;

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
            return comment.Descendants<Paragraph>()
                .Select(el => el.InnerText.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();
        }
        /*The methods GetReferenceText, CommentRangeElements, and IsMatchingCommentEnd are adapted from
        the answer to "Getting OpenXmlElements between CommentRangeStart and CommentRangeEnd - Stack Overflow" at
        https://stackoverflow.com/questions/12175491/getting-openxmlelements-between-commentrangestart-and-commentrangeend,
        copyright 2012 by Mike B, licensed under CC BY-SA 3.0 with attribution required (https://creativecommons.org/licenses/by-sa/3.0/)
        */
        public static string GetReferenceText(WordprocessingDocument wordDoc, string commentId)
        {
            
            var commentRangeStart = wordDoc.MainDocumentPart
                                      .Document
                                      .Descendants<CommentRangeStart>()
                                      .Where(cr => (cr.Id.ToString() == commentId))
                                      .FirstOrDefault(); ;

            string refText = "";
            if (commentRangeStart != null)
            {
                var elms = CommentRangeElements(commentRangeStart);
                foreach (var elm in elms)
                {
                    refText += elm.InnerText;
                    if (elm.GetType() == typeof(Paragraph))
                    {
                        refText += ' ';
                    }
                }
            }
            return refText;
        }
        public static IEnumerable<OpenXmlElement> CommentRangeElements(CommentRangeStart commentStart, OpenXmlElement searchStartElement = null)
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
                return CommentRangeElements(commentStart, searchStartElement.Parent);
            }
        }
        public static bool IsMatchingCommentEnd(OpenXmlElement element, string commentId)
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
