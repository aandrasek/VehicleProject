using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        IVehicleMake GetVehicleMake(int id) ;
        IEnumerable<IVehicleMake> GetAllVehicleMakes() ;
        void AddVehicleMake(IVehicleMake entity) ;
        void DeleteVehicleMake(IVehicleMake entity) ;
        void EditVehicleMake(IVehicleMake entity) ;
    }
}
