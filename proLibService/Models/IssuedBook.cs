using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
    public class IssuedBook
    {
        [Key]
        public int issuedId { get; set; }

        public int bookId { get; set; }
        [ForeignKey("bookId")]
        public Book books { get; set; }

        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public Student students { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required]
        [Display(Name = "From date")]
        public DateTime fromDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required]
        [Display(Name = "To date")]
        public DateTime toDate { get; set; }
    }
}