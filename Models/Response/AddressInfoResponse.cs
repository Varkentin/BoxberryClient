using Newtonsoft.Json;

namespace BoxberryClient
{
    public class PVZAddressResponse
    {
        [JsonProperty("WorkShedule")]
        public string WorkSchedule { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string TripDescription { get; set; }
        public int DeliveryPeriod { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string TariffZone { get; set; }
        public string Settlement { get; set; }
        public string Area { get; set; }
        public string Country { get; set; }
        public string OnlyPrepaidOrders { get; set; }
        public string AddressReduce { get; set; }
        public string Acquiring { get; set; }
        public string DigitalSignature { get; set; }
        public string TypeOfOffice { get; set; }
        public string NalKD { get; set; }
        public string Metro { get; set; }
        public string VolumeLimit { get; set; }
        public string LoadLimit { get; set; }
        public string GPS { get; set; }
        public string err { get; set; }
    }
}
