
using Newtonsoft.Json;

public class CommentRequestModel
{
    [JsonProperty("rid")]
    public string Id { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("beforeTime")]
    public long BeforeTime { get; set; } = 0;
}
