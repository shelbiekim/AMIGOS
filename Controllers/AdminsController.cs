using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigos.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        [Authorize]
        public ActionResult Index()
        {
            if (User.IsInRole("Administrator"))
            {
                return View();
            }
            // redirect logged-in users who are not administrators
            else
            {
                return Redirect("~/Home");
            }
        }
    }
}