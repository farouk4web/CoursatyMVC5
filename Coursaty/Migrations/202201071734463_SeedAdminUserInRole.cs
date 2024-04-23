namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminUserInRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dcbfca82-5147-4551-bee2-ba2ba1ae4241', N'25ed3651-c7aa-44ff-9451-7da4bcad7ba7')");
        }
        
        public override void Down()
        {
        }
    }
}
