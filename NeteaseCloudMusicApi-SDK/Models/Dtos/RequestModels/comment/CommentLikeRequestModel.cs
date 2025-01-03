
using Newtonsoft.Json;

/// <summary>
/// Request model for liking or unliking a comment on a specific resource.
/// </summary>
public class CommentLikeRequestModel
{
    /// <summary>
    /// The ID of the corresponding resource.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// The operation type: 
    /// 1 for liking the comment, 
    /// any other value for unliking the comment.
    /// </summary>
    [JsonProperty("t")]
    public int Operation { get; set; }

    /// <summary>
    /// The type of the corresponding resource.
    /// </summary>
    [JsonProperty("type")]
    public ResourceType Type { get; set; }
}
