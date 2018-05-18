using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        void CreateVehicleMake(IVehicleMake make);
        PagedResult<IVehicleMake> ReadVehicleMake(string sort, string search, string direction, int? page,int pageSize);
        void UpdateVehicleMake(IVehicleMake make);
        void DeleteVehicleMake(IVehicleMake make);
        IVehicleMake FindVehicleMakeWithID(int ID);
    }
}
