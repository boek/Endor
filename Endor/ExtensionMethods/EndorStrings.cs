using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkdownSharp;

namespace Endor.ExtensionMethods
{
    public static class EndorStrings
    {
        public static string MarkdownIt(this string value)
        {
            Markdown md = new Markdown();

            return md.Transform(value);
        }
    }
}
