using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve recommended programs.
/// </summary>
public class ProgramRecommendRequestModel
{
    /// <summary>
    /// Gets or sets the category ID for filtering recommendations.
    /// Example values: 1 for a specific type.
    /// </summary>
    [JsonProperty("cateId")]
    public int CategoryId { get; set; } = 0;

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve.
    /// Default is 10.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Gets or sets the offset for pagination.
    /// Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;
}
