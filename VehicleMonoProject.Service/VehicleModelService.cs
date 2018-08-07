using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VehicleMonoProject.Common.ParametersCommon;
using VehicleMonoProject.Model;
using VehicleMonoProject.Model.Common;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.Service.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        IVehicleModelRepository VehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository VehicleModelRepository)
        {
            this.VehicleModelRepository = VehicleModelRepository;
        }

        public async Task CreateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image)
        {
            if (image != null)
            {
                var nameWithoutExtension = Path.GetFileNameWithoutExtension(image.FileName);
                var extension = Path.GetExtension(image.FileName);
                model.Image = nameWithoutExtension + DateTime.Now.ToString("MMddyyHmmss") + extension;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/VehicleModelImages/"), model.Image);
                image.SaveAs(path);
            }
            else
            {
                model.Image = "default2.png";
            }
            await VehicleModelRepository.AddVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model));
        }
        public async Task<IPagedList<IVehicleModel>> GetVehicleModelPagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await VehicleModelRepository.GetVehicleModelsAsync(sortParameters, filterParameters,pageParameters);
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel model)
        {
            await VehicleModelRepository.EditVehicleModelAsync(model);
        }
        public async Task DeleteVehicleModelAsync(IVehicleModel model)
        {
            if (model.Image != "default2.png")
            {
                string fullPath = HttpContext.Current.Request.MapPath("~/Images/VehicleMakeImages/" + model.Image);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            await VehicleModelRepository.DeleteVehicleModelAsync(model);
        }
        public async Task<IVehicleModel> FindVehicleModelWithIdAsync(int? id)
        {
            return await VehicleModelRepository.GetVehicleModelAsync(id??0);
        }
    }
}
