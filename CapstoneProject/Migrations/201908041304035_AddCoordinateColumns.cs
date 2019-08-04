namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoordinateColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "dLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.Clients", "dLongitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "dLongitude");
            DropColumn("dbo.Clients", "dLatitude");
        }
    }
}
