using Newtonsoft.Json;

public class VideoTimelineRequestModel
{
    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("need_preview_url")]
    public bool NeedPreviewUrl { get; set; } = true;

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
