namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentReportUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentReport", "ReportInstitution", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StudentReport", "ReportInstitution");
        }
    }
}
