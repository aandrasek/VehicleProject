using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.Service.DAL;

namespace VehicleMonoProject.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        VehicleDB context = new VehicleDB();

        public void CreateVehicleMake(IVehicleMake make)
        {
            context.VehicleMakes.Add(AutoMapper.Mapper.Map<VehicleMake>(make));
            context.SaveChanges();
        }
        public IPagedList<IVehicleMake> GetVehicleMakePaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleMakeList = context.VehicleMakes.AsEnumerable();
            switch (sortParameters.Sort)
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

            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                var propertyInfo = vehicleMakeList.FirstOrDefault().GetType().GetProperty(sortParameters.Sort);
                vehicleMakeList = vehicleMakeList.Where(i => propertyInfo.GetValue(i).ToString().ToUpper().Contains(filterParameters.Search.ToUpper()));
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }
            return vehicleMakeList.ToList().ToPagedList(pageParameters.Page, pageParameters.PageSize);
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
