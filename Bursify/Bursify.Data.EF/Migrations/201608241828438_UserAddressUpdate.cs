namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddressUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddress", "StreetAddress", c => c.String(maxLength: 200));
            AlterColumn("dbo.UserAddress", "PostOfficeBoxNumber", c => c.String());
            DropColumn("dbo.UserAddress", "HouseNumber");
            DropColumn("dbo.UserAddress", "StreetName");
            DropColumn("dbo.UserAddress", "PostOfficeName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAddress", "PostOfficeName", c => c.String(maxLength: 200));
            AddColumn("dbo.UserAddress", "StreetName", c => c.String(maxLength: 200));
            AddColumn("dbo.UserAddress", "HouseNumber", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserAddress", "PostOfficeBoxNumber", c => c.Long());
            DropColumn("dbo.UserAddress", "StreetAddress");
        }
    }
}
