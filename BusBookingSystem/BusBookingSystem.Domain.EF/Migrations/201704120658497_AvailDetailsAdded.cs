namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AvailDetailsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AvailabilityDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusDetailsId = c.Int(nullable: false),
                        OriginLocation = c.String(),
                        DestinationLocation = c.String(),
                        Monday = c.Boolean(nullable: false),
                        Tuesday = c.Boolean(nullable: false),
                        Wednesday = c.Boolean(nullable: false),
                        Thursday = c.Boolean(nullable: false),
                        Friday = c.Boolean(nullable: false),
                        Saturday = c.Boolean(nullable: false),
                        Sunday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusDetails", t => t.BusDetailsId, cascadeDelete: true)
                .Index(t => t.BusDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AvailabilityDetails", "BusDetailsId", "dbo.BusDetails");
            DropIndex("dbo.AvailabilityDetails", new[] { "BusDetailsId" });
            DropTable("dbo.AvailabilityDetails");
        }
    }
}
