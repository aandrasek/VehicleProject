using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        void CreateVehicleModel(IVehicleModel model, HttpPostedFileBase image);
        IPagedList<IVehicleModel> GetVehicleModelPaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        IEnumerable<IVehicleMake> GetVehicleMakes();
        void UpdateVehicleModel(IVehicleModel model);
        void DeleteVehicleModel(IVehicleModel model);
        IVehicleModel FindVehicleModelWithId(int? id);
    }
}