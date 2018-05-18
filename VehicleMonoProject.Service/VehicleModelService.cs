﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Common;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        VehicleDB context = new VehicleDB();

        public void CreateVehicleModel(IVehicleModel model)
        {
            var vehicleMake = context.VehicleMakes.First(c => c.ID == model.MakeID);
            vehicleMake.VehicleModels.Add(AutoMapper.Mapper.Map<VehicleModel>(model));
            context.SaveChanges();
        }
        public PagedResult<IVehicleModel> ReadVehicleModel(string sort, string direction, string search, int? page, int pageSize)
        {
            var vehicleModelList = AutoMapper.Mapper.Map<IList<IVehicleModel>>(context.VehicleModels.ToList());
            if (!string.IsNullOrEmpty(sort) && vehicleModelList.Count != 0)
            {
                vehicleModelList = Sort<IVehicleModel>.VehicleSort(vehicleModelList, sort, direction);
            }
            if (!string.IsNullOrEmpty(search))
            {
                vehicleModelList = Filter<IVehicleModel>.VehicleFilter(vehicleModelList, sort, search);
            }
            var result = PagedResult<IVehicleModel>.GetPagedResultForList(vehicleModelList, page ?? 1, pageSize);
            return AutoMapper.Mapper.Map<PagedResult<IVehicleModel>>(result);

        }
        public IList<IVehicleMake> ReadVehicleMake()
        {
            return AutoMapper.Mapper.Map<IList<IVehicleMake>>(context.VehicleMakes.ToList());
        }
        public void UpdateVehicleModel(IVehicleModel model)
        {
            context.Entry(model).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteVehicleModel(IVehicleModel model)
        {
            context.VehicleModels.Remove(context.VehicleModels.Where(c => c.ID == model.ID).FirstOrDefault());
            context.SaveChanges();
        }
        public IVehicleModel FindVehicleModelWithID(int ID)
        {
            return context.VehicleModels.Where(c => c.ID == ID).FirstOrDefault();
        }
    }
}