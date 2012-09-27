using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MarkdownSharp;

namespace Endor.Models
{
    public class Article
    {
        public string title { get; set; }
        public DateTime date { get; set; }
        public string author { get; set; }
        private string text { get; set; }

        private Config config { get; set; }

        public Article(string path, Config conf)
        {
            config = conf;
            Load(path);
        }

        public void Load(string path)
        {
            StreamReader sr = new StreamReader(path);
            string parts = sr.ReadToEnd();
            sr.Close();

        }

        public string body()
        {
            if (Config.Markdown)
            {
                Markdown md = new Markdown();
                return md.Transform(text);
            }
            else
            {
                return text;
            }
        }
    }
}
