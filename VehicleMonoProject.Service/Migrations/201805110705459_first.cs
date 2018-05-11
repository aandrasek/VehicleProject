namespace VehicleMonoProject.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.VehicleModels", name: "Make_Id", newName: "VehicleMake_Id");
            RenameIndex(table: "dbo.VehicleModels", name: "IX_Make_Id", newName: "IX_VehicleMake_Id");
            AddColumn("dbo.VehicleModels", "MakeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VehicleModels", "MakeId");
            RenameIndex(table: "dbo.VehicleModels", name: "IX_VehicleMake_Id", newName: "IX_Make_Id");
            RenameColumn(table: "dbo.VehicleModels", name: "VehicleMake_Id", newName: "Make_Id");
        }
    }
}
