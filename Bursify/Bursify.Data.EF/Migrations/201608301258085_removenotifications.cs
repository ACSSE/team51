namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removenotifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SponsorStudentNotification", "SponsorId", "dbo.Sponsor");
            DropForeignKey("dbo.SponsorStudentNotification", "StudentId", "dbo.Student");
            DropIndex("dbo.SponsorStudentNotification", new[] { "SponsorId" });
            DropIndex("dbo.SponsorStudentNotification", new[] { "StudentId" });
            DropTable("dbo.SponsorStudentNotification");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SponsorStudentNotification", "StudentId");
            CreateIndex("dbo.SponsorStudentNotification", "SponsorId");
            AddForeignKey("dbo.SponsorStudentNotification", "StudentId", "dbo.Student", "ID", cascadeDelete: true);
            AddForeignKey("dbo.SponsorStudentNotification", "SponsorId", "dbo.Sponsor", "ID", cascadeDelete: true);
        }
    }
}
