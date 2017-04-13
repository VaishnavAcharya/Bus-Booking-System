namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusNumDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusDetails", "BusNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BusDetails", "BusNumber", c => c.Int(nullable: false));
        }
    }
}
