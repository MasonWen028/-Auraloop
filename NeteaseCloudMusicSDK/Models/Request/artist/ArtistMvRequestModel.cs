
using Newtonsoft.Json;

public class ArtistMvRequestModel
{
    [JsonProperty("artistId")]
    public long ArtistId { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
