
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
