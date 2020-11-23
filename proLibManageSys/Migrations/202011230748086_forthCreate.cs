namespace proLibManageSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forthCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IssuedBooks", "fromDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.IssuedBooks", "toDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.IssuedBooks", "toDate", c => c.String(nullable: false));
            AlterColumn("dbo.IssuedBooks", "fromDate", c => c.String(nullable: false));
        }
    }
}
