using Ninject;
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
        IVehicleMakeRepository VehicleMakeRepository;

        public VehicleModelService(IVehicleModelRepository VehicleModelRepository, IVehicleMakeRepository VehicleMakeRepository)
        {
            this.VehicleModelRepository = VehicleModelRepository;
            this.VehicleMakeRepository = VehicleMakeRepository;

        }

        public async Task CreateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image)
        {
            InsertImage(model, image);
            await VehicleModelRepository.AddVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model));
        }
        public async Task<IPagedList<IVehicleModel>> GetVehicleModelPagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            return await VehicleModelRepository.GetVehicleModelsAsync(sortParameters, filterParameters,pageParameters);
        }

        public async Task UpdateVehicleModelAsync(IVehicleModel model, HttpPostedFileBase image)
        {
            if (image != null)
            {
                if (model.Image == "default2.png")
                {
                    InsertImage(model, image);
                }
                else
                {
                    DeleteImage(model);
                    InsertImage(model, image);
                }
            }
            await VehicleModelRepository.EditVehicleModelAsync(model);
        }
        public async Task DeleteVehicleModelAsync(IVehicleModel model)
        {
            if (model.Image != "default2.png")
            {
                DeleteImage(model);
            }
            await VehicleModelRepository.DeleteVehicleModelAsync(model);
        }

        public async Task<IPagedList<IVehicleMake>> GetCategoryListAsync(IPageParameters pageParameters, IFilterParameters filterParameters)
        {
            return await VehicleMakeRepository.GetCategoryListAsync(pageParameters,filterParameters);
        }

        public async Task<IVehicleModel> FindVehicleModelWithIdAsync(int? id)
        {
            return await VehicleModelRepository.GetVehicleModelAsync(id??0);
        }

        public IVehicleModel InsertImage(IVehicleModel model, HttpPostedFileBase image)
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
            return model;
        }
        public void DeleteImage(IVehicleModel model)
        {
            string fullPath = HttpContext.Current.Request.MapPath("~/Images/VehicleModelImages/" + model.Image);
            if (File.Exists(fullPath))
            {
                File.Delete(fullPath);
            }
        }
    }
}
