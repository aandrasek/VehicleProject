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
        IVehicleMakeRepository VehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository VehicleMakeRepository)
        {
            this.VehicleMakeRepository = VehicleMakeRepository;
        }

        public async Task CreateVehicleMakeAsync(IVehicleMake make, HttpPostedFileBase image)
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
           await VehicleMakeRepository.AddVehicleMakeAsync(make);

        }
        public async Task<IPagedList<IVehicleMake>> GetVehicleMakePagedAsync(ISortParameters sortParameters, IFilterParameters filterParameters, IPageParameters pageParameters)
        {
            var vehicleMakeList = await VehicleMakeRepository.GetVehicleMakesAsync(sortParameters,filterParameters);

            if (sortParameters.Direction == "Descending")
            {
                vehicleMakeList = vehicleMakeList.Reverse();
            }

            return vehicleMakeList.ToPagedList(pageParameters.Page, pageParameters.PageSize);
        }
        public async Task UpdateVehicleMakeAsync(IVehicleMake make)
        {
           await VehicleMakeRepository.EditVehicleMakeAsync(make);
        }
        public async Task DeleteVehicleMakeAsync(IVehicleMake make)
        {
            if (make.Image != "default1.png")
            {
                string fullPath = HttpContext.Current.Request.MapPath("~/Images/VehicleMakeImages/" + make.Image);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
           await VehicleMakeRepository.DeleteVehicleMakeAsync(make);
        }

        public async Task<IEnumerable<IVehicleMake>> GetSelectListItemAsync()
        {
            return await VehicleMakeRepository.GetSelectListItemAsync();
        }

        public async Task<IVehicleMake> FindVehicleMakeWithIdAsync(int? id)
        {
            return await VehicleMakeRepository.GetVehicleMakeAsync(id ?? 0);
        }
    }
}
