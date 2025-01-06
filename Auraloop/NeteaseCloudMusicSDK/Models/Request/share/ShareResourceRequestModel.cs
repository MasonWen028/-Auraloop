using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to share a resource to the user's dynamic feed.
/// </summary>
public class ShareResourceRequestModel
{
    /// <summary>
    /// Gets or sets the type of resource to share (e.g., song, playlist, mv, djprogram, djradio).
    /// Default is "song".
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "song";

    /// <summary>
    /// Gets or sets an optional message to include with the shared resource.
    /// </summary>
    [JsonProperty("msg")]
    public string Message { get; set; } = "";

    /// <summary>
    /// Gets or sets the unique identifier of the resource to share.
    /// </summary>
    [JsonProperty("id")]
    public string ResourceId { get; set; } = "";
}
