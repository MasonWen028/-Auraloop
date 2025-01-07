using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the subscribers of a playlist.
/// </summary>
public class PlaylistSubscribersRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of subscribers to retrieve. Default is 20.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
