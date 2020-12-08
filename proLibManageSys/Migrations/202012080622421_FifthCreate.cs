namespace proLibManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FifthCreate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StudentBranches", newName: "StudentBranchs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.StudentBranchs", newName: "StudentBranches");
        }
    }
}
