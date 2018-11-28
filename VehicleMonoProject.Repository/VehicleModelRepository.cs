using PagedList;
using System.Collections.Generic;
using System.Linq;
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
        protected IGenericRepository<VehicleModelEntity> Repository { get; private set; }

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

            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                if (sortParameters.Direction == "Descending")
                {
                    vehicleModelList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderByDescending(c => c.Name).ToListAsync();
                }
                else
                {
                    vehicleModelList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(c => c.Name).ToListAsync();
                }
                return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList).ToPagedList(pageParameters.Page, pageParameters.PageSize);
            }

            switch (sortParameters.Sort)
            {
                case "MakeId":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.MakeId);
                    break;
                case "Name":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Name == null).ThenBy(c => c.Name);
                    break;
                case "Abrv":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Abrv == null).ThenBy(c => c.Abrv);
                    break;
                case "Color":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Color == null).ThenBy(c => c.Color);
                    break;
                case "Mileage":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Mileage);
                    break;
                case "ProductionDate":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.ProductionDate);
                    break;
                default:
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Id);
                    break;
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList).ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters)
        {
            IEnumerable<VehicleModelEntity> vehicleModelList;

            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                if (sortParameters.Direction == "Descending")
                {
                    vehicleModelList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderByDescending(c => c.Name).ToListAsync();
                }
                else
                {
                    vehicleModelList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(c => c.Name).ToListAsync();
                }
                return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList);
            }

            switch (sortParameters.Sort)
            {
                case "MakeId":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.MakeId);
                    break;
                case "Name":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Name == null).ThenBy(c => c.Name);
                    break;
                case "Abrv":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Abrv == null).ThenBy(c => c.Abrv);
                    break;
                case "Color":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Color == null).ThenBy(c => c.Color);
                    break;
                case "Mileage":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Mileage);
                    break;
                case "ProductionDate":
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.ProductionDate);
                    break;
                default:
                    vehicleModelList = Repository.GetVehiclesAsync().OrderBy(c => c.Id);
                    break;
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleModelList = vehicleModelList.Reverse();
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(vehicleModelList);
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {           
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id));
        }
    }
}
