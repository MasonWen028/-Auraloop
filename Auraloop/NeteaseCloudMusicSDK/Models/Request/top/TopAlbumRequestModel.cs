
using Newtonsoft.Json;

public class TopAlbumRequestModel
{
    [JsonProperty("area")]
    public string Area { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("year")]
    public string Year { get; set; }
    [JsonProperty("month")]
    public string Month { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
    [JsonProperty("rcmd")]
    public bool Rcmd { get; set; }
}
