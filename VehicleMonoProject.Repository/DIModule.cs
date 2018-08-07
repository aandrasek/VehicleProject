using Ninject.Extensions.Factory;
using Ninject.Modules;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.Repository.UOW;

namespace VehicleMonoProject.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IGenericRepository<VehicleMakeEntity>)).To(typeof(GenericRepository<VehicleMakeEntity>));
            Bind(typeof(IGenericRepository<VehicleModelEntity>)).To(typeof(GenericRepository<VehicleModelEntity>));
            Bind(typeof(IVehicleMakeRepository)).To(typeof(VehicleMakeRepository));
            Bind(typeof(IVehicleModelRepository)).To(typeof(VehicleModelRepository));
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}
