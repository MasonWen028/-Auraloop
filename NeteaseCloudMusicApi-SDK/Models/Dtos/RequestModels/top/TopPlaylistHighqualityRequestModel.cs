
using Newtonsoft.Json;

public class TopPlaylistHighqualityRequestModel
{
    [JsonProperty("cat")]
    public string Cat { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("lasttime")]
    public long Lasttime { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
