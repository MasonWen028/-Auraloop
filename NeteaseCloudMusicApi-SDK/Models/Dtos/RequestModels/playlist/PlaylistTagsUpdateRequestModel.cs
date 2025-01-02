
using Newtonsoft.Json;

public class PlaylistTagsUpdateRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("tags")]
    public string Tags { get; set; }
}
