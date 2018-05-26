using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common
{
    public interface IPageParameters
    {
        int pageSize { get; set; }
        int page { get; set; }
    }
}
