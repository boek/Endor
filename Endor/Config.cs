using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Endor
{
    public static class Config
    {
        public static string Author
        {
            get;
            set;            
        }

        public static string Title
        {
            get;
            set;
        }

        public static string ArticlesPath
        {
            get;
            set;
        }

        public static string Root
        {
            get;
            set;
        }

        public static string Url
        {
            get;
            set;
        }

        public static string Prefix
        {
            get;
            set;
        }

        public static string Date
        {
            get;
            set;
        }

        public static bool Markdown
        {
            get;
            set;
        }

        public static bool Disqus
        {
            get;
            set;
        }

        public static int SummaryLength
        {
            get;
            set;
        }
        public static char SummaryDelim
        {
            get;
            set;
        }

        public static string Extension
        {
            get;
            set;
        }

        public static int Cache
        {
            get;
            set;
        }

        public static string Error
        {
            get;
            set;
        }

        static Config()
        {
            Author = Environment.UserName; // Blog Author
            Title = "My new Endor blog!"; // Site Title
            ArticlesPath = "Articles"; // Site Title
            Root = "index"; // site index
            Url = "localhost"; // root URL of the site
            Prefix = ""; // common path prefix for the blog
            Date = DateTime.Now.ToShortDateString(); // Date format
            Markdown = true; //Use Markdown
            Disqus = false; //Disqus id, or false
            SummaryLength = 150;
            SummaryDelim = '~';
            Extension = "txt"; //File extension
            Cache = 28800; //Cache duration, in seconds
            Error = "<font style='font-size:300%'>toto, we're not in Kansas anymore (#{code})</font>"; //custom error
        }
    }
}
