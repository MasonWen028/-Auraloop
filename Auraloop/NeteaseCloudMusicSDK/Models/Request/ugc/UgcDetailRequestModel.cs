using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve user-contributed content details.
/// </summary>
public class UgcDetailRequestModel
{
    /// <summary>
    /// Gets or sets the audit status for filtering contributions.
    /// </summary>
    [JsonProperty("auditStatus")]
    public string AuditStatus { get; set; } = "";

    /// <summary>
    /// Gets or sets the number of results to retrieve. Default is 10.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets the order of results (e.g., ascending or descending). Default is "desc".
    /// </summary>
    [JsonProperty("order")]
    public string Order { get; set; } = "desc";

    /// <summary>
    /// Gets or sets the field to sort by. Default is "createTime".
    /// </summary>
    [JsonProperty("sortBy")]
    public string SortBy { get; set; } = "createTime";

    /// <summary>
    /// Gets or sets the type of content (e.g., 1 for artist, 2 for album).
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; } = 1;
}
