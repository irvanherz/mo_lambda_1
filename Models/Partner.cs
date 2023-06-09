﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("Partner")]
    public class Partner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 PartnerId { get; set; }

        [MaxLength(50)]
        [Required]
        [EmailAddress(ErrorMessage = "Masukkan email yang valid!")]
        public String Email { get; set; }

        [MaxLength(30)]
        [Required]
        [DisplayName("Nama Lengkap")]
        public String Username { get; set; }

        [MaxLength(30)]
        [Required]
        [DisplayName("No. HP")]
        public String NoHp { get; set; }

        [MaxLength(255)]
        public String PhotoKtpUrl { get; set; }

        [NotMapped]
        public String ImageFile { get; set; }

        public Boolean Status { get; set; }

        public Boolean StatusSetuju { get; set; }

        public string PhotoKtpBase64 { get; set; }

        [Required]
        public int TipePartner { get; set; }

        [Required]
        public string NamaTipe { get; set; }

        [StringLength(50)]
        public string KodeRefPilihan { get; set; }

        //add by nurul 15/2/2019
        public double komisi_support { get; set; }

        public double komisi_subscribe { get; set; }

        public double komisi_subscribe_gold { get; set; }
        //end add by nurul 15/2/2019
        public DateTime? TGL_DAFTAR { get; set; }
    }
}