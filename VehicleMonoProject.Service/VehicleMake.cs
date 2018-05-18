namespace VehicleMonoProject.Service
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using VehicleMonoProject.Service.Common;

    public partial class VehicleMake:IVehicleMake
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleMake()
        {
            VehicleModels = new HashSet<VehicleModel>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
