namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BursifyUserId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(),
                        Message = c.String(maxLength: 100),
                        Action = c.String(maxLength: 20),
                        ActionId = c.Int(),
                        Sender = c.String(maxLength: 50),
                        ReadStatus = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .Index(t => t.BursifyUserId);
            
            AddColumn("dbo.Campaign", "NumberOfViews", c => c.Int());
            AddColumn("dbo.StudentReport", "ReportFilePath", c => c.String());
            AddColumn("dbo.Sponsorship", "StartingDate", c => c.DateTime());
            AddColumn("dbo.Sponsorship", "InstitutionPreference", c => c.String());
            AddColumn("dbo.Sponsorship", "GenderPreference", c => c.String());
            AddColumn("dbo.Sponsorship", "RacePreference", c => c.String());
            AddColumn("dbo.Sponsorship", "DisabilityPreference", c => c.Boolean());
            DropColumn("dbo.Student", "AverageMark");
            DropColumn("dbo.Sponsorship", "PreferredInstitutions");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sponsorship", "PreferredInstitutions", c => c.String(maxLength: 500));
            AddColumn("dbo.Student", "AverageMark", c => c.Int());
            DropForeignKey("dbo.Notification", "BursifyUserId", "dbo.BursifyUser");
            DropIndex("dbo.Notification", new[] { "BursifyUserId" });
            DropColumn("dbo.Sponsorship", "DisabilityPreference");
            DropColumn("dbo.Sponsorship", "RacePreference");
            DropColumn("dbo.Sponsorship", "GenderPreference");
            DropColumn("dbo.Sponsorship", "InstitutionPreference");
            DropColumn("dbo.Sponsorship", "StartingDate");
            DropColumn("dbo.StudentReport", "ReportFilePath");
            DropColumn("dbo.Campaign", "NumberOfViews");
            DropTable("dbo.Notification");
        }
    }
}
