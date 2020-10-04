using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Events across Australia";

            return View();
        }
        
        [Authorize]
        public ActionResult Resources()
        {
            ViewBag.Message = "Learning Resources";

            return View();
        }
    }
}