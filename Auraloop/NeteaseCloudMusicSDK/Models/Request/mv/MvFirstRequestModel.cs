using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve the latest MVs.
/// </summary>
public class MvFirstRequestModel
{
    /// <summary>
    /// Gets or sets the region or area for filtering the latest MVs. Default is "" (no filter).
    /// </summary>
    [JsonProperty("area")]
    public string Area { get; set; } = "";

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
