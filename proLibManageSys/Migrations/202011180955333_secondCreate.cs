namespace proLibManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondCreate : DbMigration
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
            
            AddColumn("dbo.IssuedBooks", "bookId", c => c.Int(nullable: false));
            AddColumn("dbo.IssuedBooks", "studentId", c => c.Int(nullable: false));
            CreateIndex("dbo.IssuedBooks", "bookId");
            CreateIndex("dbo.IssuedBooks", "studentId");
            AddForeignKey("dbo.IssuedBooks", "bookId", "dbo.Books", "bookId", cascadeDelete: true);
            AddForeignKey("dbo.IssuedBooks", "studentId", "dbo.Students", "studentId", cascadeDelete: true);
            DropColumn("dbo.IssuedBooks", "issuedBookName");
            DropColumn("dbo.IssuedBooks", "issuedAuthorName");
            DropColumn("dbo.IssuedBooks", "issuedBookBranch");
            DropColumn("dbo.IssuedBooks", "issuedBookPublications");
            DropColumn("dbo.IssuedBooks", "issuedStudentName");
            DropColumn("dbo.IssuedBooks", "issuedStudentEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IssuedBooks", "issuedStudentEmail", c => c.String(nullable: false));
            AddColumn("dbo.IssuedBooks", "issuedStudentName", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.IssuedBooks", "issuedBookPublications", c => c.String(nullable: false));
            AddColumn("dbo.IssuedBooks", "issuedBookBranch", c => c.String(nullable: false));
            AddColumn("dbo.IssuedBooks", "issuedAuthorName", c => c.String(nullable: false));
            AddColumn("dbo.IssuedBooks", "issuedBookName", c => c.String(nullable: false));
            DropForeignKey("dbo.IssuedBooks", "studentId", "dbo.Students");
            DropForeignKey("dbo.IssuedBooks", "bookId", "dbo.Books");
            DropIndex("dbo.IssuedBooks", new[] { "studentId" });
            DropIndex("dbo.IssuedBooks", new[] { "bookId" });
            DropColumn("dbo.IssuedBooks", "studentId");
            DropColumn("dbo.IssuedBooks", "bookId");
            DropTable("dbo.BookPublications");
            DropTable("dbo.BookBranches");
            DropTable("dbo.Authors");
        }
    }
}
