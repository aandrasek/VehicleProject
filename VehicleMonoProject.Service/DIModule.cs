
using Ninject.Modules;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.Service.Services;

namespace VehicleMonoProject.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {          
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
            Bind<IVehicleModelService>().To<VehicleModelService>();
        }

    }
}
