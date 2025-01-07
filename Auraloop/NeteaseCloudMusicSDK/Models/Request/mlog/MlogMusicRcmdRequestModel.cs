using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to recommend music for Mlog posts.
/// </summary>
public class MlogMusicRcmdRequestModel
{
    /// <summary>
    /// Gets or sets the MV ID related to the recommendation. Default is 0.
    /// </summary>
    [JsonProperty("id")]
    public long MvId { get; set; } = 0;

    /// <summary>
    /// Gets or sets the song ID for generating recommendations.
    /// </summary>
    [JsonProperty("songId")]
    public long SongId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of recommendations to retrieve. Default is 10.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Gets or sets the recommendation type. Default is 20.
    /// </summary>
    [JsonProperty("rcmdType")]
    public int RecommendationType { get; set; } = 20;

    /// <summary>
    /// Gets or sets the extended information for generating recommendations.
    /// </summary>
    [JsonProperty("extInfo")]
    public string ExtendedInfo => JsonConvert.SerializeObject(new { songId = SongId });
}
