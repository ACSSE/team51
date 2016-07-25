namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentSponsorship", "SponsorshipConfirmed", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentSponsorship", "SponsorshipConfirmed");
        }
    }
}
