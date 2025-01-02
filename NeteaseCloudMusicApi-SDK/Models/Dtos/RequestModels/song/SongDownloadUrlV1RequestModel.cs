
using Newtonsoft.Json;

public class SongDownloadUrlV1RequestModel
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("immerseType")]
    public string ImmerseType { get; set; }
    [JsonProperty("level")]
    public string Level { get; set; }
}
