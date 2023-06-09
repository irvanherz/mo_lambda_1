using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("KabupatenKota")]
    public class KabupatenKota
    {
        [Key]
        [Required]
        [MaxLength(4)]
        public String KodeKabKot { get; set; }

        [Required]
        [MaxLength(2)]
        public String KodeProv { get; set; }

        [Required]
        [MaxLength(50)]
        public String NamaKabKot { get; set; }

        [NotMapped]
        public virtual Provinsi Provinsi { get; set; }
    }
}