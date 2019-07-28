namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedModelAttributes : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "test");
            DropColumn("dbo.Clients", "AvailableFrom");
            DropColumn("dbo.Clients", "AvailableUntil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "AvailableUntil", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "AvailableFrom", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "test", c => c.DateTime(nullable: false));
        }
    }
}
