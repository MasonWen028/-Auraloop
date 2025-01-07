using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve personalized new songs.
/// </summary>
public class PersonalizedNewsongRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of new songs to retrieve. Default is 10.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 10;

    /// <summary>
    /// Gets or sets the area or region ID for filtering new songs. Default is 0 (no filter).
    /// </summary>
    [JsonProperty("areaId")]
    public int AreaId { get; set; } = 0;
}
