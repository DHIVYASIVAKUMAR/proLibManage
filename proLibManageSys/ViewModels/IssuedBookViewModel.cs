using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proLibManageSys.ViewModels
{
	public class IssuedBookViewModel
	{
		public int bookId { get; set; }
		public string bookName { get; set; }
		public string authorName { get; set; }
		public string branch { get; set; }
		public string publication { get; set; }
		public string studentName { get; set; }
		public string studentEmail { get; set; }
		public DateTime fromDate { get; set; }
		public DateTime toDate { get; set; }
		public int issuedId { get; set; }

		//public Books book { get; set; }
		//public Students student { get; set; }
		//public IssuedBooks issuedBook { get; set; }
	}
}