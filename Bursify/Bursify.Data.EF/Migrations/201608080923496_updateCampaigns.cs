namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCampaigns : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CampaignSponsor");
            AddColumn("dbo.CampaignSponsor", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CampaignSponsor", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CampaignSponsor");
            DropColumn("dbo.CampaignSponsor", "ID");
            AddPrimaryKey("dbo.CampaignSponsor", new[] { "CampaignId", "SponsorId" });
        }
    }
}
