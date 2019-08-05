namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCoordinateColumns : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Clients", "dLatitude");
            //DropColumn("dbo.Clients", "dLongitude");
        }
        
        public override void Down()
        {
            //AddColumn("dbo.Clients", "dLongitude", c => c.Double(nullable: false));
            //AddColumn("dbo.Clients", "dLatitude", c => c.Double(nullable: false));
        }
    }
}
