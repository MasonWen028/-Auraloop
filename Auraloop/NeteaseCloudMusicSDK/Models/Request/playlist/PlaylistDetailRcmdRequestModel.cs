using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve recommended playlists.
/// </summary>
public class PlaylistDetailRcmdRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("playlistId")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the scene for the recommendation.
    /// Default is "playlist_head".
    /// </summary>
    [JsonProperty("scene")]
    const string Scene = "playlist_head";

    /// <summary>
    /// Gets or sets a flag indicating whether to use the new style.
    /// Default is "true".
    /// </summary>
    [JsonProperty("newStyle")]
    const string NewStyle = "true";
}
