using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        Task AddVehicleModelAsync(IVehicleModel entity);
        Task DeleteVehicleModelAsync(IVehicleModel entity);
        Task EditVehicleModelAsync(IVehicleModel entity);
        Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters);
        Task<IVehicleModel> GetVehicleModelAsync(int id);
    }
}
