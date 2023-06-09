using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MO_Lambda.Models
{
    public class Shopee
    {
    }

    public class ShopeeGetOrderDetail_V2
    {
        public string error { get; set; }
        public string message { get; set; }
        public ShopeeGetOrderDetail_V2Response response { get; set; }
        public string request_id { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Response
    {
        public ShopeeGetOrderDetail_V2Order_List[] order_list { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Order_List
    {
        public string checkout_shipping_carrier { get; set; }
        //public object reverse_shipping_fee { get; set; }
        public int actual_shipping_fee { get; set; }
        public bool actual_shipping_fee_confirmed { get; set; }
        public string buyer_cancel_reason { get; set; }
        //public object buyer_cpf_id { get; set; }
        public long buyer_user_id { get; set; }
        public string buyer_username { get; set; }
        public string cancel_by { get; set; }
        public string cancel_reason { get; set; }
        public bool cod { get; set; }
        public long create_time { get; set; }
        //public object credit_card_number { get; set; }
        public string currency { get; set; }
        public int days_to_ship { get; set; }
        public string dropshipper { get; set; }
        public string dropshipper_phone { get; set; }
        public int estimated_shipping_fee { get; set; }
        public string fulfillment_flag { get; set; }
        public bool goods_to_declare { get; set; }
        //public object invoice_data { get; set; }
        public ShopeeGetOrderDetail_V2Item_List[] item_list { get; set; }
        public string message_to_seller { get; set; }
        public string note { get; set; }
        public long note_update_time { get; set; }
        public string order_sn { get; set; }
        public string order_status { get; set; }
        public ShopeeGetOrderDetail_V2Package_List[] package_list { get; set; }
        public long? pay_time { get; set; }
        public string payment_method { get; set; }
        public long pickup_done_time { get; set; }
        public ShopeeGetOrderDetail_V2Recipient_Address recipient_address { get; set; }
        public string region { get; set; }
        public int reverse_shipping_fee { get; set; }
        public long ship_by_date { get; set; }
        public string shipping_carrier { get; set; }
        public bool split_up { get; set; }
        public int total_amount { get; set; }
        public long update_time { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Recipient_Address
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string town { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string region { get; set; }
        public string zipcode { get; set; }
        public string full_address { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Item_List
    {
        public long item_id { get; set; }
        public string item_name { get; set; }
        public string item_sku { get; set; }
        public long model_id { get; set; }
        public string model_name { get; set; }
        public string model_sku { get; set; }
        public int model_quantity_purchased { get; set; }
        public int model_original_price { get; set; }
        public int model_discounted_price { get; set; }
        public bool wholesale { get; set; }
        public float weight { get; set; }
        public bool add_on_deal { get; set; }
        public bool main_item { get; set; }
        public long add_on_deal_id { get; set; }
        public string promotion_type { get; set; }
        public long promotion_id { get; set; }
        public long order_item_id { get; set; }
        public long promotion_group_id { get; set; }
        public ShopeeGetOrderDetail_V2Image_Info image_info { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Image_Info
    {
        public string image_url { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Package_List
    {
        public string package_number { get; set; }
        public string logistics_status { get; set; }
        public string shipping_carrier { get; set; }
        public ShopeeGetOrderDetail_V2Item_List1[] item_list { get; set; }
    }

    public class ShopeeGetOrderDetail_V2Item_List1
    {
        public long item_id { get; set; }
        public long model_id { get; set; }
    }
    public class ShopeeGetOrderList_V2
    {
        public string error { get; set; }
        public string message { get; set; }
        public ShopeeGetOrderList_V2Response response { get; set; }
        public string request_id { get; set; }
    }
    public class ShopeeGetOrderList_V2Response
    {
        public bool more { get; set; }
        public ShopeeGetOrderList_V2Order_list[] order_list { get; set; }
    }
    public class ShopeeGetOrderList_V2Order_list
    {
        public string order_sn { get; set; }
        public string order_status { get; set; }
    }

}