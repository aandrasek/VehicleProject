using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleMonoProject.Model;
using VehicleMonoProject.MVC.ViewModels;

namespace VehicleMonoProject.MVC.App_Start
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleMake, MakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, ModelViewModel>().ReverseMap();
        }
    }
}