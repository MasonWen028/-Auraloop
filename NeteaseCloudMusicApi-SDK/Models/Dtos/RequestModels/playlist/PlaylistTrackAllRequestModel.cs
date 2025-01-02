
using Newtonsoft.Json;

public class PlaylistTrackAllRequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("n")]
    public int N { get; set; }
    [JsonProperty("s")]
    public int S { get; set; }
}
