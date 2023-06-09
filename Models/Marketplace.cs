using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("Marketplace")]
    public class Marketplace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int32? IdMarket { get; set; }

        [MaxLength(50)]
        [Required]
        [DisplayName("Nama Marketplace")]
        public String NamaMarket { get; set; }

        [MaxLength(100)]
        [Display(Name = "Logo")]
        public String LokasiLogo { get; set; }

        [NotMapped]
        public String ImageFile { get; set; }

        public Boolean Status { get; set; }
    }
}