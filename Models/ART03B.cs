using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ART03B
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string BUKTI { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int? NO { get; set; }

        [StringLength(10)]
        public string NFAKTUR { get; set; }

        public double SISA { get; set; }

        public double BAYAR { get; set; }

        public double POT { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }


        //ADD BY NURUL 21/10/2019
        [StringLength(100)]
        public string NOREF { get; set; }

        public DateTime? TGL_REF { get; set; }
        //END ADD BY NURUL 21/10/2019

        //add by nurul 12/3/2020
        public double? LEBIH_BAYAR { get; set; }
        //end add by nurul 12/3/2020
    }
}
