using Newtonsoft.Json;

/// <summary>
/// Request model for fetching popular comments for a specific resource.
/// </summary>
public class CommentHotRequestModel
{
    /// <summary>
    /// The ID of the corresponding resource.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// The type of the corresponding resource.
    /// </summary>
    [JsonProperty("type")]
    public ResourceType Type { get; set; }

    /// <summary>
    /// The number of comments to retrieve. Default is 20.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 20;

    /// <summary>
    /// Offset for pagination, calculated as (PageNumber - 1) * Limit.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Pagination parameter, the time of the last item on the previous page, 
    /// required when fetching more than 5000 comments.
    /// </summary>
    [JsonProperty("before")]
    public string Before { get; set; }
}