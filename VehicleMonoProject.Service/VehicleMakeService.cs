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
using VehicleMonoProject.Model.Common;
using VehicleMonoProject.Repository.Common;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.Service.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        protected IVehicleMakeRepository VehicleMakeRepository { get; private set; }

        public VehicleMakeService(IVehicleMakeRepository VehicleMakeRepository)
        {
            this.VehicleMakeRepository = VehicleMakeRepository;
        }

        public void CreateVehicleMake(IVehicleMake make, HttpPostedFileBase image)
        {
            if (image != null)
            {
                var nameWithoutExtension = Path.GetFileNameWithoutExtension(image.FileName);
                var extension = Path.GetExtension(image.FileName);
                make.Image = nameWithoutExtension + DateTime.Now.ToString("MMddyyHmmss") + extension;
                var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Images/VehicleMakeImages/"), make.Image);
                image.SaveAs(path);
            }
            else
            {
                make.Image = "default1.png";
            }
            VehicleMakeRepository.AddVehicleMake(make);

        }
        public IPagedList<IVehicleMake> GetVehicleMakePaged(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleMakeList = VehicleMakeRepository.GetAllVehicleMakes().AsEnumerable();
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
        public void UpdateVehicleMake(IVehicleMake make)
        {
            VehicleMakeRepository.EditVehicleMake(make);
        }
        public void DeleteVehicleMake(IVehicleMake make)
        {
            if (make.Image != "default1.png")
            {
                string fullPath = HttpContext.Current.Request.MapPath("~/Images/VehicleMakeImages/" + make.Image);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
            VehicleMakeRepository.DeleteVehicleMake(make);
        }
        public IVehicleMake FindVehicleMakeWithId(int? id)
        {
            return VehicleMakeRepository.GetVehicleMake(id ?? 0);
        }
    }
}
