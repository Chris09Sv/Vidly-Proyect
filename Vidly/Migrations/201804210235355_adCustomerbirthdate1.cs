namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adCustomerbirthdate1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate= '24,marzo 1995' WHERE Id=1");
            Sql("UPDATE Customers SET Birthdate= '24,marzo 1995' WHERE Id=1");
        }
        
        public override void Down()
        {
        }
    }
}
