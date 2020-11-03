using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
	public class IssuedBooks
	{
        [Key]
        public int issuedId { get; set; }

        [Required(ErrorMessage = "please enter Book Name")]
        [Display(Name = "Book Name")]
        public string issuedBookName { get; set; }

        [Required(ErrorMessage = "please enter Author Name")]
        [Display(Name = "Author Name")]
        public string issuedAuthorName { get; set; }

        [Required(ErrorMessage = "please enter Branch")]
        [Display(Name = "Branch")]
        public string issuedBookBranch { get; set; }

        [Required(ErrorMessage = "please enter Publications")]
        [Display(Name = "Publications")]
        public string issuedBookPublications { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = " Name ")]
        public string issuedStudentName { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string issuedStudentEmail { get; set; }

        [Required(ErrorMessage = "please enter in \"dd-mm-yyyy\"this format")]
        [Display(Name = "From date")]
        public string fromDate { get; set; }

        [Required(ErrorMessage = "please enter in \"dd-mm-yyyy\"this format")]
        [Display(Name = "To date")]
        public string toDate { get; set; }
    }
}