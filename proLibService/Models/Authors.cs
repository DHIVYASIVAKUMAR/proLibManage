using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace proLibManageSys.Models
{
	public class Authors
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int authorId { get; set; }

		[Required(ErrorMessage = "please enter Author Name")]
		[Display(Name = "Author Name")]
		public string authorName { get; set; }

	}
	public class BookBranchs
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int bookBranchId { get; set; }

		[Required(ErrorMessage = "please enter Branch")]
		[Display(Name = "Branch")]
		public string branch { get; set; }
	}

	public class BookPublications
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int bookPublicationId { get; set; }

		[Required(ErrorMessage = "please enter Publications")]
		[Display(Name = "Publications")]
		public string publications { get; set; }
	}
}