
using Newtonsoft.Json;

public class MsgForwardsRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
}