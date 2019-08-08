namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDataBase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvailableSlots", "ClientID", "dbo.Clients");
            DropIndex("dbo.AvailableSlots", new[] { "ClientID" });
            AddColumn("dbo.Clients", "AvailableUntil", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "AvailableDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "EndTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.GroupNames", "Notes", c => c.String());
            DropColumn("dbo.Clients", "AvailableFrom");
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
            
            AddColumn("dbo.Clients", "AvailableFrom", c => c.DateTime(nullable: false));
            DropColumn("dbo.GroupNames", "Notes");
            DropColumn("dbo.Clients", "EndTime");
            DropColumn("dbo.Clients", "StartTime");
            DropColumn("dbo.Clients", "AvailableDate");
            DropColumn("dbo.Clients", "AvailableUntil");
            CreateIndex("dbo.AvailableSlots", "ClientID");
            AddForeignKey("dbo.AvailableSlots", "ClientID", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
