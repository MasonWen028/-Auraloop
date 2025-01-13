using Newtonsoft.Json;

/// <summary>
/// Represents the parameters for fetching user-related content with pagination and video inclusion options.
/// </summary>
public class UserPlaylistRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [JsonProperty("uid")]
    public long Uid { get; set; }

    /// <summary>
    /// Gets or sets the maximum number of items to retrieve.
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
    /// Gets or sets a value indicating whether to include video content.
    /// Default is true.
    /// </summary>
    [JsonProperty("includeVideo")]
    public bool IncludeVideo { get; set; } = true;
}
