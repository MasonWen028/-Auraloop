using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the playback URL of an MV.
/// </summary>
public class MvUrlRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the MV.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the desired resolution of the MV (e.g., 1080 for 1080p). Default is 1080.
    /// </summary>
    [JsonProperty("r")]
    public int Resolution { get; set; } = 1080;
}
