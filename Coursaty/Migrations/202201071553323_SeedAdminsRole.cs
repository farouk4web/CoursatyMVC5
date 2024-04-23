namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminsRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'25ed3651-c7aa-44ff-9451-7da4bcad7ba7', N'Admins')");
        }
        
        public override void Down()
        {
        }
    }
}
