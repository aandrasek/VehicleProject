using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.DAL;

namespace VehicleMonoProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VehicleDB context;

        public GenericRepository(VehicleDB context)
        {
            this.context = context;
        }
        public T Get(int id)
        {
            return context.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return context.Set<T>().AsEnumerable();
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Delete(T entity)
        {
            var vehicleObject = context.Set<T>().Find(GetProperty(entity, "Id"));
            context.Set<T>().Remove(vehicleObject);
        }
        public void Edit(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        object GetProperty<E>(E entity, string propertyName) where E : class
        {
            var property = entity.GetType().GetProperty(propertyName);
            if (property == null)
            {
                throw new Exception("Entity does not contain property with name '" + propertyName + "'");
            }
            return property.GetValue(entity);
        }
    }
}
