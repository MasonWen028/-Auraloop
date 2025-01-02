
using Newtonsoft.Json;

public class SongOrderUpdateRequestModel
{
    [JsonProperty("pid")]
    public string Pid { get; set; }
    [JsonProperty("trackIds")]
    public string TrackIds { get; set; }
    [JsonProperty("op")]
    public string Op { get; set; }
}
