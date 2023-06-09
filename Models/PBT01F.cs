namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PBT01F
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string JENIS_FORM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string NO_BUKTI { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_1 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_2 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_3 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_4 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_5 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_6 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_7 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_8 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_9 { get; set; }

        [Required]
        [StringLength(40)]
        public string CATATAN_10 { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        public virtual PBT01A PBT01A { get; set; }
    }
}
