using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common
{
    public interface ISortParameters
    {
        string sort { get; set; }
        string direction { get; set; }
    }
}
