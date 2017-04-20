namespace BusBookingSystem.Domain.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniquebusnumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BusDetails", "BusNumber", c => c.String(maxLength: 70));
            CreateIndex("dbo.BusDetails", "BusNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.BusDetails", new[] { "BusNumber" });
            AlterColumn("dbo.BusDetails", "BusNumber", c => c.String());
        }
    }
}
