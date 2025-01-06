
using Newtonsoft.Json;

public class MsgNoticesRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("time")]
    public long Time { get; set; }
}
