
using Newtonsoft.Json;

public class LikeRequestModel
{
    [JsonProperty("alg")]
    public string Alg { get; set; }
    [JsonProperty("trackId")]
    public string TrackId { get; set; }
    [JsonProperty("like")]
    public string Like { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
}
