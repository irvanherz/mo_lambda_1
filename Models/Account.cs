using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("Account")]
    public class Account
    {
        public Int64 AccountId { get; set; }

        public String UserId { get; set; }

        public string VCode { get; set; }

        public String Email { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        //public String ConfirmPassword { get; set; }

        public String NoHp { get; set; }

        public String DatabasePathMo { get; set; }

        public String PhotoKtpUrl { get; set; }

        //public String ImageFile { get; set; }

        public String NamaTokoOnline { get; set; }

        public String DatabasePathErasoft { get; set; }

        public Boolean Status { get; set; }

        public string KODE_SUBSCRIPTION { get; set; }

        public DateTime? TGL_SUBSCRIPTION { get; set; }

        public string PhotoKtpBase64 { get; set; }

        public string TOKEN_CC { get; set; }

        public string KODE_REFERRAL { get; set; }
        
        public DateTime? TGL_DAFTAR { get; set; }

        public int? jumlahUser { get; set; }

        //add by nurul 12/3/2019
        public DateTime? tgl_approve { get; set; }
        //end add by nurul 12/3/2019

        //add by Iman 15/04/2019
        public DateTime? tgl_email1 { get; set; }       

        //add by Iman 15/04/2019
        public DateTime? tgl_email2 { get; set; }
        //end add by Iman 15/04/2019

        public DateTime? LAST_LOGIN_DATE { get; set; }

        public string DataSourcePath { get; set; }

        public string DataSourcePathDebug { get; set; }

        public string confirm_broadcast { get; set; }

        public string TOKEN { get; set; }
        public DateTime? TOKEN_EXPIREDDATE { get; set; }
        public string IP_ADDRESS_WL { get; set; }

        public string DatabaseId { get; set; }
        public string PartnerAddress { get; set; }
        public string PartnerAddressBatal { get; set; }

        public Boolean? Status_Webhook { get; set; }
        public string IP_ADDRESS_WL_2 { get; set; }
        public string IP_ADDRESS_WL_3 { get; set; }

    }
}