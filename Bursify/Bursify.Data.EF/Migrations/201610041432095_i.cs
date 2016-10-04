namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class i : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaign", "NumberOfViews", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaign", "NumberOfViews");
        }
    }
}
