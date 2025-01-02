
using Newtonsoft.Json;

public class SongUrlV1RequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("level")]
    public string Level { get; set; }
    [JsonProperty("encodeType")]
    public string EncodeType { get; set; }
}
