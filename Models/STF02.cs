using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STF02
    {
        public STF02()
        {
        }

        [Key]
        [StringLength(20)]
        public string BRG { get; set; }

        [Required]
        [StringLength(30)]
        public string NAMA { get; set; }

        [StringLength(255)]
        public string NAMA2 { get; set; }

        [StringLength(30)]
        public string NAMA3 { get; set; }

        [StringLength(10)]
        public string JENIS { get; set; }

        [Required]
        [StringLength(5)]
        public string STN { get; set; }

        public double HBELI { get; set; }

        public double MAXI { get; set; }

        public double MINI { get; set; }

        [Required]
        [StringLength(5)]
        public string STN2 { get; set; }

        public double ISI { get; set; }

        public double HPP { get; set; }

        public double HBESAR { get; set; }

        public double HKECIL { get; set; }

        [StringLength(1)]
        public string MVC { get; set; }

        [StringLength(10)]
        public string LKS { get; set; }

        [StringLength(10)]
        public string SUP { get; set; }

        [StringLength(10)]
        public string MEREK { get; set; }

        [StringLength(20)]
        public string PART { get; set; }

        [StringLength(1)]
        public string TYPE { get; set; }

        [StringLength(15)]
        public string KLINK { get; set; }

        public double HP_STD { get; set; }

        public double QPROD { get; set; }

        public DateTime? Tgl_Input { get; set; }

        public DateTime? TGL_KLR { get; set; }

        [StringLength(15)]
        public string WARNA { get; set; }

        public short LT { get; set; }

        public short OC { get; set; }

        [Required]
        [StringLength(10)]
        public string Sort1 { get; set; }

        [Required]
        [StringLength(10)]
        public string Sort2 { get; set; }

        [StringLength(10)]
        public string Sort3 { get; set; }

        [StringLength(10)]
        public string Sort4 { get; set; }

        [StringLength(10)]
        public string Sort5 { get; set; }

        [StringLength(1)]
        public string Stn_berat { get; set; }

        [StringLength(1)]
        public string Metoda { get; set; }

        [StringLength(1)]
        public string Qty_berat { get; set; }

        public double QSALES { get; set; }

        [StringLength(40)]
        public string KET_SORT1 { get; set; }

        [StringLength(40)]
        public string KET_SORT2 { get; set; }

        [StringLength(40)]
        public string KET_SORT3 { get; set; }

        [StringLength(40)]
        public string KET_SORT4 { get; set; }

        [StringLength(40)]
        public string KET_SORT5 { get; set; }

        [StringLength(5)]
        public string STN3 { get; set; }

        [StringLength(5)]
        public string STN4 { get; set; }

        [StringLength(20)]
        public string KET_STN2 { get; set; }

        [StringLength(20)]
        public string KET_STN3 { get; set; }

        [StringLength(20)]
        public string KET_STN4 { get; set; }

        public double ISI3 { get; set; }

        public double ISI4 { get; set; }

        [StringLength(20)]
        public string KET_STN { get; set; }

        public double TOLERANSI { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [StringLength(10)]
        public string Sort6 { get; set; }

        [StringLength(10)]
        public string Sort7 { get; set; }

        [StringLength(10)]
        public string Sort8 { get; set; }

        [StringLength(10)]
        public string Sort9 { get; set; }

        [StringLength(10)]
        public string Sort10 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        public double H_STN_3 { get; set; }

        public double H_STN_4 { get; set; }

        public double SS { get; set; }

        public bool METODA_HPP_PER_SN { get; set; }

        [StringLength(40)]
        public string Ket_Sort6 { get; set; }

        [StringLength(40)]
        public string Ket_Sort7 { get; set; }

        [StringLength(40)]
        public string Ket_Sort8 { get; set; }

        [StringLength(40)]
        public string Ket_Sort9 { get; set; }

        [StringLength(40)]
        public string Ket_Sort10 { get; set; }

        public bool GENERIC { get; set; }

        public bool FORMULARIUM { get; set; }

        public bool ANTIBIOTIK { get; set; }

        public bool NARKOTIK { get; set; }

        public bool PSIKOTROPIK { get; set; }

        public double HNA_PPN { get; set; }

        public double LABA { get; set; }

        [StringLength(30)]
        public string USERNAME { get; set; }

        [StringLength(1)]
        public string BSK { get; set; }

        public double KUBILASI { get; set; }

        public int? DEFAULT_STN_JUAL { get; set; }

        public int? DEFAULT_STN_HRG_JUAL { get; set; }

        [StringLength(20)]
        public string BRG_NON_OS { get; set; }

        [Column(TypeName = "text")]
        public string PHOTO2 { get; set; }

        public double BERAT { get; set; }

        public double HJUAL { get; set; }
        
        [Required]
        public string Deskripsi { get; set; }

        public double PANJANG { get; set; }

        public double LEBAR { get; set; }

        public double TINGGI { get; set; }

        public bool DISPLAY_MARKET { get; set; }

        public string LINK_GAMBAR_1 { get; set; }

        public string LINK_GAMBAR_2 { get; set; }

        public string LINK_GAMBAR_3 { get; set; }

        public string LINK_GAMBAR_4 { get; set; }

        public string LINK_GAMBAR_5 { get; set; }

        public string SIZE_GAMBAR_4 { get; set; }

        public string SIZE_GAMBAR_5 { get; set; }

        [StringLength(50)]
        public string BRG_SAP { get; set; }

        //ADD BY NURUL 7/7/2021
        public DateTime? TGL_DELETE { get; set; }
        //END ADD BY NURUL 7/7/2021

    }
}
