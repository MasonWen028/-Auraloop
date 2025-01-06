
using Newtonsoft.Json;

public class CalendarRequestModel
{
    [JsonProperty("startTime")]
    public long StartTime { get; set; }
    [JsonProperty("endTime")]
    public long EndTime { get; set; }
}
