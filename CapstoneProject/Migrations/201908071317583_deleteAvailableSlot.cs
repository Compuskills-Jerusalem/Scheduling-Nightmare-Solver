namespace CapstoneProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteAvailableSlot : DbMigration
    {
        public override void Up()
        {
            Sql("Drop Table AvailableSlots");
        }
        
        public override void Down()
        {
            
        }
    }
}
