
using Newtonsoft.Json;

public class VideoTimelineRecommendRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("filterLives")]
    public string FilterLives { get; set; }
    [JsonProperty("withProgramInfo")]
    public string WithProgramInfo { get; set; }
    [JsonProperty("needUrl")]
    public string NeedUrl { get; set; }
    [JsonProperty("resolution")]
    public string Resolution { get; set; }
}
