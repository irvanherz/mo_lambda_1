﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class InfoPesanan
    {
        public string NoPesanan { get; set; }
        public string TglPesanan { get; set; }
        public string Marketplace { get; set; }
        public string Pembeli { get; set; }
        public string Total { get; set; }
        public int allowContinue { get; set; }
        public string ID_MARKETPLACE { get; set; }
        public List<string> listBrg { get; set; }
    }
}