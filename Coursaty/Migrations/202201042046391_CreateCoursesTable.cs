namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCoursesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 200),
                        Instructor = c.String(nullable: false, maxLength: 60),
                        Link = c.String(nullable: false),
                        CoursePicture = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Likes = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "UserId" });
            DropTable("dbo.Courses");
        }
    }
}
