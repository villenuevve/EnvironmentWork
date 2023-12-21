namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Info
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
    }
}
