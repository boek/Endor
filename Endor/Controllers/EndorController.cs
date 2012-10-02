using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Endor.Models;

namespace Endor.Controllers
{
    public class EndorController : Controller
    {
        private Articles Articles = new Articles();

        public ActionResult Index(string view = "")
        {            
            if(string.IsNullOrEmpty(view))
            {
                return View(Articles);
            }
            
            return View(view);
        }

        public ActionResult Archives()
        {
            return View(Articles);
        }

        public ActionResult Article(string Year, string Month, string Day, string Slug)
        {
            Article article = (from Article art in Articles
                               where art.Slug() == Slug
                               select art).FirstOrDefault();
                              
            return View(article);
        }
    }
}
