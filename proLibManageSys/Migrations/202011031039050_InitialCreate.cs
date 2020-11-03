namespace proLibManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookId = c.Int(nullable: false, identity: true),
                        bookName = c.String(nullable: false),
                        authorName = c.String(nullable: false),
                        serialNumber = c.String(nullable: false),
                        branch = c.String(nullable: false),
                        publications = c.String(nullable: false),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.bookId);
            
            CreateTable(
                "dbo.IssuedBooks",
                c => new
                    {
                        issuedId = c.Int(nullable: false, identity: true),
                        issuedBookName = c.String(nullable: false),
                        issuedAuthorName = c.String(nullable: false),
                        issuedBookBranch = c.String(nullable: false),
                        issuedBookPublications = c.String(nullable: false),
                        issuedStudentName = c.String(nullable: false, maxLength: 30),
                        issuedStudentEmail = c.String(nullable: false),
                        fromDate = c.String(nullable: false),
                        toDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.issuedId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentId = c.Int(nullable: false, identity: true),
                        studentName = c.String(nullable: false, maxLength: 30),
                        studentBranch = c.String(nullable: false),
                        gender = c.String(nullable: false),
                        phoneNumber = c.String(nullable: false),
                        address = c.String(nullable: false, maxLength: 150),
                        city = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.studentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.IssuedBooks");
            DropTable("dbo.Books");
        }
    }
}
