using PagedList;
using System.Collections.Generic;
using System.Data;
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
        protected IVehicleModelService vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService, IVehicleMakeService vehicleMakeService)
        {
            this.vehicleModelService = vehicleModelService;
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
        public async Task<ActionResult> SelectCategory(int? page,string search)
        {
            var pagingParameters = new PageParameters() { Page = page ?? 1, PageSize = 6 };
            var filterParameters = new FilterParameters() { Search = search };
            var vehicleMakeList = await vehicleModelService.GetCategoryListAsync(pagingParameters,filterParameters);
            var makeListViewModel = AutoMapper.Mapper.Map<IEnumerable<MakeViewModel>>(vehicleMakeList);
            ViewBag.search = search;
            return View(new StaticPagedList<MakeViewModel>(makeListViewModel, vehicleMakeList.GetMetaData()));
        }
        public ActionResult Create(int? makeId)
        {
            if (makeId == null)
            {
                return RedirectToAction("SelectCategory");
            }
            ModelViewModel viewModel = new ModelViewModel() { MakeId = makeId ?? 0 };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ModelViewModel model, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.CreateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model), image);
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
        public async Task<ActionResult> Delete([Bind(Include = "Id,Name,Abrv,Image,Color,Mileage,ProductionDate")] ModelViewModel model)
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
        public async Task<ActionResult> Update([Bind(Include = "Id,MakeId,Name,Abrv,Image,Color,Mileage,ProductionDate")] ModelViewModel model, HttpPostedFileBase image)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await vehicleModelService.UpdateVehicleModelAsync(AutoMapper.Mapper.Map<VehicleModel>(model),image);
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