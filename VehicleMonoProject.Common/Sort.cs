using System.Collections.Generic;
using System.Linq;

namespace VehicleMonoProject.Common
{
    public class Sort<T>
    {
        public static IList<T> VehicleSort(IList<T> vehicleList, string sort, string direction)
        {
            var propertyInfo = vehicleList.FirstOrDefault().GetType().GetProperty(sort);
            if (direction == "Descending")
            {
                return vehicleList.OrderByDescending(i => propertyInfo.GetValue(i)).ToList();
            }
            else
            {
                return vehicleList.OrderBy(i => propertyInfo.GetValue(i)).ToList();
            }
        }
    }
}
