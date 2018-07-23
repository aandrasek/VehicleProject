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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public void AddVehicleMake(IVehicleMake entity)
        {
            unitOfWork.VehicleMakes.Add(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
            unitOfWork.Save();
        }

        public void DeleteVehicleMake(IVehicleMake entity)
        {
            unitOfWork.VehicleMakes.Delete(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
            unitOfWork.Save();
        }

        public void EditVehicleMake(IVehicleMake entity)
        {
            //unitOfWork.VehicleMakeRepository.Edit(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));
            var a = unitOfWork.VehicleMakes.Get(entity.Id);
            a = AutoMapper.Mapper.Map<VehicleMakeEntity>(entity);
            unitOfWork.Save();
        }

        public IEnumerable<IVehicleMake> GetAllVehicleMakes()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(unitOfWork.VehicleMakes.GetAll());
        }

        public IVehicleMake GetVehicleMake(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(unitOfWork.VehicleMakes.Get(id));
        }
    }
}
