using Newtonsoft.Json;

namespace MO_Lambda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class TEMP_SHOPEE_ORDERS_ITEM
    {
        //[Key, Column(Order = 0)]
        public string ordersn { get; set; }
        public float weight { get; set; }
        public string item_name { get; set; }
        public bool is_wholesale { get; set; }
        public string item_sku { get; set; }
        public string variation_discounted_price { get; set; }
        //[Key, Column(Order = 2)]
        public long variation_id { get; set; }
        public string variation_name { get; set; }
        //[Key, Column(Order = 1)]
        public long item_id { get; set; }
        public int variation_quantity_purchased { get; set; }
        public string variation_sku { get; set; }
        public string variation_original_price { get; set; }
        public DateTime pay_time { get; set; }
        public string CUST { get; set; }
        public string NAMA_CUST { get; set; }
        public string CONN_ID { get; set; }
        public double DISC { get; set; }
        public double N_DISC { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? RecNum { get; set; }
    }

}
