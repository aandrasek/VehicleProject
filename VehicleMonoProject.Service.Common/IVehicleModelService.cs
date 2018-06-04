using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using VehicleMonoProject.Common.ParametersCommon;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        void CreateVehicleModel(IVehicleModel model);
        IPagedList<IVehicleModel> GetVehicleModelPaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        IList<SelectListItem> SelectListItems();
        void UpdateVehicleModel(IVehicleModel model);
        void DeleteVehicleModel(IVehicleModel model);
        IVehicleModel FindVehicleModelWithId(int id);
    }
}