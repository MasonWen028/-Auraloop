
using Newtonsoft.Json;

public class HugCommentRequestModel
{
    [JsonProperty("targetUserId")]
    public string TargetUserId { get; set; }
    [JsonProperty("commentId")]
    public string CommentId { get; set; }
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
}
