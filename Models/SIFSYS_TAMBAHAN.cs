﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("SIFSYS_TAMBAHAN")]
    public class SIFSYS_TAMBAHAN
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecNum { get; set; }

        [StringLength(30)]
        public string PERSON { get; set; }

        [Required]
        [StringLength(50)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(30)]
        public string TELEPON { get; set; }

        [Required]
        [StringLength(7)]
        public string KODEPOS { get; set; }

        [Required]
        [StringLength(4)]
        public string KODEKABKOT { get; set; }

        [Required]
        [StringLength(2)]
        public string KODEPROV { get; set; }

        [StringLength(50)]
        public string NAMA_KABKOT { get; set; }

        [StringLength(50)]
        public string NAMA_PROV { get; set; }

        //add by nurul 9/2/2021
        public string LINK_GAMBAR { get; set; }

        [StringLength(10)]
        public string SIZE_GAMBAR { get; set; }

        [StringLength(1)]
        public string TYPE_LOGO { get; set; }
        //end add by nurul 9/2/2021

        //add by nurul 23/3/2021
        public DateTime? AMBIL_KURIR_SHOPEE { get; set; }
        //end add by nurul 23/3/2021

        //add by nurul 29/3/2021
        public DateTime? CUTOFF_SERAH_TERIMA { get; set; }
        //end add by nurul 29/3/2021

        //ADD BY NURUL 10/1/2022
        [StringLength(1)]
        public string MULTILOKASI { get; set; }
        //END ADD BY NURUL 10/1/2022

        //ADD BY NURUL 21/10/2021
        public string TIPE_PRINT_SHOPEE { get; set; }
        //END ADD BY NURUL 21/10/2021
    }
}