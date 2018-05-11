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
    public class VehicleModelService:IVehicleModelService
    {
        VehicleDB context = new VehicleDB();

        public void CreateVehicleModel(IVehicleModel model)
        {
            var vehicleMake = context.VehicleMakes.First(c=>c.Id==model.MakeId);
            vehicleMake.VehicleModels.Add(AutoMapper.Mapper.Map<VehicleModel>(model));
            context.SaveChanges();
        }
        public PagedResult<IVehicleModel> ReadVehicleModel(string sort, string direction, string search, int? page)
        {
            var vehicleModelList = context.VehicleModels.ToList();
            switch (sort)
            {
                case "MakeId":
                    if (direction == "Descending")
                    {
                        vehicleModelList = vehicleModelList.OrderByDescending(c => c.MakeId).ToList();
                        break;
                    }
                    vehicleModelList = vehicleModelList.OrderBy(c => c.MakeId).ToList();
                    break;
                case "Name":
                    if (direction == "Descending")
                    {
                        vehicleModelList = vehicleModelList.OrderByDescending(c => c.Name).ToList();
                        break;
                    }
                    vehicleModelList = vehicleModelList.OrderBy(c => c.Name).ToList();
                    break;
                case "Abrv":
                    if (direction == "Descending")
                    {
                        vehicleModelList = vehicleModelList.OrderByDescending(c => c.Abrv).ToList();
                        break;
                    }
                    vehicleModelList = vehicleModelList.OrderBy(c => c.Abrv).ToList();
                    break;
                default:
                    if (direction == "Descending")
                    {
                        vehicleModelList = vehicleModelList.OrderByDescending(c => c.Id).ToList();
                        break;
                    }
                    vehicleModelList = vehicleModelList.OrderBy(c => c.Id).ToList();
                    break;
            }
            if (!string.IsNullOrEmpty(search))
            {
                switch (sort)
                {
                    case "Make_Id":
                        vehicleModelList = vehicleModelList.Where(s => s.MakeId.ToString().Contains(search)).ToList();
                        break;
                    case "Name":
                        vehicleModelList = vehicleModelList.Where(s => s.Name.ToUpper().Contains(search.ToUpper())).ToList();
                        break;
                    case "Abrv":
                        vehicleModelList = vehicleModelList.Where(s => s.Abrv.ToUpper().Contains(search.ToUpper())).ToList();
                        break;
                    default:
                        vehicleModelList = vehicleModelList.Where(s => s.Id.ToString().Contains(search)).ToList();
                        break;
                }
            }
            var result = PagedResult<IVehicleModel>.GetPagedResultForQuery(vehicleModelList.AsQueryable(), page ?? 1, 3);
            return AutoMapper.Mapper.Map<PagedResult<IVehicleModel>>(result);
        }
        public IList<IVehicleMake> ReadVehicleMake()
        {
            return AutoMapper.Mapper.Map<IList<IVehicleMake>>(context.VehicleMakes.ToList());
        }
        public void UpdateVehicleModel(IVehicleModel model)
        {
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteVehicleModel(IVehicleModel model)
        {
            context.VehicleModels.Remove(context.VehicleModels.Where(c => c.Id == model.Id).FirstOrDefault());
            context.SaveChanges();
        }
        public IVehicleModel FindVehicleModelWithID(int? Id)
        {
            return context.VehicleModels.Where(c => c.Id == Id).FirstOrDefault();
        }
    }
}
