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

        public ActionResult Index()
        {            
            return View(Articles);
        }
        
        public ActionResult Article(string Year, string Month, string Day, string Slug)
        {            
            return View();
        }
    }
}
