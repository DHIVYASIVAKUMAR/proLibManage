namespace proLibService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentBranches", newName: "StudentBranchs");
            CreateTable(
                "dbo.Books1",
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
                "dbo.Students1",
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students1");
            DropTable("dbo.Books1");
            RenameTable(name: "dbo.StudentBranchs", newName: "StudentBranches");
        }
    }
}
