using Newtonsoft.Json;

public class VipTimeMachineRequestModel
{
    [JsonProperty("startTime")]
    public long? StartTime { get; set; }

    [JsonProperty("endTime")]
    public long? EndTime { get; set; }

    [JsonProperty("type")]
    public int Type { get; set; } = 1;

    [JsonProperty("limit")]
    public int Limit { get; set; } = 60;
}
