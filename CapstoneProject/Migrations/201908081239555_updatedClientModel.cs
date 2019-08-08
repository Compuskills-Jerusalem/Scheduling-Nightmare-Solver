namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedClientModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "AvailableTo");
            DropColumn("dbo.Clients", "AvailableUntil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "AvailableUntil", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "AvailableTo", c => c.DateTime(nullable: false));
        }
    }
}
