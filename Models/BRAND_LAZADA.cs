﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    [Table("BRAND_LAZADA")]
    public class BRAND_LAZADA
    {
        [Key]
        public string brand_id { get; set; }
        public string name { get; set; }
        public string global_identifier { get; set; }
        public string name_en { get; set; }
    }
    public class BRAND_BLIBLI
    {
        public string brand_id { get; set; }
        public string name { get; set; }
    }
    public class TiktokBrand
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    //add by fauzi for 82Cart
    public class BRAND_82CART
    {
        public string id_manufacturer { get; set; }
        public string name { get; set; }
        public string active { get; set; }
    }

    public class ATTRIBUTE_82CART_LIST
    {
        public string id_attribute { get; set; }
        public string color_attribute { get; set; }
        public string attribute_name { get; set; }
    }
    //end add

    public class BRAND_SHOPEE
    {
        public string brand_id { get; set; }
        public string name { get; set; }
    }
}