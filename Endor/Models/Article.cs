using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Endor.ExtensionMethods;
using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Endor.Models
{
    public class Article
    {        
        private Hashtable meta { get; set; }
        public DateTime date { get; set; }        
        private string text { get; set; }

        public Article(string path)
        {
            Load(path);
        }

        private void Load(string path)
        {
            StreamReader sr = new StreamReader(path);
            string[] parts = Regex.Split(sr.ReadToEnd(), "\r\n\r\n");
            sr.Close();

            Match match = Regex.Match(path, @"(\d{4}-\d{2}-\d{2})");
            if (match.Success)
            {
                date = Convert.ToDateTime(match.Groups[1].Value);                
            }
            meta = JsonConvert.DeserializeObject<Hashtable>(parts[0].Replace(System.Environment.NewLine, ""));
            text = parts[1].Replace(System.Environment.NewLine, "");
        }

        public string Title()
        {
            return meta.ContainsKey("title") ? meta["title"].ToString().Humanize() : "An Article";
        }

        public string Slug()
        {
            return meta.ContainsKey("slug") ? meta["slug"].ToString() : meta["title"].ToString().Slugize();
        }

        public string Path()
        {
            return string.Format("/{0}{1}/{2}", Config.Prefix, date.ToString("yyyy/MM/d"), Slug());
        }

        public string Summary()
        {
            string summary;
            if (text.Contains(Config.SummaryDelim))
            {
                summary = text.Trim(Config.SummaryDelim);
            }else{
                summary = text.Substring(0, Math.Min(text.Length, Config.SummaryLength));                
            }
            return Config.Markdown ? summary.MarkdownIt() : summary;
        }

        public string Date()
        {
            return date.ToString("MMMM d yyyy");
        }
        public string body()
        {
            return Config.Markdown ? text.MarkdownIt() : text;
        }
    }

    public class Articles : IEnumerable
    {
        private string[] filePaths;
        private Article[] _articles;

        public Articles()
        {
            filePaths = Directory.GetFiles(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, Config.ArticlesPath), "*." + Config.Extension);
            for (int i = 0; i < filePaths.Length; i++)
            {
                _articles[i] = new Article(filePaths[i]);
            }
            _articles = _articles.OrderByDescending(a => a.date).ToArray();
        }

        public IEnumerator<Article> GetEnumerator()
        {
            return new ArticleEnum(_articles);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class ArticleEnum : IEnumerator
    {
        public Article[] _articles;
        int position = -1;

        public PeopleEnum(Article[] list)
        {
            _articles = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _articles.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Article Current
        {
            get
            {
                try
                {
                    return _articles[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
       
}
