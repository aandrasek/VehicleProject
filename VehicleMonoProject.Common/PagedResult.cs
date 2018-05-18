using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Common
{
    public class PagedResult<T>
    {
        public IList<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }

        public static PagedResult<T> GetPagedResultForList(IList<T> vehicleList, int page, int pageSize)
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = vehicleList.Count()
            };
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Results = vehicleList.Skip(skip).Take(pageSize).ToList();
            return result;
        }
    }
}
