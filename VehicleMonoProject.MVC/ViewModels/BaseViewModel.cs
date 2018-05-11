using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class BaseViewModel
    {
        public int page { get; set; }
        public int pageCount { get; set; }
        public string sort { get; set; }
        public string search { get; set; }
        public string direction { get; set; }
    }
}