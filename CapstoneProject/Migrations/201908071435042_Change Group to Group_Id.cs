namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGrouptoGroup_Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Group1_Id", "dbo.Clients");
            DropForeignKey("dbo.Matches", "Group2_Id", "dbo.Clients");
            DropIndex("dbo.Matches", new[] { "Group1_Id" });
            DropIndex("dbo.Matches", new[] { "Group2_Id" });
            AddColumn("dbo.Clients", "AvailableTo", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Matches", "Group1_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "Group2_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Clients", "AvailableUntil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "AvailableUntil", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Matches", "Group2_Id", c => c.Int());
            AlterColumn("dbo.Matches", "Group1_Id", c => c.Int());
            DropColumn("dbo.Clients", "AvailableTo");
            CreateIndex("dbo.Matches", "Group2_Id");
            CreateIndex("dbo.Matches", "Group1_Id");
            AddForeignKey("dbo.Matches", "Group2_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Matches", "Group1_Id", "dbo.Clients", "Id");
        }
    }
}
