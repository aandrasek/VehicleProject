using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int[] SelectedID { get; set; } = new int[1];
        public IEnumerable<SelectListItem> Items { get; set; }
    }
}