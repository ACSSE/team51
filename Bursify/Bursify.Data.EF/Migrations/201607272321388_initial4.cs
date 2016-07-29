namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "StudyField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "StudyField");
        }
    }
}
