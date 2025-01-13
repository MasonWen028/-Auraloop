using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to scrobble a song.
/// </summary>
public class ScrobbleRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the song.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the source identifier where the song was played (e.g., playlist or album ID).
    /// </summary>
    [JsonProperty("sourceId")]
    public long? SourceId { get; set; }

    /// <summary>
    /// Gets or sets the duration of playback in seconds.
    /// </summary>
    [JsonProperty("time")]
    public long? Time { get; set; }
}
