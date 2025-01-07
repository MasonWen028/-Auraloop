using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to send or delete a comment.
/// </summary>
public class CommentManageRequestModel
{
    /// <summary>
    /// Gets or sets the action type. Use "add", "delete", or "reply".
    /// </summary>
    [JsonProperty("action")]
    public string Action { get; set; }

    /// <summary>
    /// Gets or sets the thread identifier for the resource.
    /// </summary>
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }

    /// <summary>
    /// Gets or sets the content of the comment (required for "add" and "reply" actions).
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the comment (required for "delete" and "reply" actions).
    /// </summary>
    [JsonProperty("commentId")]
    public long? CommentId { get; set; }
}
