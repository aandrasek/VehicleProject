using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common
{
    public class Filter<T>
    {
        public static IList<T> VehicleFilter(IList<T> vehicleList, string sort, string search)
        {
            var propertyInfo = vehicleList.FirstOrDefault().GetType().GetProperty(sort);
            var filteredList = vehicleList.Where(i => propertyInfo.GetValue(i).ToString().ToUpper()
            .Contains(search.ToUpper())).ToList();
            return filteredList;
        }
    }
}
