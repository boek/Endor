using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Endor.Routes;
using Endor.ViewEngine;

namespace Endor.web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Setup_Endor();
            Setup_Templates();
            AreaRegistration.RegisterAllAreas();
            
            EndorRoutes.RegisterRoutes(RouteTable.Routes);
        }        
        protected void Setup_Endor()
        {
            Config.Author = "Jeff Boek"; // Blog Author
            Config.Title = "My new Endor blog!"; // Site Title
            //Config.ArticlesPath = "Articles"; // Articles Path
            //Config.Root = "index"; // site index
            //Config.Url = "localhost"; // root URL of the site
            //Config.Prefix = ""; // common path prefix for the blog
            //Config.Date = DateTime.Now.ToShortDateString(); // Date format
            //Config.Markdown = true; //Use Markdown
            //Config.Disqus = false; //Disqus id, or false
            //Config.SummaryLength = 150; // Summary Length
            //Config.SummaryDelim = '~';  // Delimiter
            //Config.Extension = "txt"; //File extension
            //Config.Cache = 28800; //Cache duration, in seconds
            //Config.Error = "<font style='font-size:300%'>toto, we're not in Kansas anymore (#{code})</font>"; //custom error            
        }
        protected void Setup_Templates()
        {
            ViewEngines.Engines.Clear();

            ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
            engine.AddViewLocationFormat("~/Templates/{1}/{0}.cshtml");

            // Add a shared location too, as the lines above are controller specific
            engine.AddPartialViewLocationFormat("~/Templates/{0}.cshtml");

            ViewEngines.Engines.Add(engine);
        }
    }
}