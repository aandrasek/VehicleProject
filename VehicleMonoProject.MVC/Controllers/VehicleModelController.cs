using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.Model;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        IVehicleModelService vehicleModelService;
        IVehicleMakeService vehicleMakeService;


        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            this.vehicleModelService = vehicleModelService;
            this.vehicleMakeService = vehicleMakeService;
        }

        public async Task<ActionResult> VehicleModelList(int? page, string sort, string direction, string search)
        {
            var sortParameters = new SortParameters() { Sort = sort, Direction = direction };
            var filterParameters = new FilterParameters() { Search = search };
            var pagingParameters = new PageParameters() { Page = page ?? 1, PageSize = 3 };
            var vehicleModelList = await vehicleModelService.GetVehicleModelPagedAsync(sortParameters, filterParameters, pagingParameters);
            ViewBag.search = search;
            ViewBag.sort = sort;
            ViewBag.direction = direction;
            var modelListViewModel = AutoMapper.Mapper.Map<IEnumerable<ModelViewModel>>(vehicleModelList);
            return View(new StaticPagedList<ModelViewModel>(modelListViewModel, vehicleModelList.GetMetaData()));
        }
        public async Task<ActionResult> Create()
        {
            var vehicleMakeList = await vehicleMakeService.GetSelectListItemAsync();
            ListViewModel listViewModel = new ListViewModel()
            {
                Items =  AutoMapper.Mapper.Map<IList<SelectListItem>>(vehicleMakeList.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }))
            };
            return View(listViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ListViewModel model, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.CreateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model),image);
                    return RedirectToAction("VehicleModelList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't create VehicleModel.");
            }
            return RedirectToAction("Create");
        }
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithId = await vehicleModelService.FindVehicleModelWithIdAsync(id);
                if (vehicleModelWithId == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete([Bind(Include = "Id,Name,Abrv,Image")] ModelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.DeleteVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model));
                    return RedirectToAction("VehicleModelList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't delete VehicleModel.");
            }
            return RedirectToAction("Delete", model.Id);
        }
        public async Task<ActionResult> Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithId = await vehicleModelService.FindVehicleModelWithIdAsync(id);
                if (vehicleModelWithId == null)
                {
                    return HttpNotFound();
                }

                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update([Bind(Include = "Id,MakeId,Name,Abrv,Image")] ModelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.UpdateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model));
                    return RedirectToAction("VehicleModelList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't update VehicleModel.");
            }
            return RedirectToAction("Update", model.Id);
        }
    }
}