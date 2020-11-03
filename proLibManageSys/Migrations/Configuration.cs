namespace proLibManageSys.Migrations
{
	using proLibManageSys.Data;
	using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<proLibManageSys.Data.ModelsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(proLibManageSys.Data.ModelsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.book.AddOrUpdate(
                b => b.bookId,
                DummyData.GetBooks().ToArray()
                );
            context.SaveChanges();

            context.student.AddOrUpdate(
                s => s.studentId,
                DummyData.GetStudentDetails().ToArray()
                );
            context.SaveChanges();

            context.issuedBook.AddOrUpdate(
                i => i.issuedId,
                DummyData.GetIssuedBooks().ToArray()
                );
            context.SaveChanges();
        }
    }
}
