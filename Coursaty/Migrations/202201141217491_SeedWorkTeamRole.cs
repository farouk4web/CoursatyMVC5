namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedWorkTeamRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'61ec10f0-6185-495b-bd3f-fdd235d90911', N'WorkTeam')");
        }
        
        public override void Down()
        {
        }
    }
}
