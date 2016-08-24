namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequirementTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requirement", "SponsorshipId", "dbo.Sponsorship");
            DropIndex("dbo.Requirement", new[] { "SponsorshipId" });
            DropTable("dbo.Requirement");
        }
    }
}
