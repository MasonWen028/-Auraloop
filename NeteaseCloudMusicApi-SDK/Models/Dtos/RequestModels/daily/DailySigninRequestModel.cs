
using Newtonsoft.Json;

public class DailySigninRequestModel
{
    [JsonProperty("type")]
    public int Type { get; set; }
}
