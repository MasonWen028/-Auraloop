using Newtonsoft.Json;

/// <summary>
/// Request model for fetching a categorized list of artists.
/// </summary>
public class ArtistListRequestModel
{
    /// <summary>
    /// The type of artist:
    /// -1: All,
    /// 1: Male Singer,
    /// 2: Female Singer,
    /// 3: Band.
    /// </summary>
    [JsonProperty("type")]
    public ArtistType Type { get; set; } = ArtistType.All;

    /// <summary>
    /// The area of the artist:
    /// -1: All,
    /// 7: Chinese,
    /// 96: European/American,
    /// 8: Japanese,
    /// 16: Korean,
    /// 0: Other.
    /// </summary>
    [JsonProperty("area")]
    public ArtistArea Area { get; set; } = ArtistArea.All;

    /// <summary>
    /// The initial letter for filtering artists.
    /// </summary>
    [JsonProperty("initial")]
    public string Initial { get; set; }

    /// <summary>
    /// The offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// The limit for the number of results to return. Default is 50.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;
}

/// <summary>
/// Enumeration for the type of artist.
/// </summary>
public enum ArtistType
{
    All = -1,       // All
    MaleSinger = 1, // Male Singer
    FemaleSinger = 2, // Female Singer
    Band = 3        // Band
}

/// <summary>
/// Enumeration for the area of the artist.
/// </summary>
public enum ArtistArea
{
    All = -1,       // All
    Chinese = 7,    // Chinese
    Western = 96,   // European/American
    Japanese = 8,   // Japanese
    Korean = 16,    // Korean
    Other = 0       // Other
}
