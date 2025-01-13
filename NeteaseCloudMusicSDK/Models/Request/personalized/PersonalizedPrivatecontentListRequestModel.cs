using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve personalized private content with pagination.
/// </summary>
public class PersonalizedPrivatecontentListRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of private content items to retrieve. Default is 60.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 60;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    const bool total = true;
}
