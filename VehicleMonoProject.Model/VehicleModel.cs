using System;
using System.ComponentModel.DataAnnotations;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Model
{
    public class VehicleModel:IVehicleModel
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
    }
}
