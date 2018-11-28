using PagedList;
using System.Threading.Tasks;
using System.Web;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleMakeService
    {
        Task CreateVehicleMakeAsync(IVehicleMake make, HttpPostedFileBase image);
        Task<IPagedList<IVehicleMake>> GetVehicleMakePagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pagingParameters);
        Task UpdateVehicleMakeAsync(IVehicleMake make, HttpPostedFileBase image);
        Task DeleteVehicleMakeAsync(IVehicleMake make);
        Task<IVehicleMake> FindVehicleMakeWithIdAsync(int? id);
    }
}
