
using Newtonsoft.Json;

public class DjSubscriberRequestModel
{
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
}
