namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Technician")]
    public partial class Technician
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Technician()
        {
            EventLog = new HashSet<EventLog>();
            RadiationSensor = new HashSet<RadiationSensor>();
            SoilSensor = new HashSet<SoilSensor>();
            WaterSensor = new HashSet<WaterSensor>();
            WeatherSensor = new HashSet<WeatherSensor>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Tech_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Tech_FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Tech_LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Tech_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Tech_Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventLog> EventLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RadiationSensor> RadiationSensor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoilSensor> SoilSensor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WaterSensor> WaterSensor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WeatherSensor> WeatherSensor { get; set; }
    }
}
