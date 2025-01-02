
using Newtonsoft.Json;

public class VideoCategoryListRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
}
