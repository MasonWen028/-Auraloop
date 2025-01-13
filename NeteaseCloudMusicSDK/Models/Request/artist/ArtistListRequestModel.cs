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
    public int Type { get; set; } = -1;

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
    public int Area { get; set; } = -1;

    /// <summary>
    /// The initial letter for filtering artists. varys from a-z/A-Z
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

    /// <summary>
    /// Get all artists
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}

