using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.Service.Common.EntityCommon;

namespace VehicleMonoProject.Service.Common.ServiceCommon
{
    public interface IVehicleMakeService
    {
        void CreateVehicleMake(IVehicleMake make);
        IPagedList<IVehicleMake> GetVehicleMakePaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pagingParameters);
        void UpdateVehicleMake(IVehicleMake make);
        void DeleteVehicleMake(IVehicleMake make);
        IVehicleMake FindVehicleMakeWithId(int? id);
    }
}
