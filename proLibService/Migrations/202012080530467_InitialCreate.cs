namespace proLibService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Books1", newName: "Books");
            RenameTable(name: "dbo.Students1", newName: "Students");
            DropTable("dbo.Books");
            DropTable("dbo.Students");
        }
        
        public override void Down()
        {
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
            
            RenameTable(name: "dbo.Students", newName: "Students1");
            RenameTable(name: "dbo.Books", newName: "Books1");
        }
    }
}
