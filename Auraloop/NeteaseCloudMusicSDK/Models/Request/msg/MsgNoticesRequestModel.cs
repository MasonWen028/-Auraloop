using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to retrieve general notices and notifications.
/// </summary>
public class MsgNoticesRequestModel
{
    /// <summary>
    /// Gets or sets the maximum number of results to retrieve. Default is 30.
    /// </summary>
    [JsonProperty("limit")]
    public int Limit { get; set; } = 30;

    /// <summary>
    /// Gets or sets the timestamp to fetch notices before a specific time. Default is -1.
    /// </summary>
    [JsonProperty("time")]
    public long LastTime { get; set; } = -1;
}
