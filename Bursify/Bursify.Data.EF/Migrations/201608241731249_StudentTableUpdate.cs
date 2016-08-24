namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTableUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Headline", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "Headline");
        }
    }
}
