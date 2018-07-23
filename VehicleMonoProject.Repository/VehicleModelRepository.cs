using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Model.Common;
using VehicleMonoProject.Repository.Common;

namespace VehicleMonoProject.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public void AddVehicleModel(IVehicleModel entity)
        {
            unitOfWork.VehicleModels.Add(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
            unitOfWork.Save();
        }

        public void DeleteVehicleModel(IVehicleModel entity)
        {
            unitOfWork.VehicleModels.Delete(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
            unitOfWork.Save();
        }

        public void EditVehicleModel(IVehicleModel entity)
        {
            unitOfWork.VehicleModels.Edit(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
            unitOfWork.Save();
        }

        public IEnumerable<IVehicleModel> GetAllVehicleModels()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(unitOfWork.VehicleModels.GetAll());
        }

        public IEnumerable<IVehicleMake> GetAllVehicleMakes()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(unitOfWork.VehicleMakes.GetAll());
        }

        public IVehicleModel GetVehicleModel(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleModel>(unitOfWork.VehicleModels.Get(id));
        }
    }
}
