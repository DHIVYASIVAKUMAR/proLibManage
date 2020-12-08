using ProLibraryService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProLibraryService.DataContext
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            
            var newBook = new List<ServiceBooks> {
                new ServiceBooks()
                {
                serviceBookName = "Harry Potter",
                serviceAuthorName = "J.K Rowling",
                serviceSerialNumber = "1001",
                serviceBranch = "Stories",
                servicePublications = "Bloomsbury",
                serviceIsAvailable = false
                }
            };
            context.SaveChanges();
        }
    }
}