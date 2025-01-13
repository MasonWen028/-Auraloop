using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to check the availability or validity of a music track.
/// </summary>
public class CheckMusicRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the music track.
    /// </summary>
    [JsonProperty("id")]
    public long MusicId { get; set; }

    /// <summary>
    /// Gets or sets the bitrate for the music track. Default is 999000.
    /// </summary>
    [JsonProperty("br")]
    public int Bitrate { get; set; } = 999000;
}
