namespace DatabaseWPMSS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TASK")]
    public partial class TASK
    {
        [Key]
        public int ID_Task { get; set; }

        public int Task_Number { get; set; }

        [Required]
        [StringLength(200)]
        public string Task_Name { get; set; }

        public int Duration_Day { get; set; }

        [Column(TypeName = "date")]
        public DateTime Start_Dates { get; set; }

        [Column(TypeName = "date")]
        public DateTime Finish_Dates { get; set; }

        public int Acc_ID { get; set; }

        public int ID_Phase { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        public virtual PHASE PHASE { get; set; }
    }
}
