namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbstructurechanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailabilityDetails", "BusDetailsId", c => c.Int());
            CreateIndex("dbo.AvailabilityDetails", "BusDetailsId");
            AddForeignKey("dbo.AvailabilityDetails", "BusDetailsId", "dbo.BusDetails", "Id");
            DropColumn("dbo.AvailabilityDetails", "BusNumber");
            DropColumn("dbo.BusDetails", "OriginLocation");
            DropColumn("dbo.BusDetails", "DestinationLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusDetails", "DestinationLocation", c => c.String());
            AddColumn("dbo.BusDetails", "OriginLocation", c => c.String());
            AddColumn("dbo.AvailabilityDetails", "BusNumber", c => c.String());
            DropForeignKey("dbo.AvailabilityDetails", "BusDetailsId", "dbo.BusDetails");
            DropIndex("dbo.AvailabilityDetails", new[] { "BusDetailsId" });
            DropColumn("dbo.AvailabilityDetails", "BusDetailsId");
        }
    }
}
