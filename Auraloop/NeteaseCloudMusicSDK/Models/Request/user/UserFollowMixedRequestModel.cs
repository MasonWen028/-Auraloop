using Newtonsoft.Json;


/// <summary>
/// Represents the parameters required to fetch followed entities with pagination and filtering options.
/// </summary>
public class UserFollowMixedRequestModel
{
    /// <summary>
    /// Gets or sets whether to include authority details.
    /// Default is "false".
    /// </summary>
    [JsonProperty("authority")]
    public string Authority { get; set; } = "false";

    /// <summary>
    /// Gets or sets the pagination details as a JSON object.
    /// </summary>
    [JsonProperty("page")]
    public PaginationModel Page { get; set; } = new PaginationModel();

    /// <summary>
    /// Gets or sets the scene for filtering followed entities.
    /// 0: All follows, 1: Followed artists, 2: Followed users.
    /// Default is 0.
    /// </summary>
    [JsonProperty("scene")]
    public int Scene { get; set; } = 0;

    /// <summary>
    /// Gets or sets the number of items to retrieve per page.
    /// Default is 30.
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; set; } = 30;

    /// <summary>
    /// Gets or sets the sorting type.
    /// Default is "0".
    /// </summary>
    [JsonProperty("sortType")]
    public string SortType { get; set; } = "0";
}

/// <summary>
/// Represents pagination details for the request.
/// </summary>
public class PaginationModel
{
    /// <summary>
    /// Gets or sets the maximum number of items to retrieve.
    /// Default is 30.
    /// </summary>
    [JsonProperty("size")]
    public int Size { get; set; } = 30;

    /// <summary>
    /// Gets or sets the cursor for pagination.
    /// Default is 0.
    /// </summary>
    [JsonProperty("cursor")]
    public int Cursor { get; set; } = 0;
}
