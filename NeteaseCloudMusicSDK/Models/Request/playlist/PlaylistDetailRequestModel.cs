using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve playlist details.
/// </summary>
public class PlaylistDetailRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of subscriber details to retrieve. Default is 8.
    /// </summary>
    [JsonProperty("s")]
    public int SubscriberLimit { get; set; } = 8;

    /// <summary>
    /// Gets or sets the number of songs to retrieve in the playlist. Default is 100000.
    /// </summary>
    [JsonProperty("n")]
    public int SongLimit { get; set; } = 100000;
}
