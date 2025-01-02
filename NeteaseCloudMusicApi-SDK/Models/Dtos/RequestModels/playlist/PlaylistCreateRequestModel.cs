
using Newtonsoft.Json;

public class PlaylistCreateRequestModel
{
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("privacy")]
    public string Privacy { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
}
