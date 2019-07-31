namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKey : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Clients", "GroupNameId");
            AddForeignKey("dbo.Clients", "GroupNameId", "dbo.GroupNames", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "GroupNameId", "dbo.GroupNames");
            DropIndex("dbo.Clients", new[] { "GroupNameId" });
        }
    }
}
