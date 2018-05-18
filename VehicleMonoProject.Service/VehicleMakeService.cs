using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        VehicleDB context = new VehicleDB();

        public void CreateVehicleMake(IVehicleMake make)
        {
            context.VehicleMakes.Add(AutoMapper.Mapper.Map<VehicleMake>(make));
            context.SaveChanges();
        }
        public PagedResult<IVehicleMake> ReadVehicleMake(string sort, string search, string direction, int? page, int pageSize)
        {
            var vehicleMakeList = AutoMapper.Mapper.Map<IList<IVehicleMake>>(context.VehicleMakes.ToList());
            if (!string.IsNullOrEmpty(sort)&& vehicleMakeList.Count!=0)
            {
                vehicleMakeList = Sort<IVehicleMake>.VehicleSort(vehicleMakeList, sort, direction);
            }
            if (!string.IsNullOrEmpty(search))
            {
                vehicleMakeList = Filter<IVehicleMake>.VehicleFilter(vehicleMakeList, sort, search);
            }
            var result = PagedResult<IVehicleMake>.GetPagedResultForList(vehicleMakeList, page ?? 1, pageSize);
            return AutoMapper.Mapper.Map<PagedResult<IVehicleMake>>(result);

        }
        public void UpdateVehicleMake(IVehicleMake make)
        {
            context.Entry(make).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteVehicleMake(IVehicleMake make)
        {
            context.VehicleMakes.Remove(context.VehicleMakes.Where(c => c.ID == make.ID).FirstOrDefault());
            context.SaveChanges();
        }
        public IVehicleMake FindVehicleMakeWithID(int ID)
        {
            return context.VehicleMakes.Where(c => c.ID == ID).FirstOrDefault();
        }
    }
}
