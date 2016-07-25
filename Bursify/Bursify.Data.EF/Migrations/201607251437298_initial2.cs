namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sponsor", "Type", c => c.String(nullable: false));
            AddColumn("dbo.Sponsor", "OrganisationSize", c => c.String(nullable: false));
            AddColumn("dbo.Sponsor", "Website", c => c.String());
            AddColumn("dbo.Sponsor", "YearFounded", c => c.String(nullable: false));
            AddColumn("dbo.Sponsor", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Sponsor", "NumberOfStudentsSponsored", c => c.Int());
            AlterColumn("dbo.Sponsor", "NumberOfSponsorships", c => c.Int());
            AlterColumn("dbo.Sponsor", "NumberOfApplicants", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sponsor", "NumberOfApplicants", c => c.Int(nullable: false));
            AlterColumn("dbo.Sponsor", "NumberOfSponsorships", c => c.Int(nullable: false));
            AlterColumn("dbo.Sponsor", "NumberOfStudentsSponsored", c => c.Int(nullable: false));
            DropColumn("dbo.Sponsor", "Location");
            DropColumn("dbo.Sponsor", "YearFounded");
            DropColumn("dbo.Sponsor", "Website");
            DropColumn("dbo.Sponsor", "OrganisationSize");
            DropColumn("dbo.Sponsor", "Type");
        }
    }
}
