namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Subject", "SubjectLevel", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Subject", "SubjectLevel");
        }
    }
}
