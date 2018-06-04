using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ListViewModel : ModelViewModel
    {
        public IList<SelectListItem> Items { get; set; }
    }
}