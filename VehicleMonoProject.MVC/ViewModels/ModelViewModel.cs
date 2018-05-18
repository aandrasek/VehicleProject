using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ModelViewModel
    {
        public int ID { get; set; }
        public int MakeID { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
    }
}