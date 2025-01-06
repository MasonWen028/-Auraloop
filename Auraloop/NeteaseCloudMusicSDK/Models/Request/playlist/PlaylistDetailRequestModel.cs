
using Newtonsoft.Json;

public class PlaylistDetailRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("s")]
    public int S { get; set; } = 0;
}
