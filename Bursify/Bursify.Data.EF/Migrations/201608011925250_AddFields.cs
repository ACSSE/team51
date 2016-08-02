namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CampaignReport",
                c => new
                    {
                        CampaignId = c.Int(nullable: false),
                        BursifyUserId = c.Int(nullable: false),
                        Reason = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.CampaignId, t.BursifyUserId })
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .ForeignKey("dbo.Campaign", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.BursifyUserId);
            
            CreateTable(
                "dbo.BursifyUserCampaigns",
                c => new
                    {
                        BursifyUser_ID = c.Int(nullable: false),
                        Campaign_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BursifyUser_ID, t.Campaign_ID })
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.Campaign", t => t.Campaign_ID, cascadeDelete: true)
                .Index(t => t.BursifyUser_ID)
                .Index(t => t.Campaign_ID);
            
            AddColumn("dbo.StudentSponsorship", "SponsorshipOffered", c => c.String(nullable: false));
            AddColumn("dbo.Subject", "Period", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CampaignReport", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.CampaignReport", "BursifyUserId", "dbo.BursifyUser");
            DropForeignKey("dbo.BursifyUserCampaigns", "Campaign_ID", "dbo.Campaign");
            DropForeignKey("dbo.BursifyUserCampaigns", "BursifyUser_ID", "dbo.BursifyUser");
            DropIndex("dbo.BursifyUserCampaigns", new[] { "Campaign_ID" });
            DropIndex("dbo.BursifyUserCampaigns", new[] { "BursifyUser_ID" });
            DropIndex("dbo.CampaignReport", new[] { "BursifyUserId" });
            DropIndex("dbo.CampaignReport", new[] { "CampaignId" });
            DropColumn("dbo.Subject", "Period");
            DropColumn("dbo.StudentSponsorship", "SponsorshipOffered");
            DropTable("dbo.BursifyUserCampaigns");
            DropTable("dbo.CampaignReport");
        }
    }
}
