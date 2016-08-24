namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        AccountName = c.String(maxLength: 200),
                        CardNumber = c.String(),
                        ExpirationYear = c.Long(),
                        ExpirationMonth = c.Int(),
                        CvvNumber = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.BursifyUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        PasswordHash = c.String(),
                        PasswordSalt = c.String(),
                        AccountStatus = c.String(),
                        UserType = c.String(maxLength: 50),
                        RegistrationDate = c.DateTime(),
                        Biography = c.String(),
                        CellphoneNumber = c.String(maxLength: 50),
                        TelephoneNumber = c.String(maxLength: 50),
                        ProfilePicturePath = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserActivity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BursifyUserId = c.Int(nullable: false),
                        Type = c.String(),
                        Description = c.String(),
                        TimeStamp = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .Index(t => t.BursifyUserId);
            
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BursifyUserId = c.Int(nullable: false),
                        AddressType = c.String(maxLength: 50),
                        PreferredAddress = c.String(),
                        HouseNumber = c.String(maxLength: 50),
                        StreetName = c.String(maxLength: 200),
                        Province = c.String(maxLength: 200),
                        City = c.String(maxLength: 200),
                        PostOfficeBoxNumber = c.Long(),
                        PostOfficeName = c.String(maxLength: 200),
                        PostalCode = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .Index(t => t.BursifyUserId);
            
            CreateTable(
                "dbo.CampaignReport",
                c => new
                    {
                        CampaignId = c.Int(nullable: false),
                        BursifyUserId = c.Int(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => new { t.CampaignId, t.BursifyUserId })
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUserId, cascadeDelete: true)
                .ForeignKey("dbo.Campaign", t => t.CampaignId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.BursifyUserId);
            
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        CampaignName = c.String(maxLength: 200),
                        Tagline = c.String(maxLength: 200),
                        Location = c.String(maxLength: 500),
                        Description = c.String(),
                        AmountRequired = c.Double(),
                        CampaignType = c.String(maxLength: 50),
                        VideoPath = c.String(maxLength: 200),
                        PicturePath = c.String(maxLength: 200),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        AmountContributed = c.Double(),
                        FundUsage = c.String(),
                        ReasonsToSupport = c.String(),
                        NumberOfUpVotes = c.Int(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.CampaignSponsor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(nullable: false),
                        SponsorId = c.Int(nullable: false),
                        AmountContributed = c.Double(),
                        DateOfContribution = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Campaign", t => t.CampaignId, cascadeDelete: true)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.CampaignId)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.Sponsor",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CompanyName = c.String(),
                        Industry = c.String(),
                        Website = c.String(),
                        Location = c.String(),
                        CompanyEmail = c.String(),
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
                "dbo.Sponsorship",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SponsorId = c.Int(nullable: false),
                        Name = c.String(maxLength: 500),
                        SponsorshipType = c.String(),
                        Description = c.String(),
                        ClosingDate = c.DateTime(),
                        EssayRequired = c.Boolean(),
                        SponsorshipValue = c.Double(),
                        StudyFields = c.String(),
                        Province = c.String(maxLength: 100),
                        AverageMarkRequired = c.Int(),
                        EducationLevel = c.String(maxLength: 200),
                        PreferredInstitutions = c.String(maxLength: 500),
                        ExpensesCovered = c.String(maxLength: 500),
                        TermsAndConditions = c.String(),
                        NumberOfViews = c.Int(),
                        AgeGroup = c.String(),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .Index(t => t.SponsorId);
            
            CreateTable(
                "dbo.Requirement",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SponsorshipId = c.Int(nullable: false),
                        Name = c.String(),
                        MarkRequired = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sponsorship", t => t.SponsorshipId, cascadeDelete: true)
                .Index(t => t.SponsorshipId);
            
            CreateTable(
                "dbo.StudentSponsorship",
                c => new
                    {
                        StudentId = c.Int(nullable: false),
                        SponsorshipId = c.Int(nullable: false),
                        ApplicationDate = c.DateTime(),
                        Status = c.String(),
                        SponsorshipOffered = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.StudentId, t.SponsorshipId })
                .ForeignKey("dbo.Sponsorship", t => t.SponsorshipId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SponsorshipId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        InstitutionID = c.Int(nullable: false),
                        IDNumber = c.String(),
                        Firstname = c.String(),
                        Surname = c.String(maxLength: 200),
                        EducationLevel = c.String(maxLength: 50),
                        AverageMark = c.Int(),
                        StudentNumber = c.String(maxLength: 50),
                        Age = c.Int(),
                        HasDisability = c.Boolean(),
                        DisabilityDescription = c.String(),
                        Race = c.String(maxLength: 50),
                        Gender = c.String(maxLength: 50),
                        CurrentOccupation = c.String(maxLength: 100),
                        StudyField = c.String(),
                        HighestAcademicAchievement = c.String(maxLength: 50),
                        YearOfAcademicAchievement = c.Long(),
                        DateOfBirth = c.DateTime(),
                        NumberOfViews = c.Int(),
                        Essay = c.String(),
                        GuardianPhone = c.String(),
                        GuardianRelationship = c.String(),
                        GuardianEmail = c.String(),
                        IDDocumentPath = c.String(),
                        MatricCertificatePath = c.String(),
                        CVPath = c.String(),
                        AgreeTandC = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Institution", t => t.InstitutionID, cascadeDelete: true)
                .ForeignKey("dbo.BursifyUser", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.InstitutionID);
            
            CreateTable(
                "dbo.Institution",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 500),
                        Type = c.String(maxLength: 50),
                        Website = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SponsorStudentNotification",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SponsorId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        DateNotified = c.DateTime(),
                        Status = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Sponsor", t => t.SponsorId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.SponsorId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.StudentReport",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Average = c.Int(),
                        ReportLevel = c.String(),
                        ReportPeriod = c.String(),
                        ReportInstitution = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Subject",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        StudentReportId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        MarkAcquired = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StudentReport", t => t.StudentReportId, cascadeDelete: true)
                .Index(t => t.StudentReportId);
            
            CreateTable(
                "dbo.CampaignBursifyUsers",
                c => new
                    {
                        Campaign_ID = c.Int(nullable: false),
                        BursifyUser_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Campaign_ID, t.BursifyUser_ID })
                .ForeignKey("dbo.Campaign", t => t.Campaign_ID, cascadeDelete: true)
                .ForeignKey("dbo.BursifyUser", t => t.BursifyUser_ID, cascadeDelete: true)
                .Index(t => t.Campaign_ID)
                .Index(t => t.BursifyUser_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "ID", "dbo.BursifyUser");
            DropForeignKey("dbo.Student", "ID", "dbo.BursifyUser");
            DropForeignKey("dbo.Sponsor", "ID", "dbo.BursifyUser");
            DropForeignKey("dbo.CampaignReport", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.CampaignBursifyUsers", "BursifyUser_ID", "dbo.BursifyUser");
            DropForeignKey("dbo.CampaignBursifyUsers", "Campaign_ID", "dbo.Campaign");
            DropForeignKey("dbo.Campaign", "StudentId", "dbo.Student");
            DropForeignKey("dbo.CampaignSponsor", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.StudentSponsorship", "StudentId", "dbo.Student");
            DropForeignKey("dbo.StudentReport", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Subject", "StudentReportId", "dbo.StudentReport");
            DropForeignKey("dbo.SponsorStudentNotification", "StudentId", "dbo.Student");
            DropForeignKey("dbo.SponsorStudentNotification", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.Student", "InstitutionID", "dbo.Institution");
            DropForeignKey("dbo.StudentSponsorship", "SponsorshipId", "dbo.Sponsorship");
            DropForeignKey("dbo.Sponsorship", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.Requirement", "SponsorshipId", "dbo.Sponsorship");
            DropForeignKey("dbo.CampaignSponsor", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.CampaignReport", "BursifyUserId", "dbo.BursifyUser");
            DropForeignKey("dbo.UserAddress", "BursifyUserId", "dbo.BursifyUser");
            DropForeignKey("dbo.UserActivity", "BursifyUserId", "dbo.BursifyUser");
            DropIndex("dbo.CampaignBursifyUsers", new[] { "BursifyUser_ID" });
            DropIndex("dbo.CampaignBursifyUsers", new[] { "Campaign_ID" });
            DropIndex("dbo.Subject", new[] { "StudentReportId" });
            DropIndex("dbo.StudentReport", new[] { "StudentId" });
            DropIndex("dbo.SponsorStudentNotification", new[] { "StudentId" });
            DropIndex("dbo.SponsorStudentNotification", new[] { "SponsorId" });
            DropIndex("dbo.Student", new[] { "InstitutionID" });
            DropIndex("dbo.Student", new[] { "ID" });
            DropIndex("dbo.StudentSponsorship", new[] { "SponsorshipId" });
            DropIndex("dbo.StudentSponsorship", new[] { "StudentId" });
            DropIndex("dbo.Requirement", new[] { "SponsorshipId" });
            DropIndex("dbo.Sponsorship", new[] { "SponsorId" });
            DropIndex("dbo.Sponsor", new[] { "ID" });
            DropIndex("dbo.CampaignSponsor", new[] { "SponsorId" });
            DropIndex("dbo.CampaignSponsor", new[] { "CampaignId" });
            DropIndex("dbo.Campaign", new[] { "StudentId" });
            DropIndex("dbo.CampaignReport", new[] { "BursifyUserId" });
            DropIndex("dbo.CampaignReport", new[] { "CampaignId" });
            DropIndex("dbo.UserAddress", new[] { "BursifyUserId" });
            DropIndex("dbo.UserActivity", new[] { "BursifyUserId" });
            DropIndex("dbo.Account", new[] { "ID" });
            DropTable("dbo.CampaignBursifyUsers");
            DropTable("dbo.Subject");
            DropTable("dbo.StudentReport");
            DropTable("dbo.SponsorStudentNotification");
            DropTable("dbo.Institution");
            DropTable("dbo.Student");
            DropTable("dbo.StudentSponsorship");
            DropTable("dbo.Requirement");
            DropTable("dbo.Sponsorship");
            DropTable("dbo.Sponsor");
            DropTable("dbo.CampaignSponsor");
            DropTable("dbo.Campaign");
            DropTable("dbo.CampaignReport");
            DropTable("dbo.UserAddress");
            DropTable("dbo.UserActivity");
            DropTable("dbo.BursifyUser");
            DropTable("dbo.Account");
        }
    }
}
