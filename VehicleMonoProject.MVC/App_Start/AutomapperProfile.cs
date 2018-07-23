using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Model;
using VehicleMonoProject.Model.Common;
using VehicleMonoProject.MVC.ViewModels;

namespace VehicleMonoProject.MVC.App_Start
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {

            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();

            CreateMap<VehicleMake, MakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, ModelViewModel>().ReverseMap();
            CreateMap<VehicleModel, ListViewModel>().ReverseMap();

        }
    }
}