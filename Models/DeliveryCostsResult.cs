namespace BoxberryClient
{
    public class DeliveryCostsResult
    {
        public decimal  price { get; set; }
        public decimal price_base { get; set; }
        public decimal price_service { get; set; }
        public int delivery_period { get; set; }
    }
}
