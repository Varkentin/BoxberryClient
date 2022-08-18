namespace BoxberryClient
{
    public interface IBoxberryClient
    {
        OrderResponse ParselCreate(ShippingInfo shippingInfo, Settings settings, out string error);
        CancelOrderResponse CancelOrder(Settings settings, string trackingNumber, out string error);
        List<PVZAddressResponse> GetListPoints(Settings settings, string contryCode, out string error);
        List<CourierAddressResponse> GetCourierListCities(Settings settings, out string error);
        ZipChekResponse ZipCheck(Settings settings, string zip, out string error);
        StatusResponse ListStatusesFull(Settings settings, string trackingNumber,  out string error);
        Stream GetDocument(Settings boxberrySettings, string trackingNumber);
    }
}