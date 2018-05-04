namespace video_rental_store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'93152d03-c5f6-4108-9888-05e89c1ab6ad', N'guest@video_rental_store.com', 0, N'AFpqpZ7GC4ZhfT5xMBIhAg+OxRTG35JSNIkavr21SC/bKVk4aXwF3mvjclM8mwuJvA==', N'd6e42102-4324-4c57-8db8-05b8a13b9ab6', NULL, 0, 0, NULL, 1, 0, N'guest@video_rental_store.com')

INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'ef8f088c-dd1e-440b-8bce-5a468975ae89', N'admin@vrs.com', 0, N'AGsIcOy///b7VboTgg80zOdIIj6b+eq0vZz03DC+sfcbV2NSGuD1xpL5nwzd92h3DA==', N'ff48b75e-1212-4c3d-b2f7-1dde660d7cb8', NULL, 0, 0, NULL, 1, 0, N'admin@vrs.com')

INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'dede03d2-1509-40ae-a7a0-806e5a26f786', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ef8f088c-dd1e-440b-8bce-5a468975ae89', N'dede03d2-1509-40ae-a7a0-806e5a26f786')

            ");

        }
        
        public override void Down()
        {
        }
    }
}
