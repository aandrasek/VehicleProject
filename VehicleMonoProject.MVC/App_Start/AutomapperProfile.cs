using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleMonoProject.MVC.ViewModels;
using VehicleMonoProject.Service.Common;
using VehicleMonoProject.Service.Models;

namespace VehicleMonoProject.MVC.App_Start
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Make, IMake>().ReverseMap();
            CreateMap<Model, IModel>().ReverseMap();

            CreateMap<Make, MakeViewModel>().ReverseMap();
            CreateMap<Model, ModelViewModel>().ReverseMap();
        }
    }
}