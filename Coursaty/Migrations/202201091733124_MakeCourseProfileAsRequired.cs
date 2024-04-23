namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCourseProfileAsRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "CoursePicture", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "CoursePicture", c => c.String());
        }
    }
}
