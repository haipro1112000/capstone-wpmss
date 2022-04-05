namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHASE_TASK
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Phase { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Project_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Dates { get; set; }

        [Column(TypeName = "date")]
        public DateTime Finish_Dates { get; set; }

        public virtual PHASE PHASE { get; set; }

        public virtual PROJECT PROJECT { get; set; }
    }
}
