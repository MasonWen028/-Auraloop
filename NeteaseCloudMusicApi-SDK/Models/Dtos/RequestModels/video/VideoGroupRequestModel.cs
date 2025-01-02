
using Newtonsoft.Json;

public class VideoGroupRequestModel
{
    [JsonProperty("groupId")]
    public string GroupId { get; set; }
    [JsonProperty("offset")]
    public int Offset { get; set; }
    [JsonProperty("need_preview_url")]
    public string NeedPreviewUrl { get; set; }
    [JsonProperty("total")]
    public bool Total { get; set; }
}
