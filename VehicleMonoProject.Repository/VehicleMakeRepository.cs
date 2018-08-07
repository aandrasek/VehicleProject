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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        IGenericRepository<VehicleMakeEntity> Repository;

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
            var vehicleMakeList = AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetVehiclesAsync());
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
                vehicleMakeList = vehicleMakeList.Where(c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper()));
            }
            if (sortParameters.Direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }
            return vehicleMakeList.ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }
        public async Task<IEnumerable<IVehicleMake>> GetSelectListItemAsync()
        {
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetVehiclesAsync());
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }
    }
}
