namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMigrations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false));
        }
    }
}
