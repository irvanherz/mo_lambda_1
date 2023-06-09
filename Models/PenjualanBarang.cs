﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class PenjualanBarang
    {
        public string KodeBrg { get; set; }
        public string NamaBrg { get; set; }
        public string Kategori { get; set; }
        public string Merk { get; set; }
        public double HJual { get; set; }
        public double Qty { get; set; }
        public bool Laku { get; set; }
        public List<QOH_QOO_ALL_ITEM> Stok { get; set; }
        public double Min { get; set; }
        public double Qoh { get; set; }
        public double Qoo { get; set; }
        //add by nurul 12/4/2019
        public double QtySales { get; set; }

        //add by nurul 23/9/2019
        public double Selisih { get; set; }
        //end add by nurul 23/9/2019
    }
}