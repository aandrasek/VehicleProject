namespace VehicleMonoProject.DAL
{
    using System;
    using System.Collections.Generic;

    public partial class VehicleMakeEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleMakeEntity()
        {
            VehicleModels = new HashSet<VehicleModelEntity>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
