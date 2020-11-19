using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proLibManageSys.ViewModels
{
	public class BooksViewModel
	{		
		 public Books book{get; set;}
		 public List<Author> authors { get; set; }
		 public List<BookBranch> bookBranches { get; set; }
		 public List<BookPublication> bookPublications { get; set; }
	}
}