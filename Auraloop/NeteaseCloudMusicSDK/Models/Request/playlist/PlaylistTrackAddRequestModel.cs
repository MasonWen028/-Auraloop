using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to add tracks to a playlist.
/// </summary>
public class PlaylistTrackAddRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the track IDs to add.
    /// </summary>
    [JsonProperty("tracks")]
    public TrackModel[] TrackIds { get; set; }
}

public class TrackModel
{
    const int type = 3;

    [JsonProperty("id")]
    public long Id { get; set; }
}
