using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve detailed information about historically recommended songs.
/// </summary>
public class HistoryRecommendSongsDetailRequestModel
{
    /// <summary>
    /// Gets or sets the date for fetching detailed song recommendations in the format "yyyy-MM-dd".
    /// </summary>
    [JsonProperty("date")]
    public string Date { get; set; }
}
