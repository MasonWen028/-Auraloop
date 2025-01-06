
using Newtonsoft.Json;

public class TopPlaylistRequestModel
{
    [JsonProperty("cat")]
    public string Cat { get; set; }
    [JsonProperty("order")]
    public string Order { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
