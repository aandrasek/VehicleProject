using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Service.Common.ServiceCommon;
using VehicleMonoProject.Service.Common.EntityCommon;
using VehicleMonoProject.Service.DAL;

namespace VehicleMonoProject.Service.Services
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
        public IPagedList<IVehicleModel> GetVehicleModelPaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleModelList = context.VehicleModels.AsEnumerable();
            switch (sortParameters.Sort)
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
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleModelList = vehicleModelList.Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper()));
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }

            return vehicleModelList.ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }
        public IEnumerable<IVehicleMake> GetVehicleMake()
        {
            return context.VehicleMakes.AsEnumerable();
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
        public IVehicleModel FindVehicleModelWithId(int? id)
        {
            return context.VehicleModels.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
