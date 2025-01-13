using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch user-related data with pagination and counts.
/// </summary>
public class UserFollowedsRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [JsonProperty("userId")]
    public string UserId { get; set; }

    /// <summary>
    /// Gets or sets the timestamp or time marker for the query.
    /// Default is "0".
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; } = "0";

    /// <summary>
    /// Gets or sets the maximum number of records to retrieve.
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
    /// Gets or sets a value indicating whether to include counts in the response.
    /// Default is "true".
    /// </summary>
    [JsonProperty("getcounts")]
    public bool GetCounts { get; set; } = true;
}
