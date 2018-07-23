using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }

        string Name { get; set; }

        string Abrv { get; set; }

        string Image { get; set; }

    }
}
