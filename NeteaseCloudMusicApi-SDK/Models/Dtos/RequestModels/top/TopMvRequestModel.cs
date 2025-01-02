
using Newtonsoft.Json;

public class TopMvRequestModel
{
    [JsonProperty("area")]
    public string Area { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
