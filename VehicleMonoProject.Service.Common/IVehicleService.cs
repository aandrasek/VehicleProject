using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;

namespace VehicleMonoProject.Service.Common
{
    public interface IVehicleService
    {
        void CreateMake(IMake item);
        IList<IMake> ReadMake(string sort);
        void UpdateMake(IMake item);
        void DeleteMake(IMake item);
        IMake FindMakeWithID(int Id);
        PagedResult<IMake> ListMake(IList<IMake> list, int pageNumber, int pageSize);

        void CreateModel(IModel item);
        IList<IModel> ReadModel(string sort);
        void UpdateModel(IModel item);
        void DeleteModel(IModel item);
        IModel FindModelWithID(int Id);
        PagedResult<IModel> ListModel(IList<IModel> list, int pageNumber, int pageSize);

    }
}
