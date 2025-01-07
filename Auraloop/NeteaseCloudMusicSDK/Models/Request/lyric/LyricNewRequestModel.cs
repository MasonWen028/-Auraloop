using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve advanced lyrics for a song.
/// </summary>
public class LyricNewRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the song.
    /// </summary>
    [JsonProperty("id")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets a flag indicating whether to fetch copyright-protected lyrics. Default is false.
    /// </summary>
    [JsonProperty("cp")]
    public bool CopyrightProtected { get; set; } = false;

    /// <summary>
    /// Gets or sets the version of timestamped lyrics. Default is 0.
    /// </summary>
    [JsonProperty("tv")]
    public int TimestampedVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of standard lyrics. Default is 0.
    /// </summary>
    [JsonProperty("lv")]
    public int LyricVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of romanized lyrics. Default is 0.
    /// </summary>
    [JsonProperty("rv")]
    public int RomanizedVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of karaoke lyrics. Default is 0.
    /// </summary>
    [JsonProperty("kv")]
    public int KaraokeVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("yv")]
    public int TranslatedVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of timestamped translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("ytv")]
    public int TranslatedTimestampedVersion { get; set; } = 0;

    /// <summary>
    /// Gets or sets the version of romanized translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("yrv")]
    public int TranslatedRomanizedVersion { get; set; } = 0;
}
