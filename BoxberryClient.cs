
using Newtonsoft.Json.Linq;

namespace BoxberryClient
{
    public class BoxberryClient : IBoxberryClient
    {
        private const string _testToken = "d6f33e419c16131e5325cbd84d5d6000";
        private const string _endpoint = "https://api.boxberry.ru/json.php";


        private readonly HttpClient _client;
        public BoxberryClient()
        {
            _client = new HttpClient();
        }

        public CancelOrderResponse CancelOrder(Settings settings, string trackingNumber, out string error)
            => GetResponse<CancelOrderResponse>(CreateRequest(settings, "method=ParselDel&ImId=" + trackingNumber), out error);

        public List<PVZAddressResponse> GetListPoints(Settings settings, string contryCode, out string error)
            => GetResponse<List<PVZAddressResponse>>(CreateRequest(settings, $"method=ListPoints&prepaid=1{contryCode}"), out error);

        public List<CourierAddressResponse> GetCourierListCities(Settings settings, out string error)
            => GetResponse<List<CourierAddressResponse>>(CreateRequest(settings, "method=CourierListCities"), out error);

        public StatusResponse ListStatusesFull(Settings settings, string trackingNumber, out string error)
            => GetResponse<StatusResponse>(CreateRequest(settings, "method=ListStatusesFull&ImId=" + trackingNumber), out error);

        public ZipChekResponse ZipCheck(Settings settings, string zip, out string error)
            => GetResponse<ZipChekResponse>(CreateRequest(settings, "method=ZipCheck&Zip=" + zip), out error);

        public OrderResponse ParselCreate(ShippingInfo shippingInfo, Settings settings, out string error)
            => GetResponse<OrderResponse>(new HttpRequestMessage
            {
                RequestUri = new Uri(_endpoint),
                Method = HttpMethod.Post,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "token", settings.IsTestMode? _testToken : settings.Token },
                    { "method", "ParselCreate" },
                    { "sdata", shippingInfo.ToJSON() }
                })
            }
            , out error);

        public Stream GetDocument(Settings boxberrySettings, string trackingNumber)
        {
            try
            {
                var requestMessage = CreateRequest(boxberrySettings, "method=ParselCheck&ImId=" + trackingNumber);
                var response = _client.Send(requestMessage);
                var result = response.Content.ReadAsStringAsync().Result;
                var urlDocument = (JObject.Parse(result))["label"]?.Value<string>() ?? string.Empty;

                if (urlDocument.IsEmpty()) return default;

                response = _client.GetAsync(urlDocument).Result;
                return response.Content.ReadAsStreamAsync().Result;
            }
            catch
            {
                return default;
            }
        }

        private HttpRequestMessage CreateRequest(Settings settings, string queryParams)
            => new(HttpMethod.Get, $"{_endpoint}?token={(settings.IsTestMode ? _testToken : settings.Token)}&{queryParams}");

        private TResponse GetResponse<TResponse>(HttpRequestMessage request, out string error)
        {
            error = null;
            try
            {
                var response = _client.Send(request);
                var result = response.Content.ReadAsStringAsync().Result;
                if (response?.IsSuccessStatusCode != true)
                {
                    error = result;
                    return default;
                }

                return result.Deserialize<TResponse>();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return default;
            }
        }
    }
}