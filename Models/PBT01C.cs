namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PBT01C
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string JENISFORM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string INV { get; set; }

        [Key]
        [Column(Order = 2)]
        public int NO { get; set; }

        [Required]
        [StringLength(10)]
        public string NOBUK { get; set; }

        [Required]
        [StringLength(30)]
        public string USERNAME { get; set; }

        public DateTime TGLINPUT { get; set; }

        public virtual PBT01A PBT01A { get; set; }
    }
}
