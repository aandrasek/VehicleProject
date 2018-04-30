using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service;
using VehicleMonoProject.Service.Models;

namespace VehicleMonoProject.MVC.Controllers
{
    public class ModelController : Controller
    {
        VehicleService Service = new VehicleService();

        public ActionResult Index(int? page, string sort)
        {
            var list = Service.ReadModel(sort);
            var prr = Service.ListModel(list, page ?? 1, 3);
            var mapped = AutoMapper.Mapper.Map<List<ModelViewModel>>(prr.Results);
            ViewBag.page = page ?? 1;
            ViewBag.pageCount = prr.PageCount;
            ViewBag.sort = sort;
            return View(mapped);
        }
        public ActionResult Create()
        {
            ListViewModel svm = new ListViewModel();
            svm.Items = Service.ReadMake("").Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name });
            return View(svm);
        }
        [HttpPost]
        public ActionResult Create(ListViewModel item)
        {
            ModelViewModel item2 = new ModelViewModel() { MakeId = item.SelectedID.First(),Name=item.Name,Abrv=item.Abrv};
            Service.CreateModel(AutoMapper.Mapper.Map<Model>(item2));
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var item = Service.FindModelWithID(Id);
            return View(AutoMapper.Mapper.Map<ModelViewModel>(item));
        }
        [HttpPost]
        public ActionResult Delete(ModelViewModel item)
        {
            Service.DeleteModel(AutoMapper.Mapper.Map<Model>(item));
            return View("Removal");
        }
        public ActionResult Update(int Id)
        {
            var item = Service.FindModelWithID(Id);
            return View(AutoMapper.Mapper.Map<ModelViewModel>(item));
        }
        [HttpPost]
        public ActionResult Update(ModelViewModel item)
        {
            Service.UpdateModel(AutoMapper.Mapper.Map<Model>(item));
            return RedirectToAction("Index");
        }
    }
}