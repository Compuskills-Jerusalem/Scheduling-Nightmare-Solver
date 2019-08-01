namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdminTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Solutions",
                c => new
                    {
                        SolutionId = c.Int(nullable: false, identity: true),
                        AdminTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SolutionId);
            
            AddColumn("dbo.GroupNames", "AdminTime_SolutionId", c => c.Int(nullable: false));
            CreateIndex("dbo.GroupNames", "AdminTime_SolutionId");
            AddForeignKey("dbo.GroupNames", "AdminTime_SolutionId", "dbo.Solutions", "SolutionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GroupNames", "AdminTime_SolutionId", "dbo.Solutions");
            DropIndex("dbo.GroupNames", new[] { "AdminTime_SolutionId" });
            DropColumn("dbo.GroupNames", "AdminTime_SolutionId");
            DropTable("dbo.Solutions");
        }
    }
}
