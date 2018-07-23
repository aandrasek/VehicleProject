using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        void CreateVehicleMake(IVehicleMake make, HttpPostedFileBase image);
        IPagedList<IVehicleMake> GetVehicleMakePaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pagingParameters);
        void UpdateVehicleMake(IVehicleMake make);
        void DeleteVehicleMake(IVehicleMake make);
        IVehicleMake FindVehicleMakeWithId(int? id);
    }
}
