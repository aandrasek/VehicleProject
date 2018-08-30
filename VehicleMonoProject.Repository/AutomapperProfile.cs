using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.DAL;
using VehicleMonoProject.Model;
using VehicleMonoProject.Model.Common;

namespace VehicleMonoProject.Repository
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
        }
    }
}
