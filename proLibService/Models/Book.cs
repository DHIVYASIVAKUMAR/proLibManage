using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
	public class Book
    {
        [Key]
        public int bookId { get; set; }

        [Required(ErrorMessage = "please enter Book Name")]
        [Display(Name = "Book Name")]
        public string bookName { get; set; }

        [Required(ErrorMessage = "please enter serial number")]
        [Display(Name = "Serial Number")]
        public string serialNumber { get; set; }

        [Required(ErrorMessage = "please enter Author Name")]
        [Display(Name = "Author Name")]
        public string authorName { get; set; }

        [Required(ErrorMessage = "please enter Branch")]
        [Display(Name = "Branch")]
        public string branch { get; set; }

        [Required(ErrorMessage = "please enter Publications")]
        [Display(Name = "Publications")]
        public string publications { get; set; }
        [Display(Name = "IsAvailable")]
        public bool isAvailable { get; set; }
    }
}