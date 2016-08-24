namespace Bursify.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivity", "BursifyUserId", "dbo.BursifyUser");
            DropIndex("dbo.UserActivity", new[] { "BursifyUserId" });
            DropTable("dbo.UserActivity");
        }
    }
}
