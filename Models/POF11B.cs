namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class POF11B
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string SUPP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BRG { get; set; }

        [StringLength(30)]
        public string NAMA { get; set; }

        [StringLength(5)]
        public string STN { get; set; }

        [StringLength(5)]
        public string STN2 { get; set; }

        public double HARGABESAR { get; set; }

        public double HARGAKECIL { get; set; }

        [Required]
        [StringLength(5)]
        public string STN3 { get; set; }

        [Required]
        [StringLength(5)]
        public string STN4 { get; set; }

        public double H_STN_3 { get; set; }

        public double H_STN_4 { get; set; }
    }
}
