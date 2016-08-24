namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountTableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BursifyUserCampaigns", newName: "CampaignBursifyUsers");
            DropForeignKey("dbo.Account", "ID", "dbo.Campaign");
            DropPrimaryKey("dbo.CampaignBursifyUsers");
            AddColumn("dbo.Account", "CardNumber", c => c.String());
            AddColumn("dbo.Account", "ExpirationYear", c => c.Long());
            AddColumn("dbo.Account", "ExpirationMonth", c => c.Int());
            AddColumn("dbo.Account", "CvvNumber", c => c.Int());
            AddPrimaryKey("dbo.CampaignBursifyUsers", new[] { "Campaign_ID", "BursifyUser_ID" });
            AddForeignKey("dbo.Account", "ID", "dbo.BursifyUser", "ID");
            DropColumn("dbo.Account", "AccountNumber");
            DropColumn("dbo.Account", "BankName");
            DropColumn("dbo.Account", "BranchName");
            DropColumn("dbo.Account", "BranchCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "BranchCode", c => c.String(maxLength: 50));
            AddColumn("dbo.Account", "BranchName", c => c.String(maxLength: 50));
            AddColumn("dbo.Account", "BankName", c => c.String(maxLength: 50));
            AddColumn("dbo.Account", "AccountNumber", c => c.String(maxLength: 50));
            DropForeignKey("dbo.Account", "ID", "dbo.BursifyUser");
            DropPrimaryKey("dbo.CampaignBursifyUsers");
            DropColumn("dbo.Account", "CvvNumber");
            DropColumn("dbo.Account", "ExpirationMonth");
            DropColumn("dbo.Account", "ExpirationYear");
            DropColumn("dbo.Account", "CardNumber");
            AddPrimaryKey("dbo.CampaignBursifyUsers", new[] { "BursifyUser_ID", "Campaign_ID" });
            AddForeignKey("dbo.Account", "ID", "dbo.Campaign", "ID");
            RenameTable(name: "dbo.CampaignBursifyUsers", newName: "BursifyUserCampaigns");
        }
    }
}
