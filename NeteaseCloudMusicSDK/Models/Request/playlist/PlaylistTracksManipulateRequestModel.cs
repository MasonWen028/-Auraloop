using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to add or remove tracks from a playlist.
/// </summary>
public class PlaylistTracksManipulateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("pid")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the track IDs to add or remove.
    /// </summary>
    [JsonProperty("tracks")]
    public long[] TrackIds { get; set; }

    /// <summary>
    /// Gets or sets the operation type. Use "add" to add tracks or "del" to remove tracks.
    /// </summary>
    [JsonProperty("op")]
    public string Operation { get; set; } = "add";
}
