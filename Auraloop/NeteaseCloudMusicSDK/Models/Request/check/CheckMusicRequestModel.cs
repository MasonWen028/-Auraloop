
using Newtonsoft.Json;

public class CheckMusicRequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("br")]
    public string Br { get; set; }
}
