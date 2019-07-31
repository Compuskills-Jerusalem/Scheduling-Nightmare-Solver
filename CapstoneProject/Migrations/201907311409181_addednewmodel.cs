namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailableSlots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ClientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientID, cascadeDelete: true)
                .Index(t => t.ClientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailableSlots", "ClientID", "dbo.Clients");
            DropIndex("dbo.AvailableSlots", new[] { "ClientID" });
            DropTable("dbo.AvailableSlots");
        }
    }
}
