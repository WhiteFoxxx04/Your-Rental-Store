namespace RentStation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd3c8484b-3282-4c8a-979a-467685ae99ff', N'admin@rentstation.com', 0, N'ADgjEJl2cfTpl1yj4aH6/FrJpvcMYMD2G4DOgBkDjhF3mq67Th7dcJyXGwPkXAl/dg==', N'688898ec-4fca-4c3c-8891-c259d034e8e2', NULL, 0, 0, NULL, 1, 0, N'admin@rentstation.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'feb136a9-4f71-44ef-947c-929b85b52e65', N'guest@rentstation.com', 0, N'AGv0imLP0/WDHCP70Wo+9MSGKEnLyisPIsVIMsMAT/QRAYD/W8oYtX64Y1C0eMs3Bg==', N'837241f3-ae18-49ab-a2b4-80a76a47ebb6', NULL, 0, 0, NULL, 1, 0, N'guest@rentstation.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'dbf4c506-0a02-4db4-a20c-19af527ceec9', N'CanManageMoviesAndGames')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'd3c8484b-3282-4c8a-979a-467685ae99ff', N'dbf4c506-0a02-4db4-a20c-19af527ceec9')
");
        }
        
        public override void Down()
        {
        }
    }
}
