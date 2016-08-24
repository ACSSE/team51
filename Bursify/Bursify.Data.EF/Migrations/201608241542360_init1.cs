namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subject", "RequirementId", "dbo.Sponsorship");
            RenameColumn(table: "dbo.Subject", name: "RequirementId", newName: "StudentReportId");
            RenameIndex(table: "dbo.Subject", name: "IX_RequirementId", newName: "IX_StudentReportId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Subject", name: "IX_StudentReportId", newName: "IX_RequirementId");
            RenameColumn(table: "dbo.Subject", name: "StudentReportId", newName: "RequirementId");
            AddForeignKey("dbo.Subject", "RequirementId", "dbo.Sponsorship", "ID", cascadeDelete: true);
        }
    }
}
