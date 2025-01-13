
using Newtonsoft.Json;

public class ListenDataReportRequestModel
{
    // No data fields found

    /// <summary>
    /// week/month/year
    /// </summary>
    /// <example> week </example>
    [JsonProperty("type")]
    public string Type { get; set; } = "week";

    /// <summary>
    /// if this entime is 0 it would return this week or this month based on the Type field
    /// </summary>
    [JsonProperty("endTime")]
    public long EndTime { get; set; } = 0;
}
