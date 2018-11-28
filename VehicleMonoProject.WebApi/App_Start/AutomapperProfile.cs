using AutoMapper;
using VehicleMonoProject.Model;
using VehicleMonoProject.WebApi.Models;

namespace VehicleMonoProject.WebApi.App_Start
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelViewModel>().ReverseMap();
        }
    }
}