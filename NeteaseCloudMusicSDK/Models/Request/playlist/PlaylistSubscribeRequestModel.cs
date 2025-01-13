
using Newtonsoft.Json;

public class PlaylistSubscribeRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the operation type.
    /// Use 1 for subscribe and 0 for unsubscribe.
    /// </summary>
    [JsonProperty("t")]
    public int Operation { get; set; }
}
