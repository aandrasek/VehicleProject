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
        IPagedResult<IVehicleModel> ReadVehicleModel(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        IList<IVehicleMake> ReadVehicleMake();
        void UpdateVehicleModel(IVehicleModel model);
        void DeleteVehicleModel(IVehicleModel model);
        IVehicleModel FindVehicleModelWithId(int id);
    }
}