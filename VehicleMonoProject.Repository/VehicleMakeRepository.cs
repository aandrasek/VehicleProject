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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        protected IGenericRepository<VehicleMakeEntity> Repository { get; private set; }

        public VehicleMakeRepository(IGenericRepository<VehicleMakeEntity> repository)
        {
            Repository = repository;
        }

        public async Task AddVehicleMakeAsync(IVehicleMake entity)
        {

            await Repository.AddAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));

        }

        public async Task DeleteVehicleMakeAsync(IVehicleMake entity)
        {

            await Repository.DeleteAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));

        }

        public async Task EditVehicleMakeAsync(IVehicleMake entity)
        {

            await Repository.EditAsync(AutoMapper.Mapper.Map<VehicleMakeEntity>(entity));

        }

        public async Task<IPagedList<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            IEnumerable<VehicleMakeEntity> vehicleMakeList;

            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                if (sortParameters.Direction == "Descending")
                {
                    vehicleMakeList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderByDescending(c => c.Name).ToListAsync();
                }
                else
                {
                    vehicleMakeList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(c => c.Name).ToListAsync();
                }
                return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList).ToPagedList(pageParameters.Page, pageParameters.PageSize);
            }

            switch (sortParameters.Sort)
            {
                case "Name":
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Name == null).ThenBy(c => c.Name);
                    break;
                case "Abrv":
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Abrv == null).ThenBy(c => c.Abrv);
                    break;
                default:
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Id);
                    break;
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList).ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters)
        {
            IEnumerable<VehicleMakeEntity> vehicleMakeList;

            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                if (sortParameters.Direction == "Descending")
                {
                    vehicleMakeList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderByDescending(c => c.Name).ToListAsync();
                }
                else
                {
                    vehicleMakeList = await Repository.GetVehiclesAsync()
                    .Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper())).OrderBy(c => c.Name).ToListAsync();
                }
                return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList);
            }

            switch (sortParameters.Sort)
            {
                case "Name":
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Name == null).ThenBy(c => c.Name);
                    break;
                case "Abrv":
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Abrv == null).ThenBy(c => c.Abrv);
                    break;
                default:
                    vehicleMakeList = Repository.GetVehiclesAsync().OrderBy(c => c.Id);
                    break;
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(vehicleMakeList);
        }


        public async Task<IPagedList<IVehicleMake>> GetCategoryListAsync(IPageParameters pageParameters, IFilterParameters filterParameters)
        {
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                var vehicleMakeList = AutoMapper.Mapper.Map<List<IVehicleMake>>(await Repository.GetVehiclesAsync().Where(c => c.Name.ToUpper().StartsWith(filterParameters.Search.ToUpper())).ToListAsync());
                return vehicleMakeList.ToPagedList(pageParameters.Page, pageParameters.PageSize);
            }
            else
            {
                var vehicleMakeList = AutoMapper.Mapper.Map<List<IVehicleMake>>(await Repository.GetVehiclesAsync().ToListAsync());
                return vehicleMakeList.ToPagedList(pageParameters.Page, pageParameters.PageSize);
            }
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }
    }
}
