using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common.Parameters
{
    public class PageParameters: IPageParameters
    {
        public int pageSize { get; set; }
        public int page { get; set; }
    }
}
