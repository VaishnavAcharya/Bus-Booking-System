namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailDetailsAdded1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AvailabilityDetails", "BusDetailsId", "dbo.BusDetails");
            DropIndex("dbo.AvailabilityDetails", new[] { "BusDetailsId" });
            AddColumn("dbo.AvailabilityDetails", "BusNumber", c => c.String());
            DropColumn("dbo.AvailabilityDetails", "BusDetailsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AvailabilityDetails", "BusDetailsId", c => c.Int(nullable: false));
            DropColumn("dbo.AvailabilityDetails", "BusNumber");
            CreateIndex("dbo.AvailabilityDetails", "BusDetailsId");
            AddForeignKey("dbo.AvailabilityDetails", "BusDetailsId", "dbo.BusDetails", "Id", cascadeDelete: true);
        }
    }
}
