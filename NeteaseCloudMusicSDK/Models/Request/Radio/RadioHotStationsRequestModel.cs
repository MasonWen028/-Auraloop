using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve popular radio stations in a specific category.
/// </summary>
public class RadioHotStationsRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the radio category.
    /// </summary>
    [JsonProperty("cateId")]
    public long CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve.
    /// Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the offset for pagination.
    /// Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
