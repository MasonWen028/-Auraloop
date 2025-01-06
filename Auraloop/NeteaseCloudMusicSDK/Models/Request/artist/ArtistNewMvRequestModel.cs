
using Newtonsoft.Json;

public class ArtistNewMvRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("startTimestamp")]
    public long StartTimestamp { get; set; }
}
