using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Amigos.Utils
{
    [ValidateInput(false)]
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "";

        
        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("kimshelbie@gmail.com", "AMIGOS");
            var to = new EmailAddress("shelbkim@gmail.com", "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("C:\\Users\\user\\source\\repos\\Amigos\\AMIGOS_Newsletter.html");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("Newsletter.html", file);
            var response = client.SendEmailAsync(msg);
        }
    }
}