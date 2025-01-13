
using Newtonsoft.Json;

public class VerifyQrcodestatusRequestModel
{
    [JsonProperty("qrCode")]
    public string QrCode { get; set; }
}
