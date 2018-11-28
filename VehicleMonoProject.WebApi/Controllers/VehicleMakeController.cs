using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.Model;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.WebApi.Models;

namespace VehicleMonoProject.WebApi.Controllers
{
    public class VehicleMakeController : ApiController
    {
        public IVehicleMakeService Service { get; set; }

        public VehicleMakeController(IVehicleMakeService service)
        {
            this.Service = service;
        }

        // GET: api/VehicleMake
        [HttpGet]
        public async Task<IEnumerable<VehicleMakeViewModel>> GetVehicleMake()
        {
            var sortParameters = new SortParameters() {};
            var filterParameters = new FilterParameters() {};
            var pagingParameters = new PageParameters() { Page = 1, PageSize = 12 };
            return AutoMapper.Mapper.Map<IEnumerable<VehicleMakeViewModel>>(await Service.GetVehicleMakePagedAsync(sortParameters,filterParameters,pagingParameters)).ToList();
        }


        // POST: api/VehicleMake
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMakeViewModel make)
        {
            HttpPostedFileBase image=null;

            await Service.CreateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make),image);

            return CreatedAtRoute("DefaultApi", new { id = make.Id }, make);
        }

        // PUT: api/VehicleMake/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMakeViewModel make)
        {
            HttpPostedFileBase image = null;

            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            var vehicleMake = AutoMapper.Mapper.Map<VehicleMakeViewModel>(await Service.FindVehicleMakeWithIdAsync(id));

            if (vehicleMake != null)
            {
                vehicleMake.Name = make.Name;
                vehicleMake.Abrv = make.Abrv;

                await Service.UpdateVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(vehicleMake),image);

            }
            else
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE: api/VehicleMake/5
        [ResponseType(typeof(VehicleMakeViewModel))]
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            var make = AutoMapper.Mapper.Map<VehicleMakeViewModel>(await Service.FindVehicleMakeWithIdAsync(id));

            if (make == null)
            {
                return NotFound();
            }

            await Service.DeleteVehicleMakeAsync(AutoMapper.Mapper.Map<VehicleMake>(make));

            return Ok(make);
        }
    }
}