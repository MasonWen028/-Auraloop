
using Newtonsoft.Json;

public class ArtistListRequestModel
{
    [JsonProperty("initial")]
    public string Initial { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("area")]
    public string Area { get; set; }
}
