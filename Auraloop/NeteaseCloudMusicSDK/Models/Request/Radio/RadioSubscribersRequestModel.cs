using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the list of subscribers for a specific radio station.
/// </summary>
public class RadioSubscribersRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the radio station.
    /// </summary>
    [JsonProperty("id")]
    public long RadioId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp to retrieve subscribers from a specific time.
    /// Default is -1 (fetch all).
    /// </summary>
    [JsonProperty("time")]
    public long Time { get; set; } = -1;

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve.
    /// Default is 20.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    /// <summary>
    /// Gets or sets a flag indicating whether to include the total count in the response.
    /// Default is true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
