using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models.Api
{
    public class JsonData
    {
        public string UserId { get; set; }
        public string Email { get; set; }
        public string SelDate { get; set; }
        public string StatusTransaksi { get; set; }
        public int? RecNumPesanan { get; set; }
        public string PassLama { get; set; }
        public string PassBaru { get; set; }
        public string SearchParam { get; set; }
        public int SortBy { get; set; }
        public string DbPath { get; set; }
        public long AccId { get; set; }
        public string Username { get; set; }
        
        // Add by Fauzi for API Update Stok perbarang 26 November 2020
        public string brg { get; set; }
        public string no_bukti { get; set; }
        public string status_pesanan { get; set; }
        // End 26 November 2020

        //add by nurul 19/11/2021
        public List<string> listBrg { get; set; }
        //end add by nurul 19/11/2021
    }
    public class JsonDataUpdatePrice
    {
        public int recnumBrg { get; set; }
        public double hjualBaru { get; set; }
        public double hjualPromoBaru { get; set; }
        public int blibli { get; set; }

    }

    public class JsonDataProcessOrder
    {
        public string no_bukti { get; set; }
        public string request_action { get; set; }
        public string no_bukti_pl { get; set; }
        public string alamat { get; set; }
        public string kurir { get; set; }
        public string typeshipment { get; set; }
        public List<string> rows_data { get; set; }
    }

    public class JsonDataPrintLabel
    {
        public string no_bukti { get; set; }
        public string no_bukti_pl { get; set; }
        [DefaultValue("3")]
        public string jenis_label { get; set; }
        public List<string> rows_data { get; set; }
    }

    public class JsonData_StokOP
    {
        public string batch { get; set; }
        public string noStok { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public bool isAccurate { get; set; }
        public string DatabasePathErasoft { get; set; }
        public string dbSourceEra { get; set; }
    }

    public class JsonDealpos
    {
        public string invoiceId { get; set; }
        public string source { get; set; }
        public string cust { get; set; }
        public string dbpathera { get; set; }
    }
}