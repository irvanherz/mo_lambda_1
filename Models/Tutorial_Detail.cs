using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace MO_Lambda.Models
{
    [Table("Tutorial_Detail")]
    public class Tutorial_Detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? DetailId { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Judul { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        
        public string Konten { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}