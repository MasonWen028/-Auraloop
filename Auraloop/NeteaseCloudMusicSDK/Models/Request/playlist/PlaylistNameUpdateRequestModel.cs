
using Newtonsoft.Json;


/// <summary>
/// Represents the parameters required to update the name of a playlist.
/// </summary>
public class PlaylistNameUpdateRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the playlist.
    /// </summary>
    [JsonProperty("id")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the new name for the playlist.
    /// </summary>
    [JsonProperty("name")]
    public string NewName { get; set; }
}
