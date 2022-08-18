namespace BoxberryClient
{
    public class Settings
    {

        public string Token { get; set; }
        public bool IsTestMode { get; set; }

        /// <summary>
        /// Код точки куда продавец привезет заказ для отправки
        /// </summary>
        public string SendPlaceCode { get; set; }

    }
}
