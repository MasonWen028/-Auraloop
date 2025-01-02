
using Newtonsoft.Json;

public class AlbumListStyleRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
    [JsonProperty("area")]
    public string Area { get; set; }
}
