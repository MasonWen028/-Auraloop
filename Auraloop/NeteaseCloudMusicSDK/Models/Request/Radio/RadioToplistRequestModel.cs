using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the top-ranked radio stations.
/// </summary>
public class RadioToplistRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of results to retrieve.
    /// Default is 100.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;

    /// <summary>
    /// Gets or sets the offset for pagination.
    /// Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets the type of toplist.
    /// Example values: "new" for newcomers, "hot" for popular.
    /// Default is "hot".
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "hot";
}
