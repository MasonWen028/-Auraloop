
using Newtonsoft.Json;

public class RecommendSongsDislikeRequestModel
{
    [JsonProperty("resId")]
    public string ResId { get; set; }
    [JsonProperty("resType")]
    public int ResType { get; set; } = 4;
    [JsonProperty("sceneType")]
    public int SceneType { get; set; } = 1;
}
