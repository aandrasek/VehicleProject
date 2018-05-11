using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class VehicleModelList_ViewModel:BaseViewModel
    {
        public List<ModelViewModel> VehicleModelList { get; set; }
    }
}