using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve programs for a specific radio station.
/// </summary>
public class RadioProgramsRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the radio station.
    /// </summary>
    [JsonProperty("rid")]
    public long RadioId { get; set; }

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

    /// <summary>
    /// Gets or sets a value indicating whether to sort the results in ascending order.
    /// Default is false (descending order).
    /// </summary>
    [JsonProperty("asc")]
    public bool Ascending { get; set; } = false;
}
