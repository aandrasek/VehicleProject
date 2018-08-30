namespace VehicleMonoProject.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class VehicleModelEntity
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public string Image { get; set; }

        public string Color { get; set; }

        public int Mileage { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }

        public int? VehicleMake_Id { get; set; }

        public virtual VehicleMakeEntity VehicleMake { get; set; }
    }
}
