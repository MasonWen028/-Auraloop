
using Newtonsoft.Json;

public class VideoUrlRequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("resolution")]
    public int Resolution { get; set; }
}
