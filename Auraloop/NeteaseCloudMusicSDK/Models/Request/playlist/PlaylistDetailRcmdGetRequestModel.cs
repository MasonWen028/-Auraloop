
using Newtonsoft.Json;

public class PlaylistDetailRcmdGetRequestModel
{
    [JsonProperty("scene")]
    public string Scene { get; set; }
    [JsonProperty("playlistId")]
    public string PlaylistId { get; set; }
    [JsonProperty("newStyle")]
    public string NewStyle { get; set; }
}
