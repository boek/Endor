using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarkdownSharp;
using System.Text.RegularExpressions;

namespace Endor.ExtensionMethods
{
    public static class EndorStrings
    {
        public static string MarkdownIt(this string value)
        {
            Markdown md = new Markdown();

            return md.Transform(value);
        }

        public static string Humanize(this string value)
        {
            return Regex.Replace(value, "[^A-Za-z0-9 _]"," ");
        }
    }
}
