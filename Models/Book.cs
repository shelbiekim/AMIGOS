//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Amigos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public int Id { get; set; }

        [Required]
        // alphanuemric and space
        [RegularExpression(@"^[a-zA-Z0-9 ]+$", ErrorMessage = "Please enter only alphanumeric characters")]
        public string Title { get; set; }

        [Required]
        // numeric
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter the valid TotalPages")]
        public int TotalPages { get; set; }

        [Required]
        // between 10 and 13
        [RegularExpression(@"^\d{10,13}$", ErrorMessage = "Please enter between 10 and 13 digit number")]
        public string ISBN { get; set; }
        [Required]
        public System.DateTime PublishedDate { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherId { get; set; }
        [Required]
        public int ImageId { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Image Image { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
