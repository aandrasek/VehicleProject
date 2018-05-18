using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        void CreateVehicleModel(IVehicleModel model);
        PagedResult<IVehicleModel> ReadVehicleModel(string sort, string direction, string search, int? page,int pageSize);
        IList<IVehicleMake> ReadVehicleMake();
        void UpdateVehicleModel(IVehicleModel model);
        void DeleteVehicleModel(IVehicleModel model);
        IVehicleModel FindVehicleModelWithID(int ID);
    }
}
