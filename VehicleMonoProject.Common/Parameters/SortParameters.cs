using System.Collections.Generic;
using System.Linq;
using VehicleMonoProject.Common.ParametersCommon;

namespace VehicleMonoProject.Common.Parameters
{
    public class SortParameters: ISortParameters
    {
        public string Sort { get; set; }
        public string Direction { get; set; }
    }
}
