namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INQUERYPP")]
    public partial class INQUERYPP
    {
        public bool PILIH { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string POP_NO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BRG { get; set; }

        [StringLength(1)]
        public string SATUAN { get; set; }

        public double QTY { get; set; }

        public double HSATUAN { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NO_URUT { get; set; }

        public int NO_URUT_PP { get; set; }

        [StringLength(255)]
        public string Nama2 { get; set; }

        [Required]
        [StringLength(20)]
        public string USERNAME { get; set; }

        public int URUTAN { get; set; }

        [StringLength(255)]
        public string CONNECTION_ID { get; set; }

        public double QTY_PP { get; set; }

        public double QTY_PO { get; set; }
    }
}
