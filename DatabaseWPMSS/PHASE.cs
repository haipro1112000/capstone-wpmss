namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHASE")]
    public partial class PHASE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHASE()
        {
            TASKs = new HashSet<TASK>();
            PHASE_TASK = new HashSet<PHASE_TASK>();
        }

        [Key]
        public int ID_Phase { get; set; }

        [StringLength(50)]
        public string Name_Phase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHASE_TASK> PHASE_TASK { get; set; }
    }
}
