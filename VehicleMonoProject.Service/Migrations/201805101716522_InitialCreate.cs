namespace VehicleMonoProject.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                {
                    MigrationId = c.String(nullable: false, maxLength: 150),
                    ContextKey = c.String(nullable: false, maxLength: 300),
                    Model = c.Binary(nullable: false),
                    ProductVersion = c.String(nullable: false, maxLength: 32),
                })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });

            CreateTable(
                "dbo.VehicleMakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abrv = c.String(),
                        Make_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleMakes", t => t.Make_Id)
                .Index(t => t.Make_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleModels", "Make_Id", "dbo.VehicleMakes");
            DropIndex("dbo.VehicleModels", new[] { "Make_Id" });
            DropTable("dbo.VehicleModels");
            DropTable("dbo.VehicleMakes");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
