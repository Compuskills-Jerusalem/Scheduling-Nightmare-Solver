namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitAddressField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "HouseNumber", c => c.String());
            AddColumn("dbo.Clients", "StreetName", c => c.String());
            AddColumn("dbo.Clients", "Town", c => c.String());
            AddColumn("dbo.Clients", "PostalCode", c => c.String());
            AddColumn("dbo.Clients", "Country", c => c.String());
            DropColumn("dbo.Clients", "Address");
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
