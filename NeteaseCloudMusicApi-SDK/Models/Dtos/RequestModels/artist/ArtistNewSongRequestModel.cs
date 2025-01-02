
using Newtonsoft.Json;

public class ArtistNewSongRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("startTimestamp")]
    public long StartTimestamp { get; set; }
}
