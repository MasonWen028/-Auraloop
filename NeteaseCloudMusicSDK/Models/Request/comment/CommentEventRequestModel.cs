
using Newtonsoft.Json;

public class CommentEventRequestModel
{
    [JsonProperty("limit")]
    public int Limit { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("beforeTime")]
    public long BeforeTime { get; set; }
}
