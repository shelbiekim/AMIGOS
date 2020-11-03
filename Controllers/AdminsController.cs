using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amigos.Models;
using Amigos.Utils;

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

        [Authorize]
        public ActionResult Send_Email()
        {
            if (User.IsInRole("Administrator"))
            {
                return View(new SendEmailViewModel());
            }
            // redirect logged-in users who are not administrators
            else
            {

                return Redirect("~/Home");
            }
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (User.IsInRole("Administrator"))
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
            // redirect logged-in users who are not administrators
            else
            {

                return Redirect("~/Home");
            }
            
        }
    }
}