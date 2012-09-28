using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Endor.ExtensionMethods;
using System.Collections;
using System.Text.RegularExpressions;

namespace Endor.Models
{
    public class Article
    {
        public string title { get; set; }
        public DateTime date { get; set; }        
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
            
            Match match = Regex.Match(path, @"(\d{4}-\d{2}-\d{2})([^\/]*$)");
            if (match.Success)
            {
                date = Convert.ToDateTime(match.Groups[1].Value);
                title = match.Groups[2].Value;
            }
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

    public class Articles : IEnumerable<Article>
    {
        private string[] filePaths;
        private List<Article> articles = new List<Article>();

        public Articles()
        {
            filePaths = Directory.GetFiles(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Config.ArticlesPath), "*." + Config.Extension);
            foreach (string path in filePaths)
            {
                articles.Add(new Article(path));
            }
        }

        IEnumerator<Article> IEnumerable<Article>.GetEnumerator()
        {
            return (IEnumerator<Article>)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new ArticlesEnumerator(this);
        }
        
        private class ArticlesEnumerator : IEnumerator
        {
            private int position = -1;
            private Articles a;

            public ArticlesEnumerator(Articles a)
            {
                this.a = a;
            }

            public bool MoveNext()
            {
                if (position < a.articles.Count - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get
                {
                    return a.articles[position];
                }
            }

        }
        
    }
}
