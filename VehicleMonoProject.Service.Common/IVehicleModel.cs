using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleModel
    {
        int ID { get; set; }
        int MakeID { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
    }
}
