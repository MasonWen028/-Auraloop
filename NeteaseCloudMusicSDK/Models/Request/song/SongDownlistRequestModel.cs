
using Newtonsoft.Json;

public class SongDownlistRequestModel
{
    [JsonProperty("limit")]
    public string Limit { get; set; }
    [JsonProperty("offset")]
    public string Offset { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
}
