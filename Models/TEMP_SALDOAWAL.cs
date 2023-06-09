using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MO_Lambda.Models
{
    [Table("TEMP_SALDOAWAL")]
    public class TEMP_SALDOAWAL
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecNum { get; set; }

        [StringLength(40)]
        public string BRG { get; set; }

        public double QTY { get; set; }

        public double HARGA_SATUAN { get; set; }

    }

}