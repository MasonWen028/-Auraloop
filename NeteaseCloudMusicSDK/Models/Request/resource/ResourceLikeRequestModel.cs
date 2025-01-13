using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to like or unlike a resource.
/// </summary>
public class ResourceLikeRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the resource.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the type of the resource (e.g., song, playlist, video).
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to like (true) or unlike (false) the resource.
    /// </summary>
    [JsonProperty("like")]
    public bool Like { get; set; }

    /// <summary>
    /// Gets or sets the thread ID of the resource, required for certain resource types.
    /// </summary>
    [JsonProperty("threadId")]
    public string ThreadId { get; set; }
}
