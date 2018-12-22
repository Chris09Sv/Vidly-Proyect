namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Release_Date", c => c.DateTime());
            AlterColumn("dbo.Movies", "Date_Add", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Date_Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "Release_Date", c => c.DateTime(nullable: false));
        }
    }
}
