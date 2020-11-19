using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
	public class Students
	{
        [Key]
        public int studentId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
        [Display(Name = " Name ")]
        public string studentName { get; set; }

        [Required(ErrorMessage = "Please enter branch name")]
        [Display(Name = "Branch")]
        public string studentBranch { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        [Display(Name = "Gender")]
        public Gender gender { get; set; }


        [Required(ErrorMessage = "please enter phone number")]
        [Display(Name = " Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "enter valid phone number")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [Display(Name = "Address")]
        [StringLength(150)]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string city { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(10, ErrorMessage = "Must be between 5 and 10 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //public virtual ICollection<IssuedBooks> issuedBooks { get; set; }
    }
    public enum Gender { 
     Male,Female,Genderless
    }
   
}