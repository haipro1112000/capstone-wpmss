namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ROLE_ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ROLE_ACCOUNT()
        {
            ROLE_IN_PROJECT = new HashSet<ROLE_IN_PROJECT>();
        }

        [Key]
        public int Role_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Role_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLE_IN_PROJECT> ROLE_IN_PROJECT { get; set; }
    }
}
