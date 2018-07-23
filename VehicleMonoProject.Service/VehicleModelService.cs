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
        protected IVehicleModelRepository VehicleModelRepository { get; private set; }

        public VehicleModelService(IVehicleModelRepository VehicleModelRepository)
        {
            this.VehicleModelRepository = VehicleModelRepository;
        }

        public void CreateVehicleModel(IVehicleModel model, HttpPostedFileBase image)
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
            VehicleModelRepository.AddVehicleModel(AutoMapper.Mapper.Map<VehicleModel>(model));
        }
        public IPagedList<IVehicleModel> GetVehicleModelPaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleModelList = VehicleModelRepository.GetAllVehicleModels().AsEnumerable();
            switch (sortParameters.Sort)
            {
                case "Name":
                    vehicleModelList = vehicleModelList.OrderBy(c => c.Name);
                    break;
                case "MakeId":
                    vehicleModelList = vehicleModelList.OrderBy(c => c.MakeId);
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
        public IEnumerable<IVehicleMake> GetVehicleMakes()
        {
            return VehicleModelRepository.GetAllVehicleMakes();
        }
        public void UpdateVehicleModel(IVehicleModel model)
        {
            VehicleModelRepository.EditVehicleModel(model);
        }
        public void DeleteVehicleModel(IVehicleModel model)
        {
            if (model.Image != "default2.png")
            {
                string fullPath = HttpContext.Current.Request.MapPath("~/Images/VehicleMakeImages/" + model.Image);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            VehicleModelRepository.DeleteVehicleModel(model);
        }
        public IVehicleModel FindVehicleModelWithId(int? id)
        {
            return VehicleModelRepository.GetVehicleModel(id??0);
        }
    }
}
