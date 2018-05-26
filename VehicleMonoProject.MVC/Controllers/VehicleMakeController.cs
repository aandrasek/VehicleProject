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
    public class VehicleMakeController : Controller
    {
        VehicleMakeService vehicleMakeService = new VehicleMakeService();

        public ActionResult VehicleMakeList(int? page, string sort, string direction, string search)
        {
            var sortParameters = new SortParameters() { sort = sort, direction = direction };
            var filterParameters = new FilterParameters() { search = search };
            var pagingParameters = new PageParameters() { page = page ?? 1, pageSize = 3 };
            var vehicleMakeList = vehicleMakeService.ReadVehicleMake(sortParameters, filterParameters, pagingParameters);
            return View(AutoMapper.Mapper.Map<MakeListViewModel>(vehicleMakeList));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Abrv")] MakeViewModel make)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleMakeService.CreateVehicleMake(AutoMapper.Mapper.Map<VehicleMake>(make));
                    return RedirectToAction("VehicleMakeList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't create VehicleMake.");
            }
            return RedirectToAction("Create");
        }
        public ActionResult Delete(int? id)
        {
            var vehicleMakeWithId = vehicleMakeService.FindVehicleMakeWithId(id ?? 0);
            if (vehicleMakeWithId == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithId));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MakeViewModel make)
        {
            try
            {
                vehicleMakeService.DeleteVehicleMake(AutoMapper.Mapper.Map<VehicleMake>(make));
                return View("Removal");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong! Can't delete VehicleMake.");
            }
            return RedirectToAction("Delete", make.Id);
        }
        public ActionResult Update(int? id)
        {
            var vehicleMakeWithId = vehicleMakeService.FindVehicleMakeWithId(id ?? 0);
            if (vehicleMakeWithId == null)
            {
                return HttpNotFound();
            }
            return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithId));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "Id,Name,Abrv")] MakeViewModel make)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleMakeService.UpdateVehicleMake(AutoMapper.Mapper.Map<VehicleMake>(make));
                    return RedirectToAction("VehicleMakeList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't update VehicleMake.");
            }
            return RedirectToAction("Update", make.Id);
        }
    }
}