using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Repository.Common
{
    public interface IVehicleModelRepository
    {
        IVehicleModel GetVehicleModel(int id);
        IEnumerable<IVehicleModel> GetAllVehicleModels();
        IEnumerable<IVehicleMake> GetAllVehicleMakes();
        void AddVehicleModel(IVehicleModel entity);
        void DeleteVehicleModel(IVehicleModel entity);
        void EditVehicleModel(IVehicleModel entity);
    }
}
