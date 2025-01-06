
using Newtonsoft.Json;

public class PlaylistMylikeRequestModel
{
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("limit")]
    public string Limit { get; set; }
}
