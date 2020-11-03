using proLibManageSys.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace proLibManageSys.Data
{
	public class ModelsContext : DbContext
	{
		public ModelsContext() : base("DefaultConnection")
		{ }
		public DbSet<Books> book { get; set; }
		public DbSet<Students> student { get; set; }
		public DbSet<IssuedBooks> issuedBook { get; set; }

	}
}