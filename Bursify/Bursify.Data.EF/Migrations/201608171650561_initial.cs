namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddress", "Province", c => c.String(maxLength: 200));
            AlterColumn("dbo.UserAddress", "PreferredAddress", c => c.String());
            DropColumn("dbo.UserAddress", "Suburb");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddress", "Suburb", c => c.String(maxLength: 200));
            AlterColumn("dbo.UserAddress", "PreferredAddress", c => c.Boolean());
            DropColumn("dbo.UserAddress", "Province");
        }
    }
}
