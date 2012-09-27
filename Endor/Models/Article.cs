using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Endor.ExtensionMethods;

namespace Endor.Models
{
    public class Article
    {
        public string title { get; set; }
        public DateTime date { get; set; }
        public string author { get; set; }
        private string text { get; set; }

        public Article(string path)
        {
            Load(path);
        }

        public void Load(string path)
        {
            StreamReader sr = new StreamReader(path);
            string parts = sr.ReadToEnd();
            sr.Close();

        }

        public string Summary()
        {
            string summary;
            if (text.Contains(Config.SummaryDelim))
            {
                summary = text.Trim(Config.SummaryDelim);
            }else{
                summary = text.Substring(0, Config.SummaryLength);
            }
            return Config.Markdown ? summary.MarkdownIt() : summary;
        }

        public string body()
        {
            return Config.Markdown ? text.MarkdownIt() : text;
        }
    }
}
