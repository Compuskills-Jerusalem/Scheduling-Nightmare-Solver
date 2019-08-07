namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedmoreFiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvailableSlots", "ClientID", "dbo.Clients");
            DropIndex("dbo.AvailableSlots", new[] { "ClientID" });
            //DropTable("dbo.AvailableSlots");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AvailableSlots", "ClientID");
            AddForeignKey("dbo.AvailableSlots", "ClientID", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
