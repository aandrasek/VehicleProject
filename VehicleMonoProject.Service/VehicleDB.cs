using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMonoProject.Service.Models;

namespace VehicleMonoProject.Service
{
    public class VehicleDB : DbContext
    {
        public DbSet<Make> VehicleMake { get; set; }
        public DbSet<Model> VehicleModel { get; set; }
    }
}
