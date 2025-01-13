using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch the album/song sales leaderboard.
/// </summary>
public class AlbumSongsaleboardRequestModel
{
    /// <summary>
    /// Gets or sets the album type.
    /// Possible values:
    /// - 0: Digital album
    /// - 1: Digital single
    /// Default is 0.
    /// </summary>
    [JsonProperty("albumType")]
    public int AlbumType { get; set; } = 0;

    /// <summary>
    /// Gets or sets the type of leaderboard.
    /// Possible values:
    /// - "daily": Daily leaderboard
    /// - "week": Weekly leaderboard
    /// - "year": Yearly leaderboard
    /// - "total": Total leaderboard
    /// Default is "daily".
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "daily";

    /// <summary>
    /// Gets or sets the year for the yearly leaderboard.
    /// Required only when <see cref="Type"/> is "year".
    /// </summary>
    [JsonProperty("year")]
    public int? Year { get; set; }
}
