namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
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
            DropColumn("dbo.Sponsorship", "DisabilityPreference");
            DropColumn("dbo.Sponsorship", "RacePreference");
            DropColumn("dbo.Sponsorship", "GenderPreference");
            DropColumn("dbo.Sponsorship", "InstitutionPreference");
            DropColumn("dbo.Sponsorship", "StartingDate");
        }
    }
}
