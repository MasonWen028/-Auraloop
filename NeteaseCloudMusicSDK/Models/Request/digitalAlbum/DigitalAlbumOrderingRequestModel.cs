
using Newtonsoft.Json;

public class DigitalAlbumOrderingRequestModel
{
    [JsonProperty("business")]
    public string Business { get; set; }
    [JsonProperty("paymentMethod")]
    public string PaymentMethod { get; set; }
    [JsonProperty("digitalResources")]
    public string DigitalResources { get; set; }
    [JsonProperty("resourceID")]
    public string ResourceID { get; set; }
    [JsonProperty("quantity")]
    public string Quantity { get; set; }
}
