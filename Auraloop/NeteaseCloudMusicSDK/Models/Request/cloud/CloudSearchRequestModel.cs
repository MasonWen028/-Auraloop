using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to search in the cloud database.
/// </summary>
public class CloudSearchRequestModel
{
    /// <summary>
    /// Gets or sets the search query or keywords.
    /// </summary>
    [JsonProperty("s")]
    public string Keywords { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 50.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 50;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets the type of content to search for. 1: 单曲, 10: 专辑, 100: 歌手, 1000: 歌单, 1002: 用户, 1004: MV, 1006: 歌词, 1009: 电台, 1014: 视频
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "1";

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
