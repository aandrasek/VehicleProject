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

        public async Task<IEnumerable<IVehicleModel>> GetVehicleModelsAsync(ISortParameters sortParameters, IFilterParameters filterParameters)
        {
            Expression<Func<VehicleModelEntity, bool>> filterExpression = c => false;
            Expression<Func<VehicleModelEntity, string>> sortExpression = c => c.Id.ToString();
            switch (sortParameters.Sort)
            {
                case "MakeId":
                    sortExpression = c => c.MakeId.ToString();
                    break;
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
            return AutoMapper.Mapper.Map<IEnumerable<IVehicleModel>>(await Repository.GetVehiclesAsync(sortExpression, filterExpression));
        }

        public async Task<IVehicleModel> GetVehicleModelAsync(int id)
        {           
            return AutoMapper.Mapper.Map<IVehicleModel>(await Repository.GetVehicleAsync(id));
        }
    }
}
