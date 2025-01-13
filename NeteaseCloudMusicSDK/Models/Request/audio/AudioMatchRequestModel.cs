using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to match audio files in the system.
/// </summary>
public class AudioMatchRequestModel
{
    /// <summary>
    /// Gets or sets the duration of the audio file in seconds.
    /// </summary>
    [JsonProperty("duration")]
    public int Duration { get; set; }

    /// <summary>
    /// Gets or sets the raw audio fingerprint data.
    /// </summary>
    [JsonProperty("audioFP")]
    public string AudioFingerprint { get; set; }
}
