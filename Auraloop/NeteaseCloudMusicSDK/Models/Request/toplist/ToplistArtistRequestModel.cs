
using Newtonsoft.Json;

public class ToplistArtistRequestModel
{
    [JsonProperty("type")]
    public int Type { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    const bool Total = true;
}
