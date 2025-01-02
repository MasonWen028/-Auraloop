
using Newtonsoft.Json;

public class SimiSongRequestModel
{
    [JsonProperty("songid")]
    public string Songid { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}
