namespace VehicleMonoProject.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.VehicleMakes", newName: "VehicleMakeEntities");
            RenameTable(name: "dbo.VehicleModels", newName: "VehicleModelEntities");
            AddColumn("dbo.VehicleMakeEntities", "Image", c => c.String());
            AddColumn("dbo.VehicleModelEntities", "Image", c => c.String());
            AlterColumn("dbo.VehicleMakeEntities", "Name", c => c.String());
            AlterColumn("dbo.VehicleModelEntities", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VehicleModelEntities", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.VehicleMakeEntities", "Name", c => c.String(nullable: false));
            DropColumn("dbo.VehicleModelEntities", "Image");
            DropColumn("dbo.VehicleMakeEntities", "Image");
            RenameTable(name: "dbo.VehicleModelEntities", newName: "VehicleModels");
            RenameTable(name: "dbo.VehicleMakeEntities", newName: "VehicleMakes");
        }
    }
}
