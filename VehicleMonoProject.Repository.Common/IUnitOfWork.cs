using System;
using System.Threading.Tasks;

namespace VehicleMonoProject.Repository.Common
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> AddAsync<T>(T entity) where T : class;

        Task<int> CommitAsync();

        Task<int> DeleteAsync<T>(T entity) where T : class;

        Task<int> DeleteAsync<T>(int id) where T : class;

        Task<int> UpdateAsync<T>(T entity) where T : class;
    }
}
