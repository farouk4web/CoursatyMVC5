namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [FullName], [ProfilePicture]) VALUES (N'dcbfca82-5147-4551-bee2-ba2ba1ae4241', N'farouk@coursaty.com', 0, N'AMdi6kWiXmbSrYNiHhYuL6dAS2gxx95ve681Gjhe9BefVpA6mKRFOZ4xVUbdi8vO8w==', N'1490fc8b-ec15-4bfc-b96a-6afc49534776', NULL, 0, 0, NULL, 1, 0, N'farouk@coursaty.com', N'Farouk Abdelhamid', NULL)");
        }
        
        public override void Down()
        {
        }
    }
}
