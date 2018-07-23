namespace VehicleMonoProject.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VehicleDB : DbContext
    {
        public VehicleDB()
            : base("name=VehicleDB1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        public virtual DbSet<VehicleModelEntity> VehicleModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMakeEntity>()
                .HasMany(e => e.VehicleModels)
                .WithOptional(e => e.VehicleMake)
                .HasForeignKey(e => e.VehicleMake_Id);
        }
    }
}
