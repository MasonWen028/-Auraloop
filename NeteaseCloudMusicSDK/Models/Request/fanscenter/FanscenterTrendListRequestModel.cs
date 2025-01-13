
using Newtonsoft.Json;

public class FansCenterTrendListRequestModel
{
    [JsonProperty("startTime")]
    public long StartTime { get; set; }
    [JsonProperty("endTime")]
    public long EndTime { get; set; }
    [JsonProperty("type")]
    public int Type { get; set; }
}
