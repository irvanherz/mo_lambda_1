namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TEMP_BAYAR_MP
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RECNUM { get; set; }

        public string CUST { get; set; }
        public string BUKTI { get; set; }
        public string NOREF { get; set; }
        public DateTime TGL { get; set; }
        public string NOTE { get; set; }
        public double NILAI { get; set; }
        public string KET1 { get; set; }
        public string KET2 { get; set; }
        public string KET3 { get; set; }
        public DateTime TGLINPUT { get; set; }
        public string USERNAME { get; set; }

    }
}
