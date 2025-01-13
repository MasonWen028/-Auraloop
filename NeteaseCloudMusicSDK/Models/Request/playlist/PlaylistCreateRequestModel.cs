using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to create a new playlist.
/// </summary>
public class PlaylistCreateRequestModel
{
    /// <summary>
    /// Gets or sets the name of the new playlist.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the privacy setting for the playlist.
    /// Default is "0" (public playlist). Set to "10" for a private playlist.
    /// </summary>
    [JsonProperty("privacy")]
    public string Privacy { get; set; } = "0";

    /// <summary>
    /// Gets or sets the type of playlist.
    /// Default is "NORMAL". Other values: "VIDEO" for a video playlist, "SHARED" for a shared playlist.
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "NORMAL";
}
