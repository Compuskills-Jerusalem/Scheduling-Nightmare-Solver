namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedGroupNameToIEnumerable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "GroupNameId", "dbo.GroupNames");
            DropIndex("dbo.Clients", new[] { "GroupNameId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Clients", "GroupNameId");
            AddForeignKey("dbo.Clients", "GroupNameId", "dbo.GroupNames", "GroupNamesId", cascadeDelete: true);
        }
    }
}
