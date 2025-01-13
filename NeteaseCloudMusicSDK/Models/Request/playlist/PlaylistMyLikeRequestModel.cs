
using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve playlists liked by the user.
/// </summary>
public class PlaylistMyLikeRequestModel
{
    /// <summary>
    /// Gets or sets the timestamp to retrieve liked playlists from a specific time.
    /// Default is "-1" (fetch all).
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; } = "-1";

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve.
    /// Default is 12.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 12;
}
