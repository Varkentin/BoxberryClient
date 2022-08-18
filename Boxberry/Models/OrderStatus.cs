namespace BoxberryClient
{
    public class StatusResponse
    {
        public List<BoxberryStatus> statuses { get; set; }
        public bool PD { get; set; }
        public decimal sum { get; set; }
        public double Weight { get; set; }
        public string PaymentMethod { get; set; }
        public string err { get; set; }

        public class BoxberryStatus
        {
            public string Date { get; set; }
            public string Name { get; set; }
            public string Comment { get; set; }
        }
    }
}
