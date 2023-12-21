namespace EnvironmentWork.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrator")]
    public partial class Administrator
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Admin_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Admin_Password { get; set; }

        public int? Event_ID { get; set; }

        public virtual EventLog EventLog { get; set; }
    }
}
