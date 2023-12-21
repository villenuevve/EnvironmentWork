namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class More_Info
    {
        [Key]
        [Column("Event ID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Event_ID { get; set; }

        [Key]
        [Column("Event name", Order = 1)]
        [StringLength(300)]
        public string Event_name { get; set; }

        [Column("Event date")]
        public DateTime? Event_date { get; set; }

        [Column("Technician ID")]
        public int? Technician_ID { get; set; }

        [Key]
        [Column("Technician Last name", Order = 2)]
        [StringLength(50)]
        public string Technician_Last_name { get; set; }

        [Key]
        [Column("Administrator ID", Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Administrator_ID { get; set; }

        [Key]
        [Column("Administrator Last name", Order = 4)]
        [StringLength(50)]
        public string Administrator_Last_name { get; set; }
    }
}
