namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7a12facb-83f4-4ee3-a48b-fe4100a8d7ac', N'admin@sarasa.com', 0, N'ACdzVc26TXF88rhV77U3clWK5A9YMYNJVEawOF3KJbFWGd5m2eTDB5Xo8HMpKQ9VKQ==', N'958c9094-7a37-4153-b463-228f76c677b6', NULL, 0, 0, NULL, 1, 0, N'admin@sarasa.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea4663b3-e454-4c94-b0da-038b8fb70086', N'sarasa@sarasa.com', 0, N'AMnwghAeWiykwcCLn8+4cktStZpIxCQCbMpBwLZ0HEJKVGwLp7o9oaMx2Zjt5+NLpA==', N'9f372d6a-08a6-4002-8817-44a18339e1c8', NULL, 0, 0, NULL, 1, 0, N'sarasa@sarasa.com')
                
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'92971f31-3e82-4a02-abe4-7da13968d3c7', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7a12facb-83f4-4ee3-a48b-fe4100a8d7ac', N'92971f31-3e82-4a02-abe4-7da13968d3c7')");
        }

        public override void Down()
        {
        }
    }
}
