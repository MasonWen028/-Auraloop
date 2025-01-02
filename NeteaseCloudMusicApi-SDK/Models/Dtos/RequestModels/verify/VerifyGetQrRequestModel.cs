
using Newtonsoft.Json;

public class VerifyGetQrRequestModel
{
    [JsonProperty("verifyConfigId")]
    public string VerifyConfigId { get; set; }
    [JsonProperty("verifyType")]
    public string VerifyType { get; set; }
    [JsonProperty("token")]
    public string Token { get; set; }
    [JsonProperty("params")]
    public string Params { get; set; }
    [JsonProperty("sign")]
    public string Sign { get; set; }
}
