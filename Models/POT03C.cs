namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class POT03C
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string NO_MATRIK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SUPPLIER_CODE { get; set; }

        [StringLength(40)]
        public string CATATAN_1 { get; set; }

        [StringLength(40)]
        public string CATATAN_2 { get; set; }

        [StringLength(40)]
        public string CATATAN_3 { get; set; }

        [StringLength(40)]
        public string CATATAN_4 { get; set; }

        [StringLength(40)]
        public string CATATAN_5 { get; set; }

        [StringLength(40)]
        public string CATATAN_6 { get; set; }

        [StringLength(40)]
        public string CATATAN_7 { get; set; }

        [StringLength(40)]
        public string CATATAN_8 { get; set; }

        [StringLength(40)]
        public string CATATAN_9 { get; set; }

        [StringLength(40)]
        public string CATATAN_10 { get; set; }

        [Column(TypeName = "text")]
        public string KETERANGAN { get; set; }

        public double TERM_BAYAR { get; set; }

        public double TERM_KIRIM { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        public virtual POT03A POT03A { get; set; }
    }
}