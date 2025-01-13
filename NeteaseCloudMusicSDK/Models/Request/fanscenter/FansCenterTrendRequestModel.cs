using Newtonsoft.Json;
using System;

/// <summary>
/// Represents the parameters required to retrieve trends related to fan activity.
/// </summary>
public class FansCenterTrendRequestModel
{
    /// <summary>
    /// Gets or sets the start time for fetching fan trends, in milliseconds since epoch. Defaults to 7 days ago.
    /// </summary>
    [JsonProperty("startTime")]
    public long StartTime { get; set; } = DateTimeOffset.UtcNow.AddDays(-7).ToUnixTimeMilliseconds();

    /// <summary>
    /// Gets or sets the end time for fetching fan trends, in milliseconds since epoch. Defaults to the current time.
    /// </summary>
    [JsonProperty("endTime")]
    public long EndTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    /// <summary>
    /// Gets or sets the type of trend to fetch.
    /// <list type="bullet">
    /// <item><description>0: New followers.</description></item>
    /// <item><description>1: New unfollows.</description></item>
    /// </list>
    /// Defaults to 0.
    /// </summary>
    [JsonProperty("type")]
    public int Type { get; set; } = 0;
}
