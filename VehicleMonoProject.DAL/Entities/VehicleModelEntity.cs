namespace VehicleMonoProject.DAL
{
    using System;
    using System.Collections.Generic;

    public partial class VehicleModelEntity
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public string Image { get; set; }

        public int? VehicleMake_Id { get; set; }

        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
