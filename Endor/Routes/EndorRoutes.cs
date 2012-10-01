using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Endor.Routes
{
    public class EndorRoutes
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{file}.css");
            routes.IgnoreRoute("{file}.html");



            routes.MapRoute(
                name: "Article",
                url: "{year}/{month}/{day}/{slug}",
                defaults: new { controller = "Endor", action = "Article" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Endor", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
