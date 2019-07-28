namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameGroupNameIdToId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GroupNames");
            DropColumn("dbo.GroupNames", "GroupNamesId");
            AddColumn("dbo.GroupNames", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GroupNames", "Id");
        
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupNames", "GroupNamesId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.GroupNames");
            DropColumn("dbo.GroupNames", "Id");
            AddPrimaryKey("dbo.GroupNames", "GroupNamesId");
        }
    }
}
