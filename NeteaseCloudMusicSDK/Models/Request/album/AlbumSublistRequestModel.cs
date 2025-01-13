using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch the user's album subscription list.
/// </summary>
public class AlbumSublistRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of albums to retrieve.
    /// Default is 25.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 25;

    /// <summary>
    /// Gets or sets the offset for pagination.
    /// Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets a value indicating whether to include the total count in the response.
    /// Default is true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
