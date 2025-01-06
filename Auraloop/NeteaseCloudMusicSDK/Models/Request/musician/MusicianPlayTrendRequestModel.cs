
using Newtonsoft.Json;

public class MusicianPlayTrendRequestModel
{
    [JsonProperty("startTime")]
    public long StartTime { get; set; }
    [JsonProperty("endTime")]
    public long EndTime { get; set; }
}
