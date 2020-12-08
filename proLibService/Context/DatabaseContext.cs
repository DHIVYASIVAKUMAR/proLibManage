using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proLibService.Context
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext() : base("DefaultConnection")
        { }
      public DbSet<Book> book { get; set; }
      public DbSet<Student> student { get; set; }
      public DbSet<IssuedBook> issuedBook { get; set; }
      public DbSet<Authors> author { get; set; }
      public DbSet<BookBranch> bookBranch { get; set; }
      public DbSet<BookPublication> bookPublication { get; set; }
      public DbSet<StudentBranchs> studentBranches { get; set; }

	}
}
