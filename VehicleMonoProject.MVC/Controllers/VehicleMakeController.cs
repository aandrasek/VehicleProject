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
    public class VehicleMakeController : Controller
    {
        VehicleMakeService vehicleMakeService = new VehicleMakeService();

        public ActionResult VehicleMakeList(int? page, string sort, string direction, string search)
        {
            var vehicleMakeList = vehicleMakeService.ReadVehicleMake(sort, search, direction, page,3);
            ViewBag.page = page ?? 1;
            ViewBag.pageCount = vehicleMakeList.PageCount;
            ViewBag.sort = sort;
            ViewBag.search = search;
            ViewBag.direction = direction;
            return View(AutoMapper.Mapper.Map<IList<MakeViewModel>>(vehicleMakeList.Results));
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
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithID = vehicleMakeService.FindVehicleMakeWithID(ID ?? 0);
                if (vehicleMakeWithID == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithID));
            }

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
            return RedirectToAction("Delete",make.ID);
        }
        public ActionResult Update(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithID = vehicleMakeService.FindVehicleMakeWithID(ID ?? 0);
                if (vehicleMakeWithID == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithID));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "ID,Name,Abrv")] MakeViewModel make)
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
            return RedirectToAction("Update",make.ID);
        }
    }
}