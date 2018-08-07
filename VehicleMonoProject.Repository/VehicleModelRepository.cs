using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Model.Common;
using VehicleMonoProject.Repository.Common;

namespace VehicleMonoProject.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        IGenericRepository<VehicleModelEntity> Repository;

        public VehicleModelRepository(IGenericRepository<VehicleModelEntity> repository)
        {
            Repository = repository;
        }

        public async Task AddVehicleModelAsync(IVehicleModel entity)
        {
            
            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
           
        }

        public async Task DeleteVehicleModelAsync(IVehicleModel entity)
        {
            
            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
           
        }

        public async Task EditVehicleModelAsync(IVehicleModel entity)
        {
            
            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleModelEntity>(entity));
           
        }

        public async Task<IPagedList<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleModelList = AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(await Repository.GetVehiclesAsync());
            switch (sortParameters.Sort)
            {
                case "MakeId":
                    vehicleModelList = vehicleModelList.OrderBy(c => c.MakeId);
                    break;
                case "Name":
                    vehicleModelList = vehicleModelList.OrderBy(c => c.Name);
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

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {           
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id));
        }
    }
}
