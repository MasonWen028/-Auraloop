
using Newtonsoft.Json;

public class UserEventRequestModel
{
    [JsonProperty("getcounts")]
    public int Getcounts { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
