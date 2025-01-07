using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to fetch radio rankings.
/// </summary>
public class RadioRankingRequestModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the radio station. Default is null.
    /// </summary>
    [JsonProperty("djRadioId")]
    public long? DjRadioId { get; set; }

    /// <summary>
    /// Gets or sets the sorting index.
    /// <list type="bullet">
    /// <item><description>1: Play count</description></item>
    /// <item><description>2: Likes</description></item>
    /// <item><description>3: Comments</description></item>
    /// <item><description>4: Shares</description></item>
    /// <item><description>5: Favorites</description></item>
    /// </list>
    /// Default is 1 (Play count).
    /// </summary>
    [JsonProperty("sortIndex")]
    public int SortIndex { get; set; } = 1;

    /// <summary>
    /// Gets or sets the time range for the data.
    /// <list type="bullet">
    /// <item><description>7: One week</description></item>
    /// <item><description>30: One month</description></item>
    /// <item><description>90: Three months</description></item>
    /// </list>
    /// Default is 7 (One week).
    /// </summary>
    [JsonProperty("dataGapDays")]
    public int DataGapDays { get; set; } = 7;

    /// <summary>
    /// Gets or sets the data type (purpose unknown). Default is 3.
    /// </summary>
    [JsonProperty("dataType")]
    public int DataType { get; set; } = 3;
}
