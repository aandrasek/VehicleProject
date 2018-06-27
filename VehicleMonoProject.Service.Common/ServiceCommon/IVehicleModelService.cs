using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Service.Common.EntityCommon;

namespace VehicleMonoProject.Service.Common.ServiceCommon
{
    public interface IVehicleModelService
    {
        void CreateVehicleModel(IVehicleModel model);
        IPagedList<IVehicleModel> GetVehicleModelPaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        IEnumerable<IVehicleMake> GetVehicleMake();
        void UpdateVehicleModel(IVehicleModel model);
        void DeleteVehicleModel(IVehicleModel model);
        IVehicleModel FindVehicleModelWithId(int? id);
    }
}