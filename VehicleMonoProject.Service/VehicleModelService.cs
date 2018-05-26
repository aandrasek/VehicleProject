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
    public class VehicleModelService : IVehicleModelService
    {
        VehicleDB context = new VehicleDB();

        public void CreateVehicleModel(IVehicleModel model)
        {
            var vehicleMake = context.VehicleMakes.First(c => c.Id == model.MakeId);
            vehicleMake.VehicleModels.Add(AutoMapper.Mapper.Map<VehicleModel>(model));
            context.SaveChanges();
        }
        public IPagedResult<IVehicleModel> ReadVehicleModel(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleModelList = context.VehicleModels.AsEnumerable();
            if (!string.IsNullOrEmpty(sortParameters.sort))
            {
                switch (sortParameters.sort)
                {
                    case "Name":
                        vehicleModelList = vehicleModelList.OrderBy(c => c.Name);
                        break;
                    case "MakeId":
                        vehicleModelList = vehicleModelList.OrderBy(c => c.MakeId);
                        break;
                    case "Abrv":
                        vehicleModelList = vehicleModelList.OrderBy(c => c.Abrv);
                        break;
                    default:
                        vehicleModelList = vehicleModelList.OrderBy(c => c.Id);
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filterParameters.search))
            {
                switch (sortParameters.sort)
                {
                    case "Name":
                        vehicleModelList = vehicleModelList.Where(s => s.Name.ToUpper().Contains(filterParameters.search.ToUpper())).ToList();
                        break;
                    case "MakeId":
                        vehicleModelList = vehicleModelList.Where(s => s.MakeId.ToString().Contains(filterParameters.search.ToString())).ToList();
                        break;
                    case "Abrv":
                        vehicleModelList = vehicleModelList.Where(s => s.Abrv.ToUpper().Contains(filterParameters.search.ToUpper())).ToList();
                        break;
                    default:
                        vehicleModelList = vehicleModelList.Where(s => s.Id.ToString().Contains(filterParameters.search)).ToList();
                        break;
                }
            }
            if (sortParameters.direction == "Descending")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }

            var pageCount = (double)vehicleModelList.Count() / pageParameters.pageSize;
            vehicleModelList = vehicleModelList.Skip((pageParameters.page - 1) * pageParameters.pageSize);
            vehicleModelList = vehicleModelList.Take(pageParameters.pageSize);

            return new PagedResult<IVehicleModel>
            {
                vehicleList = AutoMapper.Mapper.Map<IList<IVehicleModel>>(vehicleModelList),
                page = pageParameters.page,
                pageCount = (int)Math.Ceiling(pageCount),
                sort = sortParameters.sort,
                direction = sortParameters.direction,
                search = filterParameters.search
            };
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
        public IVehicleModel FindVehicleModelWithId(int id)
        {
            return context.VehicleModels.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
