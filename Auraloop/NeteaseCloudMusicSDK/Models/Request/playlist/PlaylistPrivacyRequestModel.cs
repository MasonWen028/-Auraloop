
using Newtonsoft.Json;


/// <summary>
/// Represents the parameters required to update the privacy setting of a playlist.
/// </summary>
public class PlaylistPrivacyRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the privacy setting for the playlist.
    /// Default is 0 (public). Use 1 for private.
    /// </summary>
    [JsonProperty("privacy")]
    public int PrivacySetting { get; set; } = 0;
}
