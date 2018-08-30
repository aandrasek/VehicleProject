using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task<IPagedList<IVehicleMake>> GetCategoryListAsync(IPageParameters pageParameters, IFilterParameters filterParameters);
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
    }
}
