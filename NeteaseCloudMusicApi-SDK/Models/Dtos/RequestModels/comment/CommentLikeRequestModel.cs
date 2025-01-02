
using Newtonsoft.Json;

public class CommentLikeRequestModel
{
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
    [JsonProperty("commentId")]
    public string CommentId { get; set; }
}
