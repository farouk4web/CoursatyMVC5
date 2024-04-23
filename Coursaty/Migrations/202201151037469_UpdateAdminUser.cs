namespace Coursaty.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdminUser : DbMigration
    {
        public override void Up()
        {
            Sql(@" 
                    Update AspNetUsers
                    Set ProfilePicture = '/content/images/user.png', SignDate ='01/01/2022 12:00:00'
                    Where Id ='dcbfca82-5147-4551-bee2-ba2ba1ae4241'
                ");
        }
        
        public override void Down()
        {
        }
    }
}
