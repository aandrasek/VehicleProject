using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VehicleMonoProject.Service.Common;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ModelListViewModel
    {
        public IList<IVehicleModel> vehicleList { get; set; }
        public string sort { get; set; }
        public string search { get; set; }
        public string direction { get; set; }
        public int page { get; set; }
        public int pageCount { get; set; }
    }
}