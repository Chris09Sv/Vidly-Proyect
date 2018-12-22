namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Release_Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Date_Add", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Date_Add", c => c.DateTime());
            AlterColumn("dbo.Movies", "Release_Date", c => c.DateTime());
        }
    }
}
