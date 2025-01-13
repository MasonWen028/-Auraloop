using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch new albums.
/// </summary>
public class AlbumNewRequestModel
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
    /// Default is true.
    /// </summary>
    [JsonProperty("total")]
    public bool Total { get; set; } = true;

    /// <summary>
    /// Gets or sets the area or region filter for new albums.
    /// Possible values:
    /// - "ALL": All regions
    /// - "ZH": Chinese (����)
    /// - "EA": European and American (ŷ��)
    /// - "KR": Korean (����)
    /// - "JP": Japanese (�ձ�)
    /// </summary>
    [JsonProperty("area")]
    public string Area { get; set; } = "ALL";
}
