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
            var _vehicleMakeList = vehicleMakeService.ReadVehicleMake(sort, search, direction, page);
            var viewModel = new VehicleMakeList_ViewModel();
            viewModel.page = page ?? 1;
            viewModel.pageCount = _vehicleMakeList.PageCount;
            viewModel.sort = sort;
            viewModel.search = search;
            viewModel.direction = direction;
            viewModel.VehicleMakeList = AutoMapper.Mapper.Map<List<MakeViewModel>>(_vehicleMakeList.Results);
            return View(viewModel);
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
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithID = vehicleMakeService.FindVehicleMakeWithID(Id);
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
            return RedirectToAction("Delete",make.Id);
        }
        public ActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithID = vehicleMakeService.FindVehicleMakeWithID(Id);
                if (vehicleMakeWithID == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithID));
            }
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
            return RedirectToAction("Update",make.Id);
        }
    }
}