using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [JsonObject(IsReference = true)]
    public partial class STT04A
    {

        public STT04A()
        {
        }
        
        [Key]
        [Column(Order = 0)]
        public string GUD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string NOBUK { get; set; }

        [StringLength(30)]
        public string NAMA_GUDANG { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        [StringLength(1)]
        public string POSTING { get; set; }

        public DateTime? TGL { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [StringLength(100)]
        public string PROSES { get; set; }


    }
}
