namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
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
            
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CampaignName = c.String(nullable: false, maxLength: 200),
                        Tagline = c.String(maxLength: 200),
                        Location = c.String(nullable: false, maxLength: 500),
                        Description = c.String(nullable: false),
                        AmountRequired = c.Double(nullable: false),
                        CampaignType = c.String(nullable: false, maxLength: 50),
                        VideoPath = c.String(maxLength: 200),
                        PicturePath = c.String(maxLength: 200),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AmountContributed = c.Double(nullable: false),
                        FundUsage = c.String(nullable: false),
                        ReasonsToSupport = c.String(),
                        NumberOfUpVotes = c.Int(),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
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
                "dbo.BursifyUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(nullable: false),
                        PasswordSalt = c.String(nullable: false),
                        AccountStatus = c.String(nullable: false),
                        UserType = c.String(nullable: false, maxLength: 50),
                        RegistrationDate = c.DateTime(nullable: false),
                        Biography = c.String(),
                        CellphoneNumber = c.String(maxLength: 50),
                        TelephoneNumber = c.String(maxLength: 50),
                        ProfilePicturePath = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BursifyUserId = c.Int(nullable: false),
                        AddressType = c.String(nullable: false, maxLength: 50),
                        PreferredAddress = c.Boolean(nullable: false),
                        HouseNumber = c.String(maxLength: 50),
                        StreetName = c.String(maxLength: 200),
                        Suburb = c.String(maxLength: 200),
                        City = c.String(maxLength: 200),
                        PostOfficeBoxNumber = c.Long(),
                        PostOfficeName = c.String(maxLength: 200),
                        PostalCode = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .Index(t => t.BursifyUserId);
            
            CreateTable(
                "dbo.Sponsor",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Type = c.String(nullable: false),
                        Website = c.String(),
                        Location = c.String(nullable: false),
                        NumberOfStudentsSponsored = c.Int(),
                        NumberOfSponsorships = c.Int(),
                        NumberOfApplicants = c.Int(),
                        BursifyRank = c.Int(),
                        BursifyScore = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.CampaignSponsor",
                c => new
                    {
                        CampaignId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                        AmountContributed = c.Double(nullable: false),
                        DateOfContribution = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.CampaignId, t.SponsorId })
                .ForeignKey("dbo.Campaign", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.Sponsorship",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SponsorId = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        SponsorshipType = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        ClosingDate = c.DateTime(nullable: false),
                        EssayRequired = c.Boolean(nullable: false),
                        SponsorshipValue = c.Double(nullable: false),
                        StudyFields = c.String(nullable: false),
                        Province = c.String(nullable: false, maxLength: 100),
                        AverageMarkRequired = c.Int(),
                        EducationLevel = c.String(maxLength: 200),
                        PreferredInstitutions = c.String(maxLength: 500),
                        ExpensesCovered = c.String(nullable: false, maxLength: 500),
                        TermsAndConditions = c.String(nullable: false),
                        NumberOfViews = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.SponsorshipRequirement",
                c => new
                    {
                        SponsorshipId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        RequiredMark = c.Int(),
                    })
                .PrimaryKey(t => new { t.SponsorshipId, t.SubjectId })
                .ForeignKey("dbo.Sponsorship", t => t.SponsorshipId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SponsorshipId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        SubjectLevel = c.String(nullable: false),
                        Period = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.StudentSubject",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        MarkAcquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SubjectId })
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subject", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Surname = c.String(maxLength: 200),
                        EducationLevel = c.String(maxLength: 50),
                        AverageMark = c.Int(),
                        StudentNumber = c.String(maxLength: 50),
                        Age = c.Int(),
                        HasDisability = c.Boolean(),
                        Race = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        CurrentOccupation = c.String(maxLength: 100),
                        StudyField = c.String(),
                        HighestAcademicAchievement = c.String(maxLength: 50),
                        YearOfAcademicAchievement = c.Long(),
                        DateOfBirth = c.DateTime(),
                        NumberOfViews = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 500),
                        Type = c.String(nullable: false, maxLength: 50),
                        Website = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.StudentSponsorship",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        SponsorshipId = c.Int(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                        SponsorshipOffered = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SponsorshipId })
                .ForeignKey("dbo.Sponsorship", t => t.SponsorshipId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SponsorshipId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "ID", "dbo.Campaign");
            DropForeignKey("dbo.Campaign", "StudentId", "dbo.Student");
            DropForeignKey("dbo.CampaignReport", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.CampaignReport", "BursifyUserId", "dbo.BursifyUser");
            DropForeignKey("dbo.BursifyUserCampaigns", "Campaign_ID", "dbo.Campaign");
            DropForeignKey("dbo.BursifyUserCampaigns", "BursifyUser_ID", "dbo.BursifyUser");
            DropForeignKey("dbo.Student", "ID", "dbo.BursifyUser");
            DropForeignKey("dbo.Sponsor", "ID", "dbo.BursifyUser");
            DropForeignKey("dbo.Sponsorship", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.SponsorshipRequirement", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubject", "SubjectId", "dbo.Subject");
            DropForeignKey("dbo.StudentSubject", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSponsorship", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentSponsorship", "SponsorshipId", "dbo.Sponsorship");
            DropForeignKey("dbo.Institution", "ID", "dbo.Student");
            DropForeignKey("dbo.SponsorshipRequirement", "SponsorshipId", "dbo.Sponsorship");
            DropForeignKey("dbo.CampaignSponsor", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.CampaignSponsor", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.UserAddress", "BursifyUserId", "dbo.BursifyUser");
            DropIndex("dbo.BursifyUserCampaigns", new[] { "Campaign_ID" });
            DropIndex("dbo.BursifyUserCampaigns", new[] { "BursifyUser_ID" });
            DropIndex("dbo.StudentSponsorship", new[] { "SponsorshipId" });
            DropIndex("dbo.StudentSponsorship", new[] { "StudentId" });
            DropIndex("dbo.Institution", new[] { "ID" });
            DropIndex("dbo.Student", new[] { "ID" });
            DropIndex("dbo.StudentSubject", new[] { "SubjectId" });
            DropIndex("dbo.StudentSubject", new[] { "StudentId" });
            DropIndex("dbo.SponsorshipRequirement", new[] { "SubjectId" });
            DropIndex("dbo.SponsorshipRequirement", new[] { "SponsorshipId" });
            DropIndex("dbo.Sponsorship", new[] { "SponsorId" });
            DropIndex("dbo.CampaignSponsor", new[] { "SponsorId" });
            DropIndex("dbo.CampaignSponsor", new[] { "CampaignId" });
            DropIndex("dbo.Sponsor", new[] { "ID" });
            DropIndex("dbo.UserAddress", new[] { "BursifyUserId" });
            DropIndex("dbo.CampaignReport", new[] { "BursifyUserId" });
            DropIndex("dbo.CampaignReport", new[] { "CampaignId" });
            DropIndex("dbo.Campaign", new[] { "StudentId" });
            DropIndex("dbo.Account", new[] { "ID" });
            DropTable("dbo.BursifyUserCampaigns");
            DropTable("dbo.StudentSponsorship");
            DropTable("dbo.Institution");
            DropTable("dbo.Student");
            DropTable("dbo.StudentSubject");
            DropTable("dbo.Subject");
            DropTable("dbo.SponsorshipRequirement");
            DropTable("dbo.Sponsorship");
            DropTable("dbo.CampaignSponsor");
            DropTable("dbo.Sponsor");
            DropTable("dbo.UserAddress");
            DropTable("dbo.BursifyUser");
            DropTable("dbo.CampaignReport");
            DropTable("dbo.Campaign");
            DropTable("dbo.Account");
        }
    }
}
