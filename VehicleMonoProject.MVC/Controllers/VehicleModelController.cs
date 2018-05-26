using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        VehicleModelService vehicleModelService = new VehicleModelService();

        public ActionResult VehicleModelList(int? page, string sort, string direction, string search)
        {
            var sortParameters = new SortParameters() { sort = sort, direction = direction };
            var filterParameters = new FilterParameters() { search = search };
            var pagingParameters = new PageParameters() { page = page ?? 1, pageSize = 3 };
            var vehicleModelList = vehicleModelService.ReadVehicleModel(sortParameters, filterParameters, pagingParameters);
            return View(AutoMapper.Mapper.Map<ModelListViewModel>(vehicleModelList));
        }
        public ActionResult Create()
        {
            ListViewModel listViewModel = new ListViewModel();
            listViewModel.Items = vehicleModelService.ReadVehicleMake().Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
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
            var vehicleModelWithId = vehicleModelService.FindVehicleModelWithId(id ?? 0);
            if (vehicleModelWithId == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
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
            var vehicleModelWithId = vehicleModelService.FindVehicleModelWithId(id ?? 0);
            if (vehicleModelWithId == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithId));
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