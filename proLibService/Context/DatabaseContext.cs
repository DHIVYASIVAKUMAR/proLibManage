﻿using proLibManageSys.Models;
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
      public DbSet<Books> book { get; set; }
      public DbSet<Students> student { get; set; }
      public DbSet<IssuedBooks> issuedBook { get; set; }
      public DbSet<Author> author { get; set; }
      public DbSet<BookBranch> bookBranch { get; set; }
      public DbSet<BookPublication> bookPublication { get; set; }
      public DbSet<StudentBranch> studentBranches { get; set; }

	}
}
