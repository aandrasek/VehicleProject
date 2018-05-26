using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;
using VehicleMonoProject.Common.Parameters;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        void CreateVehicleMake(IVehicleMake make);
        IPagedResult<IVehicleMake> ReadVehicleMake(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pagingParameters);
        void UpdateVehicleMake(IVehicleMake make);
        void DeleteVehicleMake(IVehicleMake make);
        IVehicleMake FindVehicleMakeWithId(int id);
    }
}
