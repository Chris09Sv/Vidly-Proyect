namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class prueba : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'4e58bf33-050f-4d94-bd97-f7bc04064b98', N'csolano469@gmail.com', 0, N'AA8sl1q/uUhOWDV3wuwEcvaOxhdTWwFWfMZ/fIuYaDHzqBIbiWzhkioK2wLeilkw6g==', N'dc7c5d5b-20a7-4bb2-a753-03a8038b71d6', NULL, 0, 0, NULL, 1, 0, N'csolano469@gmail.com', N'')
                 
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e87e4a8-cd27-4598-93b4-729385ab0996', N'canManageMovie')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e58bf33-050f-4d94-bd97-f7bc04064b98', N'1e87e4a8-cd27-4598-93b4-729385ab0996')


");
        }
        
        public override void Down()
        {
        }
    }
}
