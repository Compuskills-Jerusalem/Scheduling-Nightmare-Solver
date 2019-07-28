namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "AvailableUntil", c => c.DateTime(nullable: false));
            DropColumn("dbo.Clients", "AvailableTill");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "AvailableTill", c => c.DateTime(nullable: false));
            DropColumn("dbo.Clients", "AvailableUntil");
        }
    }
}
