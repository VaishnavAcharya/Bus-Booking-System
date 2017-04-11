namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusCompanyNames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusCompanyNameId = c.Int(nullable: false),
                        BusTypeId = c.Int(nullable: false),
                        OriginLocation = c.String(),
                        DestinationLocation = c.String(),
                        NumOfChairSeats = c.Int(nullable: false),
                        NumOfSleeperSeats = c.Int(nullable: false),
                        BusNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusCompanyNames", t => t.BusCompanyNameId, cascadeDelete: true)
                .ForeignKey("dbo.BusTypes", t => t.BusTypeId, cascadeDelete: true)
                .Index(t => t.BusCompanyNameId)
                .Index(t => t.BusTypeId);
            
            CreateTable(
                "dbo.BusTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusDetails", "BusTypeId", "dbo.BusTypes");
            DropForeignKey("dbo.BusDetails", "BusCompanyNameId", "dbo.BusCompanyNames");
            DropIndex("dbo.BusDetails", new[] { "BusTypeId" });
            DropIndex("dbo.BusDetails", new[] { "BusCompanyNameId" });
            DropTable("dbo.Locations");
            DropTable("dbo.BusTypes");
            DropTable("dbo.BusDetails");
            DropTable("dbo.BusCompanyNames");
        }
    }
}
