
using Newtonsoft.Json;

public class SongLikeCheckRequestModel
{
    [JsonProperty("trackIds")]
    public string TrackIds { get; set; }
}
