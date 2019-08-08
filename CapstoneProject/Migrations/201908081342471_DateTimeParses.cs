namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeParses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "AvailableFrom", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "AvailableTo", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "AvailableTo");
            DropColumn("dbo.Clients", "AvailableFrom");
        }
    }
}
