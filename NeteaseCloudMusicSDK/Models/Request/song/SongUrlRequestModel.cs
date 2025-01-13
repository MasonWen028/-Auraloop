
using Newtonsoft.Json;

public class SongUrlRequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("br")]
    public long Br { get; set; }
}
