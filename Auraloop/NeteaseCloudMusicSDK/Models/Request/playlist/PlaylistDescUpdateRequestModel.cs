using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to update the description of a playlist.
/// </summary>
public class PlaylistDescUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the new description for the playlist.
    /// </summary>
    [JsonProperty("desc")]
    public string Description { get; set; }
}
