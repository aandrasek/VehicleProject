using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
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
            IEnumerable<VehicleModelEntity> vehicleModelList;
            switch (sortParameters.Sort)
            {
                case "MakeId":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.MakeId).ToListAsync();
                    break;
                case "Name":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.Name == null).ThenBy(c => c.Name).ToListAsync();
                    break;
                case "Abrv":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.Abrv == null).ThenBy(c => c.Abrv).ToListAsync();
                    break;
                case "Color":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.Color == null).ThenBy(c => c.Color).ToListAsync();
                    break;
                case "Mileage":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.Mileage).ToListAsync();
                    break;
                case "ProductionDate":
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.ProductionDate).ToListAsync();
                    break;
                default:
                    vehicleModelList = await Repository.GetVehiclesAsync().OrderBy(c => c.Id).ToListAsync();
                    break;
            }
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                vehicleModelList = await Repository.GetVehiclesAsync().Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).ToListAsync();
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList).ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {           
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id));
        }
    }
}
