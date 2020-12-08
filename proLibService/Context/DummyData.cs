//using proLibManageSys.Models;
//using System;
using proLibService.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace Test.Context
{
	public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
		protected override void Seed(DatabaseContext context)
		{
			base.Seed(context);
			context.SaveChanges();
		}
	}
}
