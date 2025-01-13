using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve all MVs with filtering and pagination.
/// </summary>
public class MvAllRequestModel
{
    /// <summary>
    /// Gets or sets the region or area for filtering MVs. Default is "all".
    /// </summary>
    /// <example>ȫ��</example>
    [JsonProperty("area")]
    public string Area { get; set; } = "ȫ��";

    /// <summary>
    /// Gets or sets the type or genre of MVs. Default is "all".
    /// </summary>
    /// <example>ȫ��</example>
    [JsonProperty("type")]
    public string Type { get; set; } = "ȫ��";

    /// <summary>
    /// Gets or sets the order in which to sort MVs. Default is "latest".
    /// </summary>
    /// <example>�������</example>
    [JsonProperty("order")]
    public string Order { get; set; } = "�������";

    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the offset for pagination. Default is 0.
    /// </summary>
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    const bool total = true;
}


