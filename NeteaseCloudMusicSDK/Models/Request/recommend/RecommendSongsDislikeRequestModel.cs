
using Newtonsoft.Json;

public class RecommendSongsDislikeRequestModel
{
    [JsonProperty("resId")]
    public string ResId { get; set; }
    [JsonProperty("resType")]
    const int ResType = 4;
    [JsonProperty("sceneType")]
    const int SceneType = 1;
}
