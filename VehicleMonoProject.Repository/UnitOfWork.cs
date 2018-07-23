using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.DAL;

namespace VehicleMonoProject.Repository
{
    public class UnitOfWork : IDisposable
    {
        private VehicleDB context = new VehicleDB();
        private GenericRepository<VehicleMakeEntity> vehicleMakeRepository;
        private GenericRepository<VehicleModelEntity> vehicleModelRepository;

        public GenericRepository<VehicleMakeEntity> VehicleMakes
        {
            get
            {
                if (this.vehicleMakeRepository == null)
                {
                    this.vehicleMakeRepository = new GenericRepository<VehicleMakeEntity>(context);
                }
                return vehicleMakeRepository;
            }
        }

        public GenericRepository<VehicleModelEntity> VehicleModels
        {
            get
            {
                if (this.vehicleModelRepository == null)
                {
                    this.vehicleModelRepository = new GenericRepository<VehicleModelEntity>(context);
                }
                return vehicleModelRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
