namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PuttingBackAvailableFrom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "AvailableFrom", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "AvailableFrom");
        }
    }
}
