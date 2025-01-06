
using Newtonsoft.Json;

public class PlaylistNameUpdateRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
