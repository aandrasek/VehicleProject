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
        Task CreateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image);
        Task<IPagedList<IVehicleModel>> GetVehicleModelPagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task UpdateVehicleModelAsync(IVehicleModel model);
        Task DeleteVehicleModelAsync(IVehicleModel model);
        Task<IVehicleModel> FindVehicleModelWithIdAsync(int? id);
    }
}