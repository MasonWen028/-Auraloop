
using Newtonsoft.Json;

public class PlaylistTrackDeleteRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("tracks")]
    public string Tracks { get; set; }
    [JsonProperty("map")]
    public string Map { get; set; }
    [JsonProperty("item")]
    public string Item { get; set; }
    [JsonProperty("return")]
    public string Return { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
