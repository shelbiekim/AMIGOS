using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigos.Models
{

    public class SendEmailViewModel
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Please enter an email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ToEmail { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        [StringLength(10000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        // alphanuemric and space
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Please enter only alphanumeric characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please enter the contents")]
        [AllowHtml]
        public string Contents { get; set; }
    }
}