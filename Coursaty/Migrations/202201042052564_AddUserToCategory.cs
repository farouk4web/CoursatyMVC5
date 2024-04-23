namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserToCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Categories", "UserId");
            AddForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Categories", new[] { "UserId" });
            DropColumn("dbo.Categories", "UserId");
        }
    }
}
