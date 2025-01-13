
using Newtonsoft.Json;

public class SongUrlV1RequestModel
{
    [JsonProperty("ids")]
    public string Ids { get; set; }
    [JsonProperty("level")]
    public string Level { get; set; }
    [JsonProperty("encodeType")]
    const string EncodeType = "flac";
}


public enum SongLevelForUrl
{
    standard,
    higher,
    exhigh,
    lossless,
    hires,
    jyeffect,
    sky,
    jymaster
}