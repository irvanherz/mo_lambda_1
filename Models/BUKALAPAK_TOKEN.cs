﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("BUKALAPAK_TOKEN")]
    public class BUKALAPAK_TOKEN
    {

        [Key]
        [Column(Order = 0)]
        public string ACCOUNT { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CUST { get; set; }
        //public string TOKEN { get; set; }
        //public long EXPIRED { get; set; }
        //public string REFRESH_TOKEN { get; set; }
        public DateTime CREATED_AT { get; set; }
        //public string TOKEN_TYPE { get; set; }
        //public DateTime REQUEST_DATE { get; set; }
        public string CODE { get; set; }
        public string EMAIL { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RECNUM { get; set; }
        public string VAR_1 { get; set; }
        public string VAR_2 { get; set; }
    }
    [Table("TABEL_AWS")]
    public class TABEL_AWS
    {

        [Key]
        public string AWSKEY { get; set; }

        public string AWSSECRET { get; set; }
        public DateTime TGL { get; set; }
    }
}