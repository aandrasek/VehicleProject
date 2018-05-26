using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common.Parameters
{
    public class PagedResult<T>:IPagedResult<T>
    {
        public IList<T> vehicleList { get; set; }
        public string sort { get; set; }
        public string search { get; set; }
        public string direction { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }
}
