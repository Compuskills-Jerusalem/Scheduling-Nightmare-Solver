namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemydb : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Address", c => c.String());
            DropColumn("dbo.Clients", "Country");
            DropColumn("dbo.Clients", "PostalCode");
            DropColumn("dbo.Clients", "Town");
            DropColumn("dbo.Clients", "StreetName");
            DropColumn("dbo.Clients", "HouseNumber");
        }
    }
}
