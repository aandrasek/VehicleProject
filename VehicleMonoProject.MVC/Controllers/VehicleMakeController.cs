using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.Common.Parameters;
using VehicleMonoProject.Model;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        IVehicleMakeService vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            this.vehicleMakeService = vehicleMakeService;
        }

        public ActionResult VehicleMakeList(int? page, string sort, string direction, string search)
        {
            var sortParameters = new SortParameters() { Sort = sort, Direction = direction };
            var filterParameters = new FilterParameters() { Search = search };
            var pagingParameters = new PageParameters() { Page = page ?? 1, PageSize = 3 };
            var vehicleMakeList = vehicleMakeService.GetVehicleMakePaged(sortParameters, filterParameters, pagingParameters);
            ViewBag.search = search;
            ViewBag.sort = sort;
            ViewBag.direction = direction;
            var makeListViewModel = AutoMapper.Mapper.Map<IEnumerable<MakeViewModel>>(vehicleMakeList);
            return View(new StaticPagedList<MakeViewModel>(makeListViewModel, vehicleMakeList.GetMetaData()));

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Abrv")] MakeViewModel make, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleMakeService.CreateVehicleMake(AutoMapper.Mapper.Map<VehicleMake>(make),image);
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithId = vehicleMakeService.FindVehicleMakeWithId(id);
                if (vehicleMakeWithId == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithId));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id,Name,Abrv,Image")] MakeViewModel make)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vehicleMakeService.DeleteVehicleMake(AutoMapper.Mapper.Map<VehicleMake>(make));
                    return RedirectToAction("VehicleMakeList");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Something went wrong! Can't delete VehicleMake.");
            }
            return RedirectToAction("Delete", make.Id);
        }
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var vehicleMakeWithId = vehicleMakeService.FindVehicleMakeWithId(id);
                if (vehicleMakeWithId == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapper.Mapper.Map<MakeViewModel>(vehicleMakeWithId));
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
            return RedirectToAction("Update", make.Id);
        }
    }
}