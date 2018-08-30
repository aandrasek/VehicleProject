namespace VehicleMonoProject.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleModelEntities", "Mileage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleModelEntities", "Mileage", c => c.Double(nullable: false));
        }
    }
}
