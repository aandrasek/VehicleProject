using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.Service.Models;

namespace VehicleMonoProject.MVC.Controllers
{
    public class MakeController : Controller
    {
        VehicleService Service = new VehicleService();

        public ActionResult Index(int? page, string sort)
        {
            var list = Service.ReadMake(sort);
            var prr = Service.ListMake(list, page ?? 1, 3);
            var mapped = AutoMapper.Mapper.Map<List<MakeViewModel>>(prr.Results);
            ViewBag.page = page ?? 1;
            ViewBag.pageCount = prr.PageCount;
            ViewBag.sort = sort;
            return View(mapped);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(MakeViewModel item)
        {
            Service.CreateMake(AutoMapper.Mapper.Map<Make>(item));
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var item = Service.FindMakeWithID(Id);
            return View(AutoMapper.Mapper.Map<MakeViewModel>(item));
        }
        [HttpPost]
        public ActionResult Delete(MakeViewModel item)
        {
            Service.DeleteMake(AutoMapper.Mapper.Map<Make>(item));
            return View("Removal");
        }
        public ActionResult Update(int Id)
        {
            var item = Service.FindMakeWithID(Id);
            return View(AutoMapper.Mapper.Map<MakeViewModel>(item));
        }
        [HttpPost]
        public ActionResult Update(MakeViewModel item)
        {
            Service.UpdateMake(AutoMapper.Mapper.Map<Make>(item));
            return RedirectToAction("Index");
        }
    }
}