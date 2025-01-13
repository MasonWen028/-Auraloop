
using Newtonsoft.Json;

public class SongUrlRequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("br")]
    public string Br { get; set; }
}
