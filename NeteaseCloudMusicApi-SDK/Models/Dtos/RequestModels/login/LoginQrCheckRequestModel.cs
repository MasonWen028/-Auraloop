
using Newtonsoft.Json;

public class LoginQrCheckRequestModel
{
    [JsonProperty("key")]
    public string Key { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
