namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNoteToGroupName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupNames", "Note", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GroupNames", "Note");
        }
    }
}
