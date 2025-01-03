
using Newtonsoft.Json;

public class ArtistSubRequestModel
{
    [JsonProperty("artistId")]
    public long ArtistId { get; set; }
    [JsonProperty("artistIds")]
    public long[] ArtistIds { get; set; }
}
