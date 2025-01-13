using Newtonsoft.Json;

public class VideoTimelineRecommendRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("filterLives")]
    public string FilterLives { get; set; } = "[]";

    [JsonProperty("withProgramInfo")]
    public bool WithProgramInfo { get; set; } = true;

    [JsonProperty("needUrl")]
    public bool NeedUrl { get; set; } = true;

    [JsonProperty("resolution")]
    public string Resolution { get; set; } = "480";
}
