namespace VehicleMonoProject.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VehicleMakes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleModels", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleModels", "Name", c => c.String());
            AlterColumn("dbo.VehicleMakes", "Name", c => c.String());
        }
    }
}
