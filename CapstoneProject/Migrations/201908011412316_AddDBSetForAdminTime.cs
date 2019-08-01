namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDBSetForAdminTime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdminDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminTimes");
        }
    }
}
