using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to remove tracks from a playlist.
/// </summary>
public class PlaylistTrackDeleteRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the track IDs to remove from the playlist.
    /// </summary>
    [JsonProperty("tracks")]
    public long[] TrackIds { get; set; }
}
