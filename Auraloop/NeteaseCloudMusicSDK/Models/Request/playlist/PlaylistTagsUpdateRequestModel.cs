using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update the tags of a playlist.
/// </summary>
public class PlaylistTagsUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the new tags for the playlist.
    /// </summary>
    [JsonProperty("tags")]
    public string[] Tags { get; set; }
}
