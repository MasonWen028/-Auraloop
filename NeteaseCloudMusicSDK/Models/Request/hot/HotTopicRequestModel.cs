
using Newtonsoft.Json;

public class HotTopicRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
}
