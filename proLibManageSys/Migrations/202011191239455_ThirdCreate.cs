namespace proLibManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StudentBranches",
                c => new
                    {
                        studentBranchId = c.Int(nullable: false, identity: true),
                        studentBranch = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.studentBranchId);
            
            AlterColumn("dbo.Students", "gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "gender", c => c.String(nullable: false));
            DropTable("dbo.StudentBranches");
        }
    }
}
