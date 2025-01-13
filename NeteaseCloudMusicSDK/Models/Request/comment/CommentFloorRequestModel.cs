
using Newtonsoft.Json;

public class CommentFloorRequestModel
{
    [JsonProperty("parentCommentId")]
    public string ParentCommentId { get; set; }
    [JsonProperty("threadId")]
    public string ThreadId { get; set; } = "";
    [JsonProperty("time")]
    public long Time { get; set; } = -1;
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    public long Id { get; set; }
}
