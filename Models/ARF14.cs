namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ARF14
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Level1 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Level2 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket2 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string Level3 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket3 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string Level4 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket4 { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string Level5 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket5 { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string Level6 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket6 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(10)]
        public string Level7 { get; set; }

        [Required]
        [StringLength(40)]
        public string Ket7 { get; set; }
    }
}
