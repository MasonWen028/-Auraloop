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
    const bool CopyrightProtected = false;

    /// <summary>
    /// Gets or sets the version of timestamped lyrics. Default is 0.
    /// </summary>
    [JsonProperty("tv")]
    const int TimestampedVersion = 0;

    /// <summary>
    /// Gets or sets the version of standard lyrics. Default is 0.
    /// </summary>
    [JsonProperty("lv")]
    const int LyricVersion = 0;

    /// <summary>
    /// Gets or sets the version of romanized lyrics. Default is 0.
    /// </summary>
    [JsonProperty("rv")]
    const int RomanizedVersion = 0;

    /// <summary>
    /// Gets or sets the version of karaoke lyrics. Default is 0.
    /// </summary>
    [JsonProperty("kv")]
    const int KaraokeVersion = 0;

    /// <summary>
    /// Gets or sets the version of translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("yv")]
    const int TranslatedVersion = 0;

    /// <summary>
    /// Gets or sets the version of timestamped translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("ytv")]
    const int TranslatedTimestampedVersion = 0;

    /// <summary>
    /// Gets or sets the version of romanized translated lyrics. Default is 0.
    /// </summary>
    [JsonProperty("yrv")]
    const int TranslatedRomanizedVersion = 0;
}
