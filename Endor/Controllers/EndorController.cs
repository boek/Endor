using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Endor.Controllers
{
    public class EndorController : Controller
    {
        public ActionResult Index()
        {
            return View("index");
        }
    }
}
