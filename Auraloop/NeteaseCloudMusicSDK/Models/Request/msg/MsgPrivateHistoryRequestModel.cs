
using Newtonsoft.Json;

public class MsgPrivateHistoryRequestModel
{
    [JsonProperty("userId")]
    public string UserId { get; set; }
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
    [JsonProperty("total")]
    public string Total { get; set; }
}
