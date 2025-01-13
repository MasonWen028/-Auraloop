
using Newtonsoft.Json;

public class LikeRequestModel
{
    [JsonProperty("alg")]
    public string Alg { get; set; } = "itembased";
    [JsonProperty("trackId")]
    public long TrackId { get; set; }
    [JsonProperty("like")]
    public bool Like { get; set; }
    [JsonProperty("time")]
    public string Time { get; set; } = "3";
}
