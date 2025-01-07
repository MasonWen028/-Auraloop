using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to match a song in the cloud database.
/// </summary>
public class SongMatchRequestModel
{
    /// <summary>
    /// Gets or sets the user ID.
    /// </summary>
    [JsonProperty("uid")]
    public long UserId { get; set; }

    /// <summary>
    /// Gets or sets the song ID in the user's cloud storage.
    /// </summary>
    [JsonProperty("sid")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets an additional song ID for matching purposes.
    /// </summary>
    [JsonProperty("asid")]
    public long AdjustedSongId { get; set; }
}
