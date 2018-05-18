using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
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
            var vehicleModelList = vehicleModelService.ReadVehicleModel(sort, direction, search, page,3);
            ViewBag.page = page ?? 1;
            ViewBag.pageCount = vehicleModelList.PageCount;
            ViewBag.sort = sort;
            ViewBag.search = search;
            ViewBag.direction = direction;
            return View(AutoMapper.Mapper.Map<IList<ModelViewModel>>(vehicleModelList.Results));
        }
        public ActionResult Create()
        {
            ListViewModel listViewModel = new ListViewModel();
            listViewModel.Items = vehicleModelService.ReadVehicleMake().Select(c => new SelectListItem { Value = c.ID.ToString(), Text = c.Name });
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
                    model.MakeID = model.SelectedID.FirstOrDefault();
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
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithID = vehicleModelService.FindVehicleModelWithID(ID ?? 0);
                if (vehicleModelWithID == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithID));
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
            return RedirectToAction("Delete", model.ID);
        }
        public ActionResult Update(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleModelWithID = vehicleModelService.FindVehicleModelWithID(ID ?? 0);
                if (vehicleModelWithID == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<ModelViewModel>(vehicleModelWithID));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ID,MakeID,Name,Abrv")] ModelViewModel model)
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
            return RedirectToAction("Update", model.ID);
        }
    }
}