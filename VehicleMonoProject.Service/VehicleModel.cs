namespace VehicleMonoProject.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using VehicleMonoProject.Service.Common;

    public partial class VehicleModel: IVehicleModel
    {
        public int ID { get; set; }

        public int MakeID { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int? VehicleMake_Id { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}
