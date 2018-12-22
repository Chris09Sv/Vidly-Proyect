namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'465b4c7a-1016-4509-84fe-a4e3671ba105', N'admin@solano.com', 0, N'ALPvb1jZTt5P0gVs2Ol4Uj/YAeb7r7ykxJvmK4icxhurHkClloFwECURo1CJx2u48g==', N'e70b676a-ceee-4df7-9c07-1dfac52659b2', NULL, 0, 0, NULL, 1, 0, N'admin@solano.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e58bf33-050f-4d94-bd97-f7bc04064b98', N'csolano469@gmail.com', 0, N'AA8sl1q/uUhOWDV3wuwEcvaOxhdTWwFWfMZ/fIuYaDHzqBIbiWzhkioK2wLeilkw6g==', N'dc7c5d5b-20a7-4bb2-a753-03a8038b71d6', NULL, 0, 0, NULL, 1, 0, N'csolano469@gmail.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1e87e4a8-cd27-4598-93b4-729385ab0996', N'canManageMovie')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'465b4c7a-1016-4509-84fe-a4e3671ba105', N'1e87e4a8-cd27-4598-93b4-729385ab0996')


");
        }
        
        public override void Down()
        {
        }
    }
}
