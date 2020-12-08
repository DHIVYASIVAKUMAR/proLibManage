namespace proLibService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        authorId = c.Int(nullable: false, identity: true),
                        authorName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.authorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        bookId = c.Int(nullable: false, identity: true),
                        bookName = c.String(nullable: false),
                        serialNumber = c.String(nullable: false),
                        authorName = c.String(nullable: false),
                        branch = c.String(nullable: false),
                        publications = c.String(nullable: false),
                        isAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.bookId);
            
            CreateTable(
                "dbo.BookBranches",
                c => new
                    {
                        bookBranchId = c.Int(nullable: false, identity: true),
                        branch = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.bookBranchId);
            
            CreateTable(
                "dbo.BookPublications",
                c => new
                    {
                        bookPublicationId = c.Int(nullable: false, identity: true),
                        publications = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.bookPublicationId);
            
            CreateTable(
                "dbo.IssuedBooks",
                c => new
                    {
                        issuedId = c.Int(nullable: false, identity: true),
                        bookId = c.Int(nullable: false),
                        studentId = c.Int(nullable: false),
                        fromDate = c.DateTime(nullable: false),
                        toDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.issuedId)
                .ForeignKey("dbo.Books", t => t.bookId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.studentId, cascadeDelete: true)
                .Index(t => t.bookId)
                .Index(t => t.studentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        studentId = c.Int(nullable: false, identity: true),
                        studentName = c.String(nullable: false, maxLength: 30),
                        studentBranch = c.String(nullable: false),
                        gender = c.Int(nullable: false),
                        phoneNumber = c.String(nullable: false),
                        address = c.String(nullable: false, maxLength: 150),
                        city = c.String(nullable: false, maxLength: 50),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.studentId);
            
            CreateTable(
                "dbo.StudentBranches",
                c => new
                    {
                        studentBranchId = c.Int(nullable: false, identity: true),
                        studentBranch = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.studentBranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IssuedBooks", "studentId", "dbo.Students");
            DropForeignKey("dbo.IssuedBooks", "bookId", "dbo.Books");
            DropIndex("dbo.IssuedBooks", new[] { "studentId" });
            DropIndex("dbo.IssuedBooks", new[] { "bookId" });
            DropTable("dbo.StudentBranches");
            DropTable("dbo.Students");
            DropTable("dbo.IssuedBooks");
            DropTable("dbo.BookPublications");
            DropTable("dbo.BookBranches");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
