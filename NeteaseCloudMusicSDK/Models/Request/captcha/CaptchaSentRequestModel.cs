
using Newtonsoft.Json;

public class CaptchaSentRequestModel
{
    [JsonProperty("ctcode")]
    public string Ctcode { get; set; }
    [JsonProperty("cellphone")]
    public string Cellphone { get; set; }
}
