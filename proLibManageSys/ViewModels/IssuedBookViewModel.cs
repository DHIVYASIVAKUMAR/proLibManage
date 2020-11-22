using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proLibManageSys.ViewModels
{
	public class IssuedBookViewModel
	{
		public Books book { get; set; }
		public Students student { get; set; }
		public IssuedBooks issuedBook { get; set; }
	}
}