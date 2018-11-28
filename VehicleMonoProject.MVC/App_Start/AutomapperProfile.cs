using AutoMapper;
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