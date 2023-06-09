namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEMP_SIT01F
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string JENIS_FORM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string NO_BUKTI { get; set; }

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
    }
}
