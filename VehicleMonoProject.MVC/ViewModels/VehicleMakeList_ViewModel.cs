using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class VehicleMakeList_ViewModel:BaseViewModel
    {
        public List<MakeViewModel> VehicleMakeList { get; set; }
    }
}