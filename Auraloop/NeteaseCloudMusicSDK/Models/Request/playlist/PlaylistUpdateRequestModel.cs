
using Newtonsoft.Json;

public class PlaylistUpdateRequestModel
{
    [JsonProperty("api")]
    public string Api { get; set; }
    [JsonProperty("playlist")]
    public string Playlist { get; set; }
    [JsonProperty("desc")]
    public string Desc { get; set; }
    [JsonProperty("update")]
    public long Update { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("query")]
    public string Query { get; set; }
}
