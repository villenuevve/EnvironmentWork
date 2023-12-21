namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RadiationSensor")]
    public partial class RadiationSensor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RadiationSensor()
        {
            EventLog = new HashSet<EventLog>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RadiationSensor_ID { get; set; }

        public int? Technician_ID { get; set; }

        public double RadiationSensor_Value { get; set; }

        [Required]
        [StringLength(150)]
        public string RadiationSensor_Location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventLog> EventLog { get; set; }

        public virtual Technician Technician { get; set; }
    }
}
