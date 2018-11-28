using PagedList;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task AddVehicleMakeAsync(IVehicleMake entity);
        Task DeleteVehicleMakeAsync(IVehicleMake entity);
        Task EditVehicleMakeAsync(IVehicleMake entity);
        Task<IPagedList<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters);
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters);
        Task<IPagedList<IVehicleMake>> GetCategoryListAsync(IPageParameters pageParameters, IFilterParameters filterParameters);
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
    }
}
