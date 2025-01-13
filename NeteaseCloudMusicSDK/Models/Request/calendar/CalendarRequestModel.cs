using Newtonsoft.Json;
using System;

/// <summary>
/// Represents the parameters required to fetch calendar details.
/// </summary>
public class CalendarRequestModel
{
    /// <summary>
    /// Gets or sets the start time for fetching calendar details.
    /// Default is the current time.
    /// </summary>
    [JsonProperty("startTime")]
    public long StartTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    /// <summary>
    /// Gets or sets the end time for fetching calendar details.
    /// Default is the current time.
    /// </summary>
    [JsonProperty("endTime")]
    public long EndTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
}
