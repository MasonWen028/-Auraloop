
using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch an album list.
/// </summary>
public class AlbumListRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of albums to retrieve.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the offset for pagination.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// Gets or sets a value indicating whether to include the total count in the response.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;

    /// <summary>
    /// Gets or sets the area or region filter for albums.
    /// </summary>
    [JsonProperty("area")]
    public string Area { get; set; } = "all";

    /// <summary>
    /// Gets or sets the type of albums to filter.
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; } = 1; // Default type
}
