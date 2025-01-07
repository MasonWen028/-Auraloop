using Newtonsoft.Json;

public class VideoGroupRequestModel
{
    [JsonProperty("groupId")]
    public long GroupId { get; set; }

    [JsonProperty("offset")]
    public int Offset { get; set; } = 0;

    [JsonProperty("need_preview_url")]
    public bool NeedPreviewUrl { get; set; } = true;

    [JsonProperty("total")]
    public bool Total { get; set; } = true;
}
