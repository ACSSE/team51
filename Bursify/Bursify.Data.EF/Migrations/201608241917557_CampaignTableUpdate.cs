namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignTableUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "ID", "dbo.BursifyUser");
            CreateTable(
                "dbo.CampaignAccount",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        AccountName = c.String(nullable: false, maxLength: 200),
                        AccountNumber = c.String(nullable: false, maxLength: 50),
                        BankName = c.String(nullable: false, maxLength: 50),
                        BranchName = c.String(maxLength: 50),
                        BranchCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Campaign", t => t.ID)
                .Index(t => t.ID);
            
            AddForeignKey("dbo.Account", "ID", "dbo.Sponsor", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "ID", "dbo.Sponsor");
            DropForeignKey("dbo.CampaignAccount", "ID", "dbo.Campaign");
            DropIndex("dbo.CampaignAccount", new[] { "ID" });
            DropTable("dbo.CampaignAccount");
            AddForeignKey("dbo.Account", "ID", "dbo.BursifyUser", "ID");
        }
    }
}
