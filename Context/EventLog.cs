namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventLog")]
    public partial class EventLog
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EventLog()
        {
            Administrator = new HashSet<Administrator>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Event_ID { get; set; }

        [Required]
        [StringLength(300)]
        public string EventName { get; set; }

        public DateTime? EventTime { get; set; }

        public int? WeatherSensor_ID { get; set; }

        public int? SoilSensor_ID { get; set; }

        public int? RadiationSensor_ID { get; set; }

        public int? WaterSensor_ID { get; set; }

        public int? Tech_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrator> Administrator { get; set; }

        public virtual RadiationSensor RadiationSensor { get; set; }

        public virtual SoilSensor SoilSensor { get; set; }

        public virtual Technician Technician { get; set; }

        public virtual WaterSensor WaterSensor { get; set; }

        public virtual WeatherSensor WeatherSensor { get; set; }
    }
}
