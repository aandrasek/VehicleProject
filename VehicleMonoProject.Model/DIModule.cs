using Ninject.Modules;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Model
{
    public class DIModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleMake>().To<VehicleMake>();
            Bind<IVehicleModel>().To<VehicleModel>();
        }

    }
}
