using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Model
{
    public class VehicleMake: IVehicleMake
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public string Image { get; set; }
    }
}
