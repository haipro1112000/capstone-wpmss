namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNT")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            ROLE_IN_PROJECT = new HashSet<ROLE_IN_PROJECT>();
            TASKs = new HashSet<TASK>();
        }

        [Key]
        public int Acc_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Passwords { get; set; }

        [Required]
        [StringLength(40)]
        public string MemberName { get; set; }

        public bool iAdmin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ROLE_IN_PROJECT> ROLE_IN_PROJECT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASKs { get; set; }
    }
}
