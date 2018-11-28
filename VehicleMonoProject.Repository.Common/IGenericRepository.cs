using System.Data.Entity;
using System.Threading.Tasks;

namespace VehicleMonoProject.Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetVehicleAsync(int id);
        IDbSet<T> GetVehiclesAsync();
        Task AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task EditAsync(T entity);

    }
}
