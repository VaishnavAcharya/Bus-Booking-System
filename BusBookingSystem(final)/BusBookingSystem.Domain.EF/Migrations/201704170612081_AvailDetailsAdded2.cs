namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailDetailsAdded2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailabilityDetails", "IsReturn", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AvailabilityDetails", "IsReturn");
        }
    }
}
