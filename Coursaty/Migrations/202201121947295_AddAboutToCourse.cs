namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAboutToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "About", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "About");
        }
    }
}
