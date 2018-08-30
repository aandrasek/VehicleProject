using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleMonoProject.MVC.ViewModels
{
    public class ModelViewModel
    {
        public int Id { get; set; }
        public int MakeId { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public string Image { get; set; }
        public string Color { get; set; }
        [Display(Name = "Mileage(in km)")]
        public int Mileage { get; set; }
        [Display(Name = "Production Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProductionDate { get; set; }
    }
}