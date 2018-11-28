using System.Threading.Tasks;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Repository.UOW;
using System.Data.Entity;

namespace VehicleMonoProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VehicleDB context;
        protected IUnitOfWorkFactory UowFactory { get; private set; }

        public GenericRepository(VehicleDB context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            UowFactory = uowFactory;
        }
        public virtual async Task<T> GetVehicleAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public virtual IDbSet<T> GetVehiclesAsync()
        {
            return context.Set<T>();
        }
        public virtual async Task AddAsync(T entity)
        {
            var unitOfWork = UowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            var unitOfWork = UowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }
        public virtual async Task EditAsync(T entity)
        {
            var unitOfWork = UowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
