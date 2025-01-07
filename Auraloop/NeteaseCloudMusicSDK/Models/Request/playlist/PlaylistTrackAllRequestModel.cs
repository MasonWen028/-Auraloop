using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve all tracks in a playlist with pagination.
/// </summary>
public class PlaylistTrackAllRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of tracks to retrieve. Default is 50.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
