using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service.DAL;
using VehicleMonoProject.Service.Common.EntityCommon;

namespace VehicleMonoProject.MVC.App_Start
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            CreateMap<VehicleMake, MakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, ModelViewModel>().ReverseMap();
            CreateMap<VehicleModel, ListViewModel>().ReverseMap();

        }
    }
}