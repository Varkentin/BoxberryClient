using System.Collections.Generic;

namespace BoxberryClient
{
    public class ShippingInfo
    {
        public string updateByTrack { get; set; }
        public string order_id { get; set; }
        public string PalletNumber { get; set; }
        public string barcode { get; set; } // если менять этот параметр самим, то выгрузить документы будет нельзя
        public decimal price { get; set; }
        public decimal payment_sum { get; set; }
        public decimal delivery_sum { get; set; }
        public int vid { get; set; } // 1 (самовывоз) или 2 (курьер)
        public BoxberryShopInfo shop { get; set; }
        public CustomerInfo customer { get; set; }
        public BoxberryCourierInfo kurdost { get; set; }
        public IEnumerable<ItemInfo> items { get; set; }
        public BoxberryItemWeight weights { get; set; }
    }

    public class BoxberryShopInfo
    {
        public string name { get; set; }
        public string name1 { get; set; }
    }

    public class BoxberryCourierInfo
    {
        public string index { get; set; }
        public string citi { get; set; }
        public string addressp { get; set; }
        public string timesfrom1 { get; set; }
        public string timesto1 { get; set; }
        public string timesfrom2 { get; set; }
        public string timesto2 { get; set; }
        public string timep { get; set; }
        public string comentk { get; set; }
    }
}
