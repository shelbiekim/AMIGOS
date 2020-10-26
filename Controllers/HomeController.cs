using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amigos.Models;
using Amigos.Utils;

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

        [Authorize]
        public ActionResult Study_List()
        {
            ViewBag.Message = "Study List";

            return View();
        }

        public ActionResult Send_Email()
        {
            return View(new SendEmailViewModel());
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents);

                    ViewBag.Result = "Email has been sent.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}