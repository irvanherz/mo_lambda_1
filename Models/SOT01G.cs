using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SOT01G
    {
        [StringLength(15)]
        public string NO_BUKTI { get; set; }

        [StringLength(20)]
        public string BRG { get; set; }
        
        public double? QTY { get; set; }
        
        public double? HARGA { get; set; }

        [StringLength(20)]
        public string USERNAME { get; set; }
        
        public DateTime? TGL_EDIT { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RECNUM { get; set; }

        //ADD BY NURUL 27/7/2021
        [StringLength(70)]
        public string NOREF { get; set; }
        [StringLength(10)]
        public string CUST { get; set; }
        //END ADD BY NURUL 27/7/2021
    }
}
