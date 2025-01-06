
using Newtonsoft.Json;

public class MsgCommentsRequestModel
{
    [JsonProperty("beforeTime")]
    public long BeforeTime { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
    [JsonProperty("uid")]
    public string Uid { get; set; }
}
