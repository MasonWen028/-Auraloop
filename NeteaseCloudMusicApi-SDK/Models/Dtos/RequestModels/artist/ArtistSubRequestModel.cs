
using Newtonsoft.Json;

public class ArtistSubRequestModel
{
    [JsonProperty("artistId")]
    public string ArtistId { get; set; }
    [JsonProperty("artistIds")]
    public string ArtistIds { get; set; }
}
