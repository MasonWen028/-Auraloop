
using Newtonsoft.Json;

public class MvFirstRequestModel
{
    [JsonProperty("area")]
    public string Area { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
