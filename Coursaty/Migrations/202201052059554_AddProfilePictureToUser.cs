namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfilePictureToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfilePicture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfilePicture");
        }
    }
}
