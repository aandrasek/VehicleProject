using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;

namespace VehicleMonoProject.Common.Parameters
{
    public class PageParameters: IPageParameters
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
