namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEMP_SIT01D
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string JENIS_FORM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string NO_BUKTI { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NO_URUT_UNIT { get; set; }

        [Key]
        [Column(Order = 3)]
        public int NO_URUT { get; set; }

        [StringLength(20)]
        public string KODE_BRG_UNIT { get; set; }

        [StringLength(20)]
        public string KODE_BRG { get; set; }

        [Key]
        [Column(Order = 4)]
        public double QTY { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool KONFIG_STANDART { get; set; }

        [StringLength(1)]
        public string SATUAN { get; set; }

        [StringLength(4)]
        public string GD { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime TGLINPUT { get; set; }

        [StringLength(20)]
        public string USERNAME { get; set; }
    }
}
