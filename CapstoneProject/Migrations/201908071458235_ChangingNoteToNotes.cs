namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingNoteToNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GroupNames", "Notes", c => c.String());
            DropColumn("dbo.GroupNames", "Note");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GroupNames", "Note", c => c.String());
            DropColumn("dbo.GroupNames", "Notes");
        }
    }
}
