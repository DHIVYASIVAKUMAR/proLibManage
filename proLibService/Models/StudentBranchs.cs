using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
	public class StudentBranchs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int studentBranchId { get; set; }

		[Required(ErrorMessage = "Please enter branch name")]
		[Display(Name = "Branch")]
		public string studentBranch { get; set; }
	}
}
