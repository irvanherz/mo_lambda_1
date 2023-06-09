using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [JsonObject(IsReference = true)]
    public partial class STT01A
    {
        public STT01A()
        {
        }

        [Key]
        [Column(Order = 0)]
        public byte Jenis_Form { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string Nobuk { get; set; }

        public DateTime? Tgl { get; set; }

        [StringLength(1)]
        public string Satuan { get; set; }

        [StringLength(256)]
        public string Ket { get; set; }

        [StringLength(1)]
        public string ST_Cetak { get; set; }

        [StringLength(1)]
        public string ST_Posting { get; set; }

        [StringLength(2)]
        public string JTran { get; set; }

        [StringLength(1)]
        public string MK { get; set; }

        [StringLength(1)]
        public string JRef { get; set; }

        [StringLength(10)]
        public string Ref { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        public DateTime? TglInput { get; set; }

        public bool Retur_Penuh { get; set; }

        public bool Terima_Penuh { get; set; }

        [StringLength(3)]
        public string VALUTA { get; set; }

        public double TUKAR { get; set; }

        public DateTime? TGL_TERIMA_CUST { get; set; }

        public DateTime? TGL_RETUR { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ID { get; set; }

        [StringLength(15)]
        public string WORK_CENTER { get; set; }

        [StringLength(1)]
        public string STATUS_LOADING { get; set; }

        public bool TERIMA_PENUH_PO_QC { get; set; }

        [StringLength(5)]
        public string KLINE { get; set; }

        public double JLH_KARYAWAN { get; set; }

        [StringLength(5)]
        public string KODE_ANGKUTAN { get; set; }

        [StringLength(2)]
        public string JENIS_MOBIL { get; set; }

        [StringLength(10)]
        public string NO_POLISI { get; set; }

        public double NILAI_ANGKUTAN { get; set; }

        [StringLength(20)]
        public string NAMA_SOPIR { get; set; }

        public double KOLI { get; set; }

        public double BERAT { get; set; }

        public double VOLUME { get; set; }

        public double? JAM { get; set; }

        [StringLength(20)]
        public string No_PP { get; set; }

        public double? Kurs { get; set; }

        [StringLength(40)]
        public string CATATAN_1 { get; set; }

        [StringLength(40)]
        public string CATATAN_2 { get; set; }

        [StringLength(40)]
        public string CATATAN_3 { get; set; }

        [StringLength(40)]
        public string CATATAN_4 { get; set; }

        [StringLength(40)]
        public string CATATAN_5 { get; set; }

        [StringLength(40)]
        public string CATATAN_6 { get; set; }

        [StringLength(40)]
        public string CATATAN_7 { get; set; }

        [StringLength(40)]
        public string CATATAN_8 { get; set; }

        [StringLength(40)]
        public string CATATAN_9 { get; set; }

        [StringLength(40)]
        public string CATATAN_10 { get; set; }

        [StringLength(20)]
        public string NOBUK_POQC { get; set; }

        [StringLength(10)]
        public string Supp { get; set; }

        [StringLength(100)]
        public string NAMA_SUPP { get; set; }

        [StringLength(10)]
        public string NO_PL { get; set; }

        [StringLength(10)]
        public string NO_FAKTUR { get; set; }

        public DateTime? TGL_STPD { get; set; }

    }
}
