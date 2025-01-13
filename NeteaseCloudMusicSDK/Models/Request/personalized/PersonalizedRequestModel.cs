using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve personalized recommendations.
/// </summary>
public class PersonalizedRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of recommendations to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets whether to include the total count in the response. Default is true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;

    /// <summary>
    /// Gets or sets an optional parameter for advanced customization. Default is 1000.
    /// </summary>
    [JsonProperty("n")]
    public int AdvancedCustomization { get; set; } = 1000;
}
