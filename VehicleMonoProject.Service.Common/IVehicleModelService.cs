using PagedList;
using System.Threading.Tasks;
using System.Web;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleModelService
    {
        Task CreateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image);
        Task<IPagedList<IVehicleModel>> GetVehicleModelPagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task UpdateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image);
        Task DeleteVehicleModelAsync(IVehicleModel model);
        Task<IPagedList<IVehicleMake>> GetCategoryListAsync(IPageParameters pagingParameters, IFilterParameters filterParameters);
        Task<IVehicleModel> FindVehicleModelWithIdAsync(int? id);
    }
}