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
        public PagedResult<IVehicleMake> ReadVehicleMake(string sort, string search, string direction, int? page)
        {
            var vehicleMakeList = context.VehicleMakes.ToList();
            switch (sort)
            {
                case "Name":
                    if (direction == "Descending")
                    {
                        vehicleMakeList = vehicleMakeList.OrderByDescending(c => c.Name).ToList();
                        break;
                    }
                    vehicleMakeList = vehicleMakeList.OrderBy(c => c.Name).ToList();
                    break;
                case "Abrv":
                    if (direction == "Descending")
                    {
                        vehicleMakeList = vehicleMakeList.OrderByDescending(c => c.Abrv).ToList();
                        break;
                    }
                    vehicleMakeList = vehicleMakeList.OrderBy(c => c.Abrv).ToList();
                    break;
                default:
                    if (direction == "Descending")
                    {
                        vehicleMakeList = vehicleMakeList.OrderByDescending(c => c.Id).ToList();
                        break;
                    }
                    vehicleMakeList = vehicleMakeList.OrderBy(c => c.Id).ToList();
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                switch (sort)
                {
                    case "Name":
                        vehicleMakeList = vehicleMakeList.Where(s => s.Name.ToUpper().Contains(search.ToUpper())).ToList();
                        break;
                    case "Abrv":
                        vehicleMakeList = vehicleMakeList.Where(s => s.Abrv.ToUpper().Contains(search.ToUpper())).ToList();
                        break;
                    default:
                        vehicleMakeList = vehicleMakeList.Where(s => s.Id.ToString().Contains(search)).ToList();
                        break;
                }
            }
            var result = PagedResult<IVehicleMake>.GetPagedResultForQuery(vehicleMakeList.AsQueryable(), page ?? 1, 3);
            return AutoMapper.Mapper.Map<PagedResult<IVehicleMake>>(result);
        }
        public void UpdateVehicleMake(IVehicleMake make)
        {
            context.Entry(make).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteVehicleMake(IVehicleMake make)
        {
            context.VehicleMakes.Remove(context.VehicleMakes.Where(c => c.Id == make.Id).FirstOrDefault());
            context.SaveChanges();
        }
        public IVehicleMake FindVehicleMakeWithID(int? Id)
        {
            return context.VehicleMakes.Where(c => c.Id == Id).FirstOrDefault();
        }
    }
}
