namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMatchModelandTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Group1_Id = c.Int(),
                        Group2_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.Group1_Id)
                .ForeignKey("dbo.Clients", t => t.Group2_Id)
                .Index(t => t.Group1_Id)
                .Index(t => t.Group2_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "Group2_Id", "dbo.Clients");
            DropForeignKey("dbo.Matches", "Group1_Id", "dbo.Clients");
            DropIndex("dbo.Matches", new[] { "Group2_Id" });
            DropIndex("dbo.Matches", new[] { "Group1_Id" });
            DropTable("dbo.Matches");
        }
    }
}
