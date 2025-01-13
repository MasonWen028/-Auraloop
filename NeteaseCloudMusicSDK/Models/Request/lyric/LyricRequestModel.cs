using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve lyrics for a song.
/// </summary>
public class LyricRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the song.
    /// </summary>
    [JsonProperty("id")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp for lyric versions. Default is -1.
    /// </summary>
    [JsonProperty("tv")]
    const int TimestampVersion = -1;

    /// <summary>
    /// Gets or sets the lyric version for standard lyrics. Default is -1.
    /// </summary>
    [JsonProperty("lv")]
    const int LyricVersion = -1;

    /// <summary>
    /// Gets or sets the romanized lyric version. Default is -1.
    /// </summary>
    [JsonProperty("rv")]
    const int RomanizedVersion = -1;

    /// <summary>
    /// Gets or sets the karaoke lyric version. Default is -1.
    /// </summary>
    [JsonProperty("kv")]
    const int KaraokeVersion = -1;

    /// <summary>
    /// Gets or sets an internal flag for lyric fetching. Default is 1.
    /// </summary>
    [JsonProperty("_nmclfl")]
    const int InternalFlag = 1;
}
