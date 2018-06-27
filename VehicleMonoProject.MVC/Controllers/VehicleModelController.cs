using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service.Services;
using VehicleMonoProject.Service.DAL;

namespace VehicleMonoProject.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        VehicleModelService vehicleModelService = new VehicleModelService();

        public ActionResult VehicleModelList(int? page, string sort, string direction, string search)
        {
            var sortParameters = new SortParameters() { Sort = sort, Direction = direction };
            var filterParameters = new FilterParameters() { Search = search };
            var pagingParameters = new PageParameters() { Page = page ?? 1, PageSize = 3 };
            var vehicleModelList = vehicleModelService.GetVehicleModelPaged(sortParameters, filterParameters, pagingParameters);
            ViewBag.search = search;
            ViewBag.sort = sort;
            ViewBag.direction = direction;
            var modelListViewModel = AutoMapper.Mapper.Map<IEnumerable<ModelViewModel>>(vehicleModelList);
            return View(new StaticPagedList<ModelViewModel>(modelListViewModel, vehicleModelList.GetMetaData()));
        }
        public ActionResult Create()
        {
            ListViewModel listViewModel = new ListViewModel()
            {
                Items = AutoMapper.Mapper.Map<IList<SelectListItem>>(vehicleModelService.GetVehicleMake().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }))
            };
            return View(listViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleModelService.CreateVehicleModel(AutoMapper.Mapper.Map<VehicleModel>(model));
                    return RedirectToAction("VehicleModelList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't create VehicleModel.");
            }
            return RedirectToAction("Create");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithId = vehicleModelService.FindVehicleModelWithId(id);
                if (vehicleModelWithId == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ModelViewModel model)
        {
            try
            {
                vehicleModelService.DeleteVehicleModel(AutoMapper.Mapper.Map<VehicleModel>(model));
                return View("Removal");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong! Can't delete VehicleMake.");
            }
            return RedirectToAction("Delete", model.Id);
        }
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithId = vehicleModelService.FindVehicleModelWithId(id);
                if (vehicleModelWithId == null)
                {
                    return HttpNotFound();
                }

                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,MakeId,Name,Abrv")] ModelViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleModelService.UpdateVehicleModel(AutoMapper.Mapper.Map<VehicleModel>(model));
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