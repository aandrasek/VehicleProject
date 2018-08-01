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
        Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters);
        Task<IEnumerable<IVehicleMake>> GetSelectListItemAsync();
        Task<IVehicleMake> GetVehicleMakeAsync(int id);
    }
}
