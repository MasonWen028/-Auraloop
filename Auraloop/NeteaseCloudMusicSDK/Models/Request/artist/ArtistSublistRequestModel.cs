
using Newtonsoft.Json;

public class ArtistSublistRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 25;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
