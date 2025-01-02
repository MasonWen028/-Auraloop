
using Newtonsoft.Json;

public class ArtistMvRequestModel
{
    [JsonProperty("artistId")]
    public string ArtistId { get; set; }
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
