namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ART04C
    {
        [StringLength(10)]
        public string NOBUK { get; set; }

        [StringLength(15)]
        public string REK { get; set; }

        [Key]
        public int NO_URUT { get; set; }

        [StringLength(40)]
        public string URAIAN { get; set; }

        [StringLength(1)]
        public string DK { get; set; }

        public double NILAI { get; set; }

        [StringLength(10)]
        public string DEPT { get; set; }

        [StringLength(10)]
        public string COST { get; set; }

        [StringLength(5)]
        public string VLT { get; set; }

        public double TUKAR { get; set; }

        [StringLength(15)]
        public string REK_LAWAN { get; set; }
    }
}
