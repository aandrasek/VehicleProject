using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;
using VehicleMonoProject.Common.Parameters;
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
        public IPagedResult<IVehicleMake> ReadVehicleMake(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleMakeList = context.VehicleMakes.AsEnumerable();
            if (!string.IsNullOrEmpty(sortParameters.sort))
            {
                switch (sortParameters.sort)
                {
                    case "Name":
                        vehicleMakeList = vehicleMakeList.OrderBy(c => c.Name);
                        break;
                    case "Abrv":
                        vehicleMakeList = vehicleMakeList.OrderBy(c => c.Abrv);
                        break;
                    default:
                        vehicleMakeList = vehicleMakeList.OrderBy(c => c.Id);
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filterParameters.search))
            {
                switch (sortParameters.sort)
                {
                    case "Name":
                        vehicleMakeList = vehicleMakeList.Where(s => s.Name.ToUpper().Contains(filterParameters.search.ToUpper())).ToList();
                        break;
                    case "Abrv":
                        vehicleMakeList = vehicleMakeList.Where(s => s.Abrv.ToUpper().Contains(filterParameters.search.ToUpper())).ToList();
                        break;
                    default:
                        vehicleMakeList = vehicleMakeList.Where(s => s.Id.ToString().Contains(filterParameters.search)).ToList();
                        break;
                }
            }
            if (sortParameters.direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }

            var pageCount = (double)vehicleMakeList.Count() / pageParameters.pageSize;
            vehicleMakeList = vehicleMakeList.Skip((pageParameters.page - 1) * pageParameters.pageSize);
            vehicleMakeList = vehicleMakeList.Take(pageParameters.pageSize);

            return new PagedResult<IVehicleMake>
            {
                vehicleList = AutoMapper.Mapper.Map<IList<IVehicleMake>>(vehicleMakeList),
                page = pageParameters.page,
                pageCount = (int)Math.Ceiling(pageCount),
                sort = sortParameters.sort,
                direction = sortParameters.direction,
                search = filterParameters.search
            };
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
        public IVehicleMake FindVehicleMakeWithId(int id)
        {
            return context.VehicleMakes.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
