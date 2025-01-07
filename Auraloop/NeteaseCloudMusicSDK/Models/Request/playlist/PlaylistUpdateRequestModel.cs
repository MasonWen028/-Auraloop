using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update a playlist's name, tags, and description.
/// </summary>
public class PlaylistUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the new name for the playlist.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the new tags for the playlist.
    /// </summary>
    [JsonProperty("tags")]
    public string[] Tags { get; set; }

    /// <summary>
    /// Gets or sets the new description for the playlist.
    /// Default is an empty string.
    /// </summary>
    [JsonProperty("desc")]
    public string Description { get; set; } = string.Empty;
}
