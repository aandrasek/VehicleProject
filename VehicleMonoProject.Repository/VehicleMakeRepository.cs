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

        public async Task<IEnumerable<IVehicleMake>> GetVehicleMakesAsync(ISortParameters sortParameters, IFilterParameters filterParameters)
        {
            Expression<Func<VehicleMakeEntity, bool>> filterExpression = c => false;
            Expression<Func<VehicleMakeEntity, string>> sortExpression = c => c.Id.ToString();
            switch (sortParameters.Sort)
            {
                case "Name":
                    sortExpression = c => c.Name;
                    break;
                case "Abrv":
                    sortExpression = c => c.Abrv;
                    break;
                default:
                    break;
            }
            if (!string.IsNullOrEmpty(filterParameters.Search))
            {
                filterExpression = c => c.Name.ToUpper().Contains(filterParameters.Search.ToUpper());
            }
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetVehiclesAsync(sortExpression, filterExpression));
        }
        public async Task<IEnumerable<IVehicleMake>> GetSelectListItemAsync()
        {
            Expression<Func<VehicleMakeEntity, bool>> filterExpression = c => false;
            Expression<Func<VehicleMakeEntity, string>> sortExpression = c => c.Id.ToString();

            return AutoMapper.Mapper.Map<IEnumerable<IVehicleMake>>(await Repository.GetVehiclesAsync(sortExpression, filterExpression));
        }

        public async Task<IVehicleMake> GetVehicleMakeAsync(int id)
        {
            return AutoMapper.Mapper.Map<IVehicleMake>(await Repository.GetVehicleAsync(id));
        }
    }
}
