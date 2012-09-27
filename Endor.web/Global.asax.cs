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
            EndorSetup();
            Setup_Templates();
            AreaRegistration.RegisterAllAreas();
            
            EndorRoutes.RegisterRoutes(RouteTable.Routes);
        }
        protected void EndorSetup()
        {
            Endor.Config.Title = "New Endor Blog!";
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