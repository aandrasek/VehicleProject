using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ListViewModel:ModelViewModel
    {
        public int[] SelectedID { get; set; } = new int[1];
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}