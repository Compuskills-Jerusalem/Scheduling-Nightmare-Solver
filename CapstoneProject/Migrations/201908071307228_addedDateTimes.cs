namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedDateTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "AvailableDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "StartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clients", "EndTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "EndTime");
            DropColumn("dbo.Clients", "StartTime");
            DropColumn("dbo.Clients", "AvailableDate");
        }
    }
}
