using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.DAL;
using System.Linq.Expressions;
using VehicleMonoProject.Repository.UOW;

namespace VehicleMonoProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VehicleDB context;
        IUnitOfWorkFactory uowFactory;

        public GenericRepository(VehicleDB context, IUnitOfWorkFactory uowFactory)
        {
            this.context = context;
            this.uowFactory = uowFactory;
        }
        public virtual async Task<T> GetVehicleAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
        public virtual async Task<IEnumerable<T>> GetVehiclesAsync(Expression<Func<T, string>> sortExpression, Expression<Func<T, bool>> filterExpression)
        {
            if (filterExpression.ToString() != "c => False")
            {
                return await context.Set<T>().Where(filterExpression).ToListAsync();
            }
            return await context.Set<T>().OrderBy(sortExpression).ToListAsync();
        }
        public virtual async Task AddAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.AddAsync(entity);
            await unitOfWork.CommitAsync();
        }
        public virtual async Task DeleteAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.DeleteAsync(entity);
            await unitOfWork.CommitAsync();
        }
        public virtual async Task EditAsync(T entity)
        {
            var unitOfWork = uowFactory.CreateUnitOfWork();
            await unitOfWork.UpdateAsync(entity);
            await unitOfWork.CommitAsync();
        }
    }
}
