using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to generate an intelligent play mode song list.
/// </summary>
public class PlaymodeIntelligenceListRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the song being used as a reference.
    /// </summary>
    [JsonProperty("songId")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets the playlist ID for context in generating recommendations.
    /// </summary>
    [JsonProperty("playlistId")]
    public long PlaylistId { get; set; }

    /// <summary>
    /// Gets or sets the seed song ID for more targeted recommendations. Defaults to the SongId if not specified.
    /// </summary>
    [JsonProperty("startMusicId")]
    public long? SeedSongId { get; set; }

    /// <summary>
    /// Gets or sets the number of recommendations to generate. Default is 1.
    /// </summary>
    [JsonProperty("count")]
    public int Count { get; set; } = 1;

    const string type = "fromPlayOne";
}
