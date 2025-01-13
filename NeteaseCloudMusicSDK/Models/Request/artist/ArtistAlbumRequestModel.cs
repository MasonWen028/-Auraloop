
using Newtonsoft.Json;

public class ArtistAlbumRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
    [JsonIgnore]
    public long ArtistId { get; set; }

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
//long artistId, int limit = 50, int offset = 0