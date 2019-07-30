namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class puttingAvailableFromBack1 : DbMigration
    {
        public override void Up()
        {
            //DropColumn("dbo.Clients", "AvailableFrom");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "AvailableFrom", c => c.DateTime(nullable: false));
        }
    }
}
