using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VehicleMonoProject.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetVehicleAsync(int id);
        Task<IEnumerable<T>> GetVehiclesAsync(Expression<Func<T, string>> sortExpression, Expression<Func<T, bool>> filterExpression);
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);

    }
}
