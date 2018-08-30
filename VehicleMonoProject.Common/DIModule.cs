using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.Common.ParametersCommon;

namespace VehicleMonoProject.Common
{
    public class DIModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IFilterParameters>().To<FilterParameters>();
            Bind<IPageParameters>().To<PageParameters>();
            Bind<ISortParameters>().To<SortParameters>();
        }
    }
}
