namespace BoxberryClient
{
    public class CourierAddressResponse
    {
        public string City { get; set; }
        public string Region { get; set; }
        public string Area { get; set; }
        public string DeliveryPeriod { get; set; }

        public override bool Equals(object obj)
        {
            var model = obj as CourierAddressResponse;
            return model != null && City == model.City;
        }

        public override int GetHashCode()
        {
            return -222019662 + EqualityComparer<string>.Default.GetHashCode(City);
        }

        public string err { get; set; }
    }
}
