using Newtonsoft.Json;

/// <summary>
/// Represents the parameters required to report real-time listening data.
/// </summary>
public class ListenDataRealtimeReportRequestModel
{
    /// <summary>
    /// Gets or sets the type of report to submit. Valid values are "week" or "month". Default is "week".
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } = "week";
}
