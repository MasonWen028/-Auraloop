
using Newtonsoft.Json;

public class ArtistFansRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}
