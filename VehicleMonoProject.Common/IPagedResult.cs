using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common
{
    public interface IPagedResult<T>
    {
         IList<T> vehicleList { get; set; }
         string sort { get; set; }
         string search { get; set; }
         string direction { get; set; }
         int page { get; set; }
         int pageCount { get; set; }
    }
}
