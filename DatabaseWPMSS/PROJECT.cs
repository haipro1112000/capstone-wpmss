namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROJECTS")]
    public partial class PROJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROJECT()
        {
            PHASE_TASK = new HashSet<PHASE_TASK>();
            ROLE_IN_PROJECT = new HashSet<ROLE_IN_PROJECT>();
        }

        [Key]
        public int Project_id { get; set; }

        [Required]
        [StringLength(100)]
        public string Project_Name { get; set; }

        [StringLength(50)]
        public string Project_Type { get; set; }

        [Required]
        [StringLength(40)]
        public string Project_Manager { get; set; }

        [Column(TypeName = "date")]
        public DateTime Estimated_Start { get; set; }

        [Column(TypeName = "date")]
        public DateTime Estimated_End { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Project_Des { get; set; }

        public int Acc_ID { get; set; }

        public int Role_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHASE_TASK> PHASE_TASK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLE_IN_PROJECT> ROLE_IN_PROJECT { get; set; }
    }
}
