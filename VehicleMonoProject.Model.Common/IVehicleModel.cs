using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }

        int MakeId { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        string Image { get; set; }

        string Color { get; set; }

        int Mileage { get; set; }

        DateTime ProductionDate { get; set; }
    }
}
